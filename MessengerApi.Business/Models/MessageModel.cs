using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MessengerApi.Business.Models
{
    public class MessageModel : ModelBase
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public UserModel User { get; set; }
        public IFormFile Image { get; set; }
    }
}