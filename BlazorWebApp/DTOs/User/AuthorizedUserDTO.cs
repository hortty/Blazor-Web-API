using BlazorWebApp.DTOs;

namespace BlazorWebApp.DTOs
{
    public class AuthorizedUser
    {

        public AuthorizedUser(UserDTO usuario, string senha, Util.Enum.UserRole papel)
        {
            User = usuario;
            Token = senha;
            UserRole = papel;
            Login = usuario.Login;
        }

        public UserDTO User { get; set; }
        public string Token { get; set; }
        public Util.Enum.UserRole UserRole { get; set; }
        public string Login { get; set; }
        
    }
}
