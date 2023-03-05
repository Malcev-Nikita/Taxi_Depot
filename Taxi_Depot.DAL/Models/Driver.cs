using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Depot.DAL.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Это поле обязательно")]
        public string Phone { get; set; }

        public List<Transport> Transport { get; set; } = new List<Transport>();
    }
}
