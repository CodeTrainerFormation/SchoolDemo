using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table(nameof(School))]
    public record School
    {
        [Key]
        public int SchoolID { get; init; }

        [StringLength(50)]
        [Required]
        public required string Name { get; set; }

        public ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
