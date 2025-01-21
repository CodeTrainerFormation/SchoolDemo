namespace DomainModel
{
    public class Person
    {
        public int PersonID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Title { get; set; }
        public int? Age { get; set; }
    }
}
