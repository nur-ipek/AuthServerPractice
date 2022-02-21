using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.Models
{
    public class UserApp: IdentityUser //Identıty user içerisinde bulunan alanlar veri tabanına sutün olarak eklenmektedir.  
    {
        public string City { get; set; }

    }
}
