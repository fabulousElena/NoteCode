using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo02.Services
{
    public class EmailService:IMessageService
    {
        public string Send()
        {
            return "ThisEmail";
        }
    }
}
