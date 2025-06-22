using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.UsersServices
{
    public class UserService
    {   
        private readonly UserRepo _userRepo;

        public UserService(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }
    }
}
