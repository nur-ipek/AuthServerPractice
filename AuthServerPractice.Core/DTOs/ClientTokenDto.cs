using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.DTOs
{
    //Client'lara döneceğimiz token modelleri
    //Hava tahmini, yemek tarifi dönen üyelik sistemi gerektirmeyen API'ler için Client'ın kendisini tanımlayan token gereklidir.
    public class ClientTokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
