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
        private ICalculator _calculator;
        private IEmailService _emailService;

        public UsersController(ICalculator calculator, IEmailService emailService)
        {
            _calculator = calculator;
            _emailService = emailService;
        }
        public int AddUser(string name)
        {
            throw new NotImplementedException();
        }
    }
}
