using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fikri_MVC.Models
{
    [Table("TB_M_Consumer")]
    public class Consumer
    {
        [Key]
        public int Consumer_Id { get; set; }
        public string Vehicle_Name { get; set; }
        public string Fuel_Type { get; set; }
        public  int Capacity { get; set; }

    }
}