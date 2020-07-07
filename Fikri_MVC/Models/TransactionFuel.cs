using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fikri_MVC.Models
{
    [Table ("TB_R_TransactionFuel")]
    public class TransactionFuel
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string FuelType { get; set; }
        public int Capacity { get; set; }
        public int? Consumer_Id { get; set; }
        [ForeignKey("Consumer_Id")]
        public virtual Consumer Consumer { get; set; }
        public int? Employee_Id { get; set; }
        [ForeignKey("Employee_Id")]
        public virtual Employee Employee{ get; set; }
    }
}