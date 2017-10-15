using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business
{
    public interface IUsersController
    {
        ICalculator Calculator { get; set; }
        IEmailService EmailService { get; set; }
        int AddUser(string name);
    }
}
