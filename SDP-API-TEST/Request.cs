using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SDP_API_TEST
{
    public static class Request
    {
        public static async Task<bool> AddRequest()
        {
            // Prompt the user for their details
            string email = Microsoft.VisualBasic.Interaction.InputBox("Enter Requester Email:", "User Details", "email@email.com");
            string subject = Microsoft.VisualBasic.Interaction.InputBox("Enter Request Subject:", "User Details", "");
            string description = Microsoft.VisualBasic.Interaction.InputBox("Enter Request Description:", "User Details", "");

            var jsonContent = $@"{{
                    ""request"": {{
                        ""subject"": ""{subject}"",
                        ""description"": ""{description}"",
                        ""requester"": {{
                            ""email_id"": ""{email}""
                        }},
                        ""impact_details"": ""Routine tasks are pending due to mail server problem"",
                        ""resolution"": {{
                            ""content"": ""Mail Fetching Server problem has been fixed""
                        }},
                        ""status"": {{
                            ""name"": ""Open""
                        }}
                    }}
                }}";

            var requestUri = new Uri("https://sd.sntx.ae/api/v3/requests");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Request successful: " + responseBody);

                    return true;
                }
                else
                {
                    Console.WriteLine("Request failed: " + response.StatusCode);
                    return false;
                }
            }

        }
    }
}
