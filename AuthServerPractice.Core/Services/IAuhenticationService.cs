using AuthServerPractice.Core.DTOs;
using AuthServerPractice.Core.Models;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.Services
{
    public interface IAuhenticationService //Kimlik Doğrulama
    {
        Task<Response<TokenDto>> CreateToken(LoginDto loginDto);

        //RefreshToken ile yeni bir token alınabilir.
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        //Kötü amaçlı kullancı tespiti yapıldığında kullanıcının refreshtoken'ını bloke etmek için
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

        //Üyelik sistemi olmadan Client ile beraber Token alanabilir
        Task<Response<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);




    }
}
