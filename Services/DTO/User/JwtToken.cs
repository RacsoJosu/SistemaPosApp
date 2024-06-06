using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.User
{

    public enum Roles
    {
        Admin,
        User
    }
    public class JwtToken
    {
        public string Token { get; set; }

        
        public Guid Id { get; set; }


        public string Role { get; set; }

        public string UserName { get; set; }

        public TimeSpan Validity { get; set; }

        public string RefreshToken { get; set; }

        public string EmailId { get; set; }

       

        public DateTime ExpiredTime { get; set; }


    }
}
