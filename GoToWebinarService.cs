using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Project.Models;

namespace Project.Services
{
    public class GoToWebinarService
    {
        public AuthModel Auth;
        public string BaseURL;
	
		// auth = One instance of the AuthModel class. You only really need access_token and organizer_key.
        public void SetAuth(AuthModel auth)
        {
            Auth = auth;
            BaseURL = "https://api.citrixonline.com/";
        }
        
        // Example endpoint access. Gets the authenticated user's upcomming webinars.
        public List<UpcomingWebinar> getUpcomingWebinars()
        {
            var client = new RestClient(BaseURL);

            var request = new RestRequest("G2W/rest/organizers/{organizerKey}/upcomingWebinars ", Method.GET);

            request.AddUrlSegment("organizerKey", Auth.organizer_key);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", " OAuth oauth_token=" + Auth.access_token);

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            IRestResponse<List<UpcomingWebinar>> response = client.Execute<List<UpcomingWebinar>>(request);
            return response.Data;
        }
    }
}