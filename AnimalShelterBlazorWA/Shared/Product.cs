using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnimalShelterBlazorWA.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100)]
        public int VatPercentage { get; set; }

        [NotMapped] public decimal NetPrice => Price * (1 + (VatPercentage / 100));

        [Required]
        public string ProductImage { get; set; }

    }
}
