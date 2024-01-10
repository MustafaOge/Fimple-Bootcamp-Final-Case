using BankingApp.Core.Entities;

namespace BankingApp.Entities
{
    public class User  : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public List<string> Roles { get; set; }

        public User() 
        {
            Roles = new List<string> {"user"};
        }





    }
}


