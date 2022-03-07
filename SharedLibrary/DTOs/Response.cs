using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs
{
    //HER BİR ENDPOINT'E İSTEK YAPILDIĞINDA BAŞARILI DA OLSA BAŞARISIZ DA OLSA AYNI RESPONSE SINIFI DÖNÜLECEK ..!!!1!1
    public class Response<T> where T : class
    {
        // private set ---> çünkü: bu propları bu class içerisinde set edeceğimm
        #region property
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDto ErrorDto { get; private set; }

        //Clientlara açmayacağımız property.. !!11! Sebebi: program içerisinde isteklerin başarılı olup olmayacağını StatusCode veya Data üzerinden takip etmek yerine bu prop'tan edelim:
        //JsonIgnore: 
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        #endregion

        #region method
        //Ekleme işlemlerinde data dönülmelidir. Db'ye eklenen veriye bir id atanacağı için, bu id ile bir işlem yapılabilir.
        public static Response<T> Success(T data, int statusCode)   //TODO: neden static?
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessful= true};
        }

        //update,delete gibi işlemlerde endpointten data dönülmesine gerek kalınmadığı için kullanılacak metot. 
        //200 durum kodu ile birlikte boş data dönebiliriz.
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode , IsSuccessful = true};
        }

        public static Response<T> Fail(int statusCode, ErrorDto errorDto)
        {
            return new Response<T> { StatusCode = statusCode, ErrorDto = errorDto, IsSuccessful = false };
        }

        //Tek bir hata dönmek için yardımcı metodumuz
        //isShow'un var olma sebebi gelen datayı(hatayı) kullanıcıya göstereli mi?
        public static Response<T> Fail(string error, bool isShow, int statusCode)
        {
            //ErrorDto nesnesinin 3 tane overload'ı bulunuyor. Tek hata için 2. overload kullanıldı.
            ErrorDto errorDto = new ErrorDto(error, isShow);
            return new Response<T> { ErrorDto = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
        #endregion
    }
}
