using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.Configurations
{
    public class Client
    {
        public int Id { get; set; }
        public string Secret { get; set; }

        //PAYLOAD bölümünde görünecek..
        public List<String> Audiences { get; set; }
    }
}
