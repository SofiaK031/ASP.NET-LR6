namespace LR6.Services
{
    public class UserService : IUserService
    {
        static List<UserModel> users = new List<UserModel>();

        public UserModel CreateUser(string firstName, string lastName, int age)
        {
            var newUser = new UserModel(firstName, lastName, age);
            users.Add(newUser);
            return newUser;
        }

        public UserModel GetUser(Guid id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
    }
}
