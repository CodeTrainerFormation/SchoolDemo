using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Person")]
    public record Person
    {
        [Key]
        public int PersonID { get; init; }

        [StringLength(50)]
        public required string FirstName { get; set; }

        [StringLength(100)]
        public required string LastName { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }

        [Range(0, 140)]
        public int? Age { get; set; }

        public School? School { get; set; }
    }
}
