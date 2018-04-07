namespace PizzaOrderWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dish")]
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string FoodID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Size { get; set; }

        public double Price { get; set; }

        public virtual Food Food { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
