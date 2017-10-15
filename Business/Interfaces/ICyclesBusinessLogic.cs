using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICyclesBusinessLogic
    {
        IUsersController UsersController {get; set;}

        void AddNewCycle(string cycleName);

        void AddCycleUsers();

        int Compute();
    }
}
