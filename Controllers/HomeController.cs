using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace LR6.Controllers
{
    public class HomeController(IProductService productService, IOrderService orderService, IUserService userService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly IOrderService _orderService = orderService;
        private readonly IUserService _userService = userService;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeOrder(string firstName, string lastName, int age)
        {
            var sb = new StringBuilder();

            if (age < 16 || age > 100)
            {
                sb.Append("We are sorry, but you are underage... We only serve people over the age of 16. \n");
            }

            if (string.IsNullOrEmpty(firstName))
            {
                sb.Append("Enter your first name, please! \n");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                sb.Append("Enter your last name, please! \n");
            }

            ViewData["ErrorMessage"] = sb.ToString();

            if (string.IsNullOrEmpty(ViewData["ErrorMessage"] as string))
            {
                var newUser = _userService.CreateUser(firstName, lastName, age);
                ViewData["newUserGuid"] = newUser.Id;
                ViewData["AvailableProducts"] = _productService.GetProducts();
            }

            return View();
        }


        public IActionResult CreateOrder(Guid userGuid,
                                         int quantityOfProductTypes,
                                         int currentProductId,
                                         int quantityOfCurrentProduct,
                                         int currentNumberOfForm = 1,
                                         Guid? orderId = null)
        {
            ViewData["currentNumberOfForm"] = currentNumberOfForm;
            ViewData["quantityOfProductTypes"] = quantityOfProductTypes;

            if (quantityOfProductTypes >= 1 || quantityOfProductTypes <= _productService.GetProducts().Count)
            {
                OrderModel currentOrder = orderId.HasValue ? _orderService.GetOrder((Guid)orderId) : _orderService.CreateOrder(userGuid);

                var products = _productService.GetProducts();
                ViewData["AvailableProducts"] = products;
                ViewData["orderId"] = currentOrder.Id;

                //Якщо товар не обрано
                if (currentProductId == 0)
                {
                    return View();
                }
                else
                {
                    //Оновлення замовлення
                    var currentProduct = _productService.FindProductById(currentProductId);
                    _orderService.AddProduct(currentOrder, currentProduct, quantityOfCurrentProduct);

                    //Видалення продуктів, які вже були обрані
                    currentOrder.Products.ForEach(orderItem =>
                    {
                        products.RemoveAll(p => p.id == orderItem.Product.id);
                    });
                    ViewData["AvailableProducts"] = products;
                }

                //Якщо форма остання
                if (currentNumberOfForm.Equals(quantityOfProductTypes))
                {
                    return RedirectToAction("ShowOrder", new { orderId = currentOrder.Id });
                }
                else
                {
                    //Наступна форма для обрання
                    ViewData["currentNumberOfForm"] = ++currentNumberOfForm;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult ShowOrder(Guid orderId)
        {
            var order = _orderService.GetOrder(orderId);
            ViewData["totalPrice"] = order.Products.Sum(p => p.Product.Price * p.Quantity);

            var warningMessages = new List<string>(); // List to hold warning messages

            foreach (var orderItemModel in order.Products)
            {
                if (orderItemModel.Quantity > orderItemModel.Product.AvailableQuantity)
                {
                    warningMessages.Add($"You have ordered more pieces of '{orderItemModel.Product.Name}' than there are currently available! Please, change your choice.");
                }
            }

            if (warningMessages.Count > 0)
            {
                ViewData["warningMessages"] = warningMessages;
            }

            ViewData["displayTable"] = !warningMessages.Any();

            return View(order);
        }


        /*public IActionResult ShowOrder(Guid orderId)
        {
            var order = _orderService.GetOrder(orderId);
            ViewData["totalPrice"] = order.Products.Sum(p => p.Product.Price * p.Quantity);

            var sb = new StringBuilder();
            bool hasExceededQuantity = false;

            foreach (var orderItemModel in order.Products)
            {
                if (orderItemModel.Quantity > orderItemModel.Product.AvailableQuantity)
                {
                    sb.Append($"You have ordered more pieces of '{orderItemModel.Product.Name}' than are currently available! Please, change your choice.");
                    hasExceededQuantity = true;
                }
            }

            if (sb.ToString() != String.Empty)
            {
                ViewData["warningMessage"] = sb.ToString();
            }

            ViewData["displayTable"] = !hasExceededQuantity;

            return View(order);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
    }
}
