using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WebTruyen.Models
{
    public class ChatGPT
    {
        private string gptApiKey;

        public ChatGPT(string gptApiKey)
        {
            this.gptApiKey = gptApiKey;
        }

        public class GPTService
        {
            private readonly string _apiKey;
            private readonly string _gptApiUrl = "https://api.openai.com/v1/";  // Thay thế bằng endpoint của GPT

          
            public string GetGPTAnswer(string question)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                    // Thực hiện yêu cầu đến API GPT
                    var apiUrl = $"{_gptApiUrl}/completion"; // Thay thế bằng endpoint cụ thể của GPT
                    var requestBody = JsonConvert.SerializeObject(new { prompt = question, max_tokens = 50 });
                    var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(apiUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        var responseObject = JsonConvert.DeserializeObject<GPTResponse>(responseData);
                        return responseObject.choices[0].text.Trim();
                    }
                    else
                    {
                        // Xử lý lỗi
                        return "Xin lỗi, không thể nhận câu trả lời từ GPT.";
                    }
                }
            }
        }

        internal string GetGPTAnswer(string userQuestion)
        {
            throw new NotImplementedException();
        }

        public class GPTResponse
        {
            public List<Choice> choices { get; set; }

            public class Choice
            {
                public string text { get; set; }
            }
        }

    }
}