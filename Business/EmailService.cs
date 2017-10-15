using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business
{
    public class EmailService : IEmailService
    {
        public string Message { get; set; }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
