namespace DomainModel
{
    public record Person
    {
        public int PersonID { get; init; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Title { get; set; }
        public int? Age { get; set; }

        public School? School { get; set; }
    }
}
