using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Account
    {
        public string Name { get; set; }
        public string Salt { get; set; }
        public int[] RandomNumbers { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime Date { get; set; }
    }
}
