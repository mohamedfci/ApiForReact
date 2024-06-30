

using ApiForReact.DTO;
using ApiForReact.Services;

namespace ClaenArch.Services
{
    public class AuthManager: IAuthManager
    {
        private readonly ITokenService _tokenService;
      //  private readonly ApplicationDbContext _context; // Inject your DbContext here

        public AuthManager(ITokenService tokenService)
        {
            _tokenService = tokenService;
            
        }

        public string Authenticate(string username, string password)
        {

            // Example logic: Check username and password against database
           // var user = _context.TblUsers.SingleOrDefault(u => u.UserName == username && u.Pass == password);

            // For Test With No MSSql
            TblUsers user=new TblUsers ();
            user.Id = 1;
            user.UserName = username;
            user.Pass   = password;
            user.Role = "Emp";


            if (user.UserName == "admin" && user.Pass == "admin")
            {
                // Generate JWT token
                return _tokenService.GenerateJwtToken(user);

            }

            

            return null; // User not found or invalid credentials

        }
    }

}
