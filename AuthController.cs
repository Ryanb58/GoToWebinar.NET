using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Controller
{
    public class AuthController
    {
        public string baseURL;
        public string authorizationURL;
        public string clientKey;
        public AuthModel Access;
        public string returnURL;

        //Constructor
        public AuthController()
        {
            //Initalize properties.
            baseURL = "https://api.citrixonline.com/";              //Base url every endpoint begins with
            authorizationURL = baseURL + "oauth/authorize";         //Build auth url from baseURL
            clientKey = "YOUR_CLIENT_KEY_HERE";                     //Client Key
            Access = new AuthModel();                               //Empty AuthObject
        }
        
        // return_url = the url you want GoToWebinar's page to post back too.
        public string getAuthorizationURL(string return_url)
        {
            returnURL = return_url;

            var builder = new UriBuilder(authorizationURL);

            //Append access token.
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["client_id"] = clientKey;
            query["redirect_uri"] = returnURL;
            builder.Query = query.ToString();

            //Return the finalized URL
            return builder.ToString();
        }
    
        // responseCode = the ?code=##### parameter that GoToWebinar posts back to your return_url.
        public AuthModel getAuth(string responseCode)
        {
            //Send off Response key
            var client = new RestClient("https://api.citrixonline.com/");

            var request = new RestRequest("oauth/access_token", Method.GET);

            //Add the parameters.
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", responseCode);
            request.AddParameter("client_id", clientKey);

            //Get the access key
            IRestResponse<AuthModel> resp = client.Execute<AuthModel>(request);
            var content = resp.Data.access_token;
            string accessKey = resp.Data.access_token;
            string orgKey = resp.Data.organizer_key;

            //Assign public facing object to returned object's data.
            Access = resp.Data;

            //Return object to caller
            return Access;
        }
    }
}