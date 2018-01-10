namespace ZipkinLab.Dto
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            
        }
        public CustomerDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}