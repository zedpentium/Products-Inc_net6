using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string msg) : base(msg)
        {

        }
    }
}
