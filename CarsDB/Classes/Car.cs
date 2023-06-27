using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsDB.Classes
{
    public class Car
    {
        [Key]//annotations - annotáció
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("car_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        [MaxLength(50)]
        [Required]
        public double PriceInMillion { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandID { get; set; }


        [NotMapped]
        public virtual Brand Brand { get; set; }

        public override string ToString()
        {
            return Id + ": " + Brand.Name + " " + Type + ", Price: " + Math.Round(PriceInMillion,2) + " M";
        }
    }
}
