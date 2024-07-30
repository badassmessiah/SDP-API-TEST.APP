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
        public static async Task<string> AddRequest()
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
                            ""resolution"": {{
                                ""content"": """"
                            }},
                            ""status"": {{
                                ""name"": ""Open""
                            }}
                        }}
                    }}";

            var formData = new StringContent($"input_data={jsonContent}", Encoding.UTF8, "application/x-www-form-urlencoded");

            var requestUri = new Uri("https://sd.sntx.ae/api/v3/requests");

            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                    var response = await client.PostAsync(requestUri, formData);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Request successful: " + responseBody);

                        return "Success!";
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Request failed: " + response.StatusCode + " - " + responseBody);
                        return "Failed! " + response.StatusCode + " - " + responseBody;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public static async Task<string> UpdateRequestById()
        {
            string requestId = Microsoft.VisualBasic.Interaction.InputBox("Enter RequestID:", "User Details", "");
            string closureComments = Microsoft.VisualBasic.Interaction.InputBox("Enter Closure Comments:", "User Details", "");
            var jsonContent = $@"{{
                        ""request"": {{
                            ""closure_info"": {{
                                ""requester_ack_resolution"": true,
                                ""requester_ack_comments"": """",
                                ""closure_comments"": ""{closureComments}"",
                                ""closure_code"": {{
                                    ""name"": ""success""
                                }}
                            }}
                        }}
             }}";

            try
            {
                var formData = new StringContent($"input_data={jsonContent}", Encoding.UTF8, "application/x-www-form-urlencoded");

                var requestUri = new Uri($@"https://sd.sntx.ae/api/v3/requests/{requestId}/close");

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                    var response = await client.PutAsync(requestUri, formData);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Request successful: " + responseBody);

                        return "Success!";
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Request failed: " + response.StatusCode + " - " + responseBody);
                        return "Failed! " + response.StatusCode + " - " + responseBody;
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        

    }
}
