using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;

namespace SDP_API_TEST
{
    public partial class Form1 : Form
    {
        public string? api_Key;
        public string? url;

        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            // Initialize the ProgressBar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 20;
        }

        private async void sendRequest_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Processing the request";
            progressBar1.Value = 0;

            try
            {
                // Prompt the user for their details
                string firstName = Microsoft.VisualBasic.Interaction.InputBox("Enter First Name:", "User Details", "George");
                string middleName = Microsoft.VisualBasic.Interaction.InputBox("Enter Middle Name:", "User Details", "Georgie");
                string lastName = Microsoft.VisualBasic.Interaction.InputBox("Enter Last Name:", "User Details", "Georgia");
                string email = Microsoft.VisualBasic.Interaction.InputBox("Enter Email:", "User Details", "email@email.com");
                string phone = Microsoft.VisualBasic.Interaction.InputBox("Enter Phone Number:", "User Details", "1234567890");
                string loginName = Microsoft.VisualBasic.Interaction.InputBox("Enter Login Name:", "User Details", "user323");

                progressBar1.PerformStep(); // Step 1: User input collected

                var jsonContent = $@"{{
                                    ""user"": {{
                                        ""first_name"": ""{firstName}"",
                                        ""middle_name"": ""{middleName}"",
                                        ""last_name"": ""{lastName}"",
                                        ""name"": ""{firstName} {middleName} {lastName}"",
                                        ""is_vipuser"": ""false"",
                                        ""employee_id"": ""9685"",
                                        ""mobile"": ""02895902"",
                                        ""description"": ""Help Desk manager"",
                                        ""sms_mail_id"": ""vaska.k@mail.com"",
                                        ""jobtitle"": ""Taxi Driver"",
                                        ""phone"": ""{phone}"",
                                        ""email_id"": ""{email}"",
                                        ""cost_per_hour"": ""929"",
                                        ""service_request_approver"": ""true"",
                                        ""reporting_to"": {{
                                            ""id"": ""4""
                                        }},
                                        ""requester_allowed_to_view"": ""0"",
                                        ""login_name"": ""{loginName}"",
                                        ""password"": ""1qaz!QAZ""
                                    }}
                                }}";

                var formData = new StringContent($"input_data={jsonContent}", Encoding.UTF8, "application/x-www-form-urlencoded");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sd.sntx.ae/api/v3/users"),
                    Content = formData
                };
                request.Headers.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                progressBar1.PerformStep(); // Step 2: Request prepared

                // Log the request content for debugging
                Console.WriteLine("Request Content: " + formData);

                var response = await client.SendAsync(request);

                progressBar1.PerformStep(); // Step 3: Request sent

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                progressBar1.PerformStep(); // Step 4: Response received

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = responseBody;

                progressBar1.PerformStep(); // Step 5: Response processed
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar1.Value = 0; // Reset progress bar
            }
        }

        private async void modifyUser_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            richTextBox1.Text = "Processing the request";

            try
            {
                string email = Microsoft.VisualBasic.Interaction.InputBox("Which User you want to remove?\nEnter email address:", "User Details", "email@email.com");

                progressBar1.PerformStep(); // Step 1: User input collected

                var jsonContent = $@"{{
                            ""list_info"": {{
                                ""sort_field"": ""name"",
                                ""start_index"": 1,
                                ""sort_order"": ""asc"",
                                ""row_count"": 25,
                                ""get_total_count"": true,
                                ""search_fields"": {{
                                    ""email_id"": ""{email}""
                                }}
                            }}
                        }}";

                var requestUri = new Uri("https://sd.sntx.ae/api/v3/users?input_data=" + Uri.EscapeDataString(jsonContent));

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = requestUri
                };
                request.Headers.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                progressBar1.PerformStep(); // Step 2: Request prepared

                // Log the request URI for debugging
                Console.WriteLine("Request URI: " + requestUri);

                var response = await client.SendAsync(request);

                progressBar1.PerformStep(); // Step 3: Request sent

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                progressBar1.PerformStep(); // Step 4: Response received

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = responseBody;

                // Parse the JSON response to extract the "id"
                string userID = ExtractUserIdFromResponse(responseBody, email);

                if (string.IsNullOrEmpty(userID))
                {
                    MessageBox.Show("No user found with the provided email.");
                    return;
                }

                progressBar1.PerformStep(); // Step 5: User ID extracted

                // Send the second request to remove the user
                await RemoveUserById(userID);

                progressBar1.PerformStep(); // Step 6: User removed
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar1.Value = 0; // Reset progress bar
            }
        }

        private string ExtractUserIdFromResponse(string responseBody, string email)
        {
            using (JsonDocument doc = JsonDocument.Parse(responseBody))
            {
                JsonElement root = doc.RootElement;
                JsonElement users = root.GetProperty("users");

                foreach (JsonElement user in users.EnumerateArray())
                {
                    if (user.GetProperty("email_id").GetString() == email)
                    {
                        return user.GetProperty("id").GetString();
                    }
                }
            }
            return null;
        }

        private async Task RemoveUserById(string userID)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://sd.sntx.ae/api/v3/users/" + userID)
            };
            request.Headers.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

            var response = await client.SendAsync(request);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            string responseBody = await response.Content.ReadAsStringAsync();
            richTextBox1.Text = responseBody;
        }

        private async void AddRequestBtn_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            richTextBox1.Text = "Processing the request";

            try
            {
                progressBar1.PerformStep(); // Step 1: Request started

                await Request.AddRequest();

                progressBar1.PerformStep(); // Step 2: Request completed
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar1.Value = 0; // Reset progress bar
            }
        }


    }
}
