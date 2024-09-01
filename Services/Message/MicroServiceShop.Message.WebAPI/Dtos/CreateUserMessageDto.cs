﻿namespace MicroServiceShop.Message.WebAPI.Dtos
{
    public class CreateUserMessageDto
    {
        public string? SenderId { get; set; }
        public string? RecieverId { get; set; }
        public string? Subject { get; set; }
        public string? MessageContent { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
