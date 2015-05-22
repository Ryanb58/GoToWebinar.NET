using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    /// <summary>
    /// Auth objects is created via the response from grabbing an accessKey.
    /// </summary>
    public class AuthModel
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string organizer_key { get; set; }
        public string account_key { get; set; }
        public string account_type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string platform { get; set; }
        public string version { get; set; }
    }
}