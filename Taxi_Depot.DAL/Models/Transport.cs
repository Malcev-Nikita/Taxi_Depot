using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Depot.DAL.Models
{
    public class Transport
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string StateNumber { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public bool Seller { get; set; }

        public int DriverId { get; set; }

        public List<Order> Numbers { get; set; } = new List<Order>();
    }
}
