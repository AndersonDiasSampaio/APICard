using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICard.Data
{
    public class UserCredCard
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public void SetEmail(string email)
        {
            this.Email = email;
        }
        public string Card { get; set; }
        public void SetCard(string card)
        {
            this.Card = card;
        }
       
    }

}
