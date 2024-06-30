
using ApiForReact.DTO;

namespace ClaenArch.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(TblUsers user);
    }
}
