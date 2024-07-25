using DealerPortalApp.Models.DTOs;

namespace DealerPortalApp.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
