using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLib.Entitys
{
    public class UserEntity :BaseEntity //user herda campos da base
    {
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
    }
}
