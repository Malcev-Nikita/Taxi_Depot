using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Depot.DAL.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Base { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Comfy { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Express { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Wchild { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
