using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fikri_MVC.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public int Nip { get; set; }


    }
}