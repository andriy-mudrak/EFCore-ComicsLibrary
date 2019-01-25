using System;
using System.Collections.Generic;
using System.Linq;
using task1_3;
using task1_3.Tables;
using task1_3.Repositories;
using task1_3.BusinessLogicLayer;

namespace task1_3.BusinessLogicLayer
{
    public class BusinessOperations: IBusinessOperations
    {
        public bool isProfitable(Comix auth, int primeCost)
        {
            return auth.Price > primeCost;
        }
    }
}