using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Depot.DAL.Enums
{
    public class OrderStatus
    {
        public enum OrderStatusEnum
        {
            Waiting,
            OnMove,
            Delivered,
            Canceled
        }
    }
}
