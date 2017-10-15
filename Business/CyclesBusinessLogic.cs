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
        private IUsersController _usersController;

        public CyclesBusinessLogic(IUsersController usersController)
        {
            _usersController = usersController;
        }

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
