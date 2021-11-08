using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public User(string UserId, string UserEmail, string UserName)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserEmail = UserEmail;
        }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }

    }
}
