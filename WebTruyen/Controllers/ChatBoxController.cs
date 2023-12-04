using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    public class ChatBoxController : Controller
    {
        // GET: ChatBox
        private readonly ChatService _chatService;

        public ChatBoxController(string gptApiKey)
        {
            _chatService = new ChatService(gptApiKey);
        }

        public ActionResult Index()
        {
            var chatMessages = _chatService.GetChatMessages();
            return View(chatMessages);
        }

        [HttpPost]
        public ActionResult GetGPTAnswer(string userQuestion)
        {
            var gptAnswer = _chatService.GetGPTAnswer(userQuestion);
            return Json(new { answer = gptAnswer });
        }
    }
}