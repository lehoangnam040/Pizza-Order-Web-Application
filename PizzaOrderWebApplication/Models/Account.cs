namespace PizzaOrderWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string User { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
