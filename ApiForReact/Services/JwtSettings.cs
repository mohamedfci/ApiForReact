namespace ClaenArch.Services
{
     
        public class JwtSettings
        {
            public string ValidIssuer { get; set; }
            public string ValidAudience { get; set; }
            public string SymmetricSecurityKey { get; set; }
            public string JwtRegisteredClaimNamesSub { get; set; }

            public int ExpirationMinutes { get; set; }
        }
}
