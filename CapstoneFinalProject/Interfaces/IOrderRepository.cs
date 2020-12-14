using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneFinalProject.Models;

namespace CapstoneFinalProject.Interfaces
{
    interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
