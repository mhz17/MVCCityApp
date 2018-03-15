using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Dashboarding.Extensions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace Dashboarding
{
    public class JiraCalls
  {

        private string _jiraAPI;
        public JiraCalls(string jiraAPI)
        {
            _jiraAPI = jiraAPI;
        }

        public List<Models.Items> GetItems()
        {
  
            var result = new List<Models.Items>();

            using (var client = new HttpClient())
            {

                var requestURI = _jiraAPI + "/search?jql=resolution=Unresolved & project = INT";

                Console.WriteLine($"Calling Jira API : {requestURI}");

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(requestURI),
                    Method = HttpMethod.Get,
                    Headers = {
                        { HttpRequestHeader.Authorization.ToString(), "Basic " },
                        { HttpRequestHeader.ContentType.ToString(), "application/json" }
                    }
                };

                var task = client.SendAsync(request)
                   .ContinueWith((taskwithresponse) =>
                   {

                       try
                       {
                           
                           var response = taskwithresponse.Result.Content.ReadAsStringAsync();
                           response.Wait();
                           // List<Models.Items> jiraData = JsonConvert.DeserializeObject<List<Models.Items>>(response.Result);
                           // result = jiraData;
                           Console.WriteLine($"Results : {response.Result}");
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine($"Error occurred: {ex}");
                           throw;
                       }

                   });

                task.Wait();

            }

            return result;
        }
    }
}
