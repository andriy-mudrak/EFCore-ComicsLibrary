using System;
using System.Collections.Generic;
using System.Text;
using task1_3.Tables;

namespace task1_3.BusinessLogicLayer
{
    public interface IBusinessOperations
    {
        bool isProfitable(Comix auth, int primeCost);

    }
}
