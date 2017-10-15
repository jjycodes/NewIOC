using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business
{
    public class UsersController : IUsersController
    {
        public ICalculator Calculator { get; set; }
        public IEmailService EmailService { get; set; }

        public UsersController(ICalculator calculator, IEmailService emailService)
        {
            Calculator = calculator;
            EmailService = emailService;
        }
        public int AddUser(string name)
        {
            throw new NotImplementedException();
        }
        
    }
}
