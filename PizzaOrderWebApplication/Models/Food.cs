namespace PizzaOrderWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Food")]
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            Dishes = new HashSet<Dish>();
        }

        [StringLength(10)]
        public string FoodID { get; set; }

        [Required]
        [StringLength(50)]
        public string FoodName { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public int CategoryID { get; set; }

        [StringLength(100)]
        public string ImageString { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
