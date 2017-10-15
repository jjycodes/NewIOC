using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business
{
    public class CyclesBusinessLogic : ICyclesBusinessLogic
    {
        public CyclesBusinessLogic(IUsersController usersController)
        {
            UsersController = usersController;
        }

        public IUsersController UsersController { get; set; }

        public void AddNewCycle(string cycleName)
        {
            throw new NotImplementedException();
        }

        public void AddCycleUsers()
        {
            throw new NotImplementedException();
        }

        public int Compute()
        {
            throw new NotImplementedException();
        }
    }
}
