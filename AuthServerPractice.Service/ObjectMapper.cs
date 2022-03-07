using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Service
{
    public static class ObjectMapper
    {
        //Mesele,
        //Bir class var.
        //Class'ın bir property'sinde yüklü bir veri var.
        //Bu datanın ihtiyaç durumunda yüklenmesini istiyorum
        //Bu gibi durumlarda Lazy kullanabilirim.

        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>

        {
            var config = new MapperConfiguration(x =>
            { 
              x.AddProfile<DtoMapper>(); 
            });

            return config.CreateMapper();

        });


        public static IMapper Mapper => lazy.Value;
    }
}
