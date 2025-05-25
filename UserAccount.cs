using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CashierApplication
{
    public abstract class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public UserAccount(string username, string password, string fullName, string department)
        {
            Username = username;
            Password = password;
            Name = fullName;
            Department = department; ;
        }

        public abstract bool ValidateCredentials(string username, string password);

        public virtual string GetWelcomeMessage()
        {
            return $"Welcome, {Name} from {Department}";
        }
    }
    public class Cashier : UserAccount
    {
        public Cashier(string username, string password, string name, string department)
        : base(username, password, name, department)
        {

        }


        public override bool ValidateCredentials(string username, string password)
        {
            return this.Username == username && this.Password == password;
        }

        public override string GetWelcomeMessage()
        {
            return $"Cashier Login Successful!\n{base.GetWelcomeMessage()}";
        }
    }
}

