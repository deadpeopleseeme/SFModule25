using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
    public class UserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        // Метод для получения всех пользователей
        public IEnumerable<User> GetAllUsers()
        {
            return [.. _context.Users];
        }

        // Метод для получения пользователя по email
        // Можно использовать нахождение по Id, но это не очень логично, т.к. мы скорее знаем email юзера, чем его ID в базе
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }


        // Метод для обновления email пользователя по id
        public void UpdateUserEmail(int id, string newEmail)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Email = newEmail;
            }
        }

        // Метод для обновления имени пользователя по email
        public void UpdateUserNameByEmail(string email, string newName)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.Name = newName;
            }
        }

        // Метод для удаления пользователя по email
        public void DeleteUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
    }
}