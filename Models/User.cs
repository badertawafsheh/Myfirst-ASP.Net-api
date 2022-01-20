using models.first_web_api;
using System.Collections.Generic;

namespace first_web_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswiordSalt { get; set; }

        public List<Character> Characters { get; set; }

    }
}
