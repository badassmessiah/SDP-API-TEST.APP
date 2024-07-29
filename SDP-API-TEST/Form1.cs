using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

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
        }

        private async void sendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var jsonContent = @"{
                        ""user"": {
                            ""first_name"": ""kagawa"",
                            ""middle_name"": ""Rat"",
                            ""last_name"": ""At"",
                            ""name"": ""KAG KAGAWA Am"",
                            ""is_vipuser"": ""false"",
                            ""employee_id"": ""4823""
                        }
                    }";

                var formData = new StringContent($"input_data={jsonContent}", Encoding.UTF8, "application/x-www-form-urlencoded");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sd.sntx.ae/api/v3/users"),
                    Content = formData
                };
                request.Headers.Add("authtoken", "318BDA54-2DE3-4958-8CE7-2EDBBC79296E");

                // Log the request content for debugging
                Console.WriteLine("Request Content: " + formData);

                var response = await client.SendAsync(request);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = responseBody;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
