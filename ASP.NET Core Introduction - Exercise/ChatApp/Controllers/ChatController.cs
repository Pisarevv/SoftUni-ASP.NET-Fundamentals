﻿using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;
public class ChatController : Controller
{
    private static readonly ICollection<KeyValuePair<string, string>> _messages = 
        new List<KeyValuePair<string, string>>();

    public IActionResult Show()
    {
        if(_messages.Count < 1)
        {
            return View(new ChatViewModel());
        }
        var chatModel = new ChatViewModel()
        {
            Messages = _messages.
                       Select(m => new MessageViewModel()
                       {
                           Sender = m.Key,
                           Text = m.Value,
                       })
                       .ToList()
        };
        return View(chatModel);
        }

    [HttpPost]
    public IActionResult Send(ChatViewModel chat)
    {
        var newMessage = chat.CurrentMessage;
      

        var currentMessage = new KeyValuePair<string,string>(newMessage.Sender, newMessage.Text);
        _messages.Add(currentMessage);

        return RedirectToAction("Show");
    }
}
