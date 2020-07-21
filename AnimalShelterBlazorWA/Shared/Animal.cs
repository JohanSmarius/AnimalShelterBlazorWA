using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Shared
{
    public class Animal
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                {
                    var calculatedAge = DateTime.Today.Year - DateOfBirth.Value.Year;

                    if (DateTime.Today.DayOfYear < DateOfBirth.Value.DayOfYear)
                    {
                        calculatedAge -= 1;
                    }

                    return calculatedAge;
                }

                return EstimatedAge.Value;
            }

        }

        public int? EstimatedAge { get; set; }

        [Required]
        public AnimalKind AnimalKind { get; set; }

        public string PictureUrl { get; set; }

        public Gender Gender { get; set; }
    }
}
