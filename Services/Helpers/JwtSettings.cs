using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class JwtSettings
    {

        public bool ValidateIssuerSgningKey { get; set; }

        public string IssueSigningKey { get; set; } = string.Empty;

        public bool ValidateIssuer { get; set; } = true;

        public string ValidIssuer { get; set; } = string.Empty;

        public bool ValidateAudience { get; set; } = true;

        public string ValidAudience { get; set; } = string.Empty;

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; }
    }
}
