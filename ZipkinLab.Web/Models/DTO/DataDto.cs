namespace ZipkinLab.Web.Models.DTO
{
    public class DataDto
    {
        public DataDto(string firstName, string lastName, int accountId)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountId = accountId;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public int AccountId { get; private set; }
    }
}