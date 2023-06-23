using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsDB.Classes
{
    [Table("brand")]
    public class Brand
    {
        [Key]//annotations - annotáció
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("brand_id",TypeName ="int")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars {get; set;}

        public Brand()
        {
            Cars = new HashSet<Car>(); //gyors keresés, indexelés nem szükséges
        }
    }
}
