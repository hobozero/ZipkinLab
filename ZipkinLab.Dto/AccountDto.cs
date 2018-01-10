namespace ZipkinLab.Dto
{
    public class AccountDto
    {
        public AccountDto()
        {
            
        }
        public AccountDto(int accountId, CustomerDto customer)
        {
            AccountId = accountId;
            Customer = customer;
        }
        public int AccountId { get; set; }
        public CustomerDto Customer { get; set; }


    }
}