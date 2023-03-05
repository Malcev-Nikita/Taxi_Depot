using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Depot.DAL.Enums;

namespace Taxi_Depot.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string ClientPhone { get; set; }

        public OrderStatus.OrderStatusEnum Status { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string From { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Where { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public int Cost { get; set; }
    }
}
