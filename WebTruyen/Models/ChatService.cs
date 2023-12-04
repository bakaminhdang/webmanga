using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTruyen.Models
{
    public class ChatService
    {
        private readonly dataDataContext data;
        private readonly ChatGPT _gptService;

        public ChatService(string gptApiKey)
        {
            data = new dataDataContext();
            _gptService = new ChatGPT(gptApiKey);
        }

        public List<ChatData> GetChatMessages()
        {
            return data.ChatDatas.ToList();
        }

        public string GetGPTAnswer(string userQuestion)
        {
            string gptAnswer = _gptService.GetGPTAnswer(userQuestion);

            // Lưu câu hỏi và câu trả lời vào cơ sở dữ liệu
            data.ChatDatas.Attach(new ChatData { Question = userQuestion, Answer = gptAnswer });
            data.SubmitChanges();

            return gptAnswer;
        }
    }
}