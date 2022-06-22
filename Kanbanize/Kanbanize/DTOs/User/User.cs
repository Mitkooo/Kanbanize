using System;

namespace Kanbanize.DTOs.User
{
    public class User
    {
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public string? RealName { get; set; }
        public string? CompanyName { get; set; }
        public string? apiKey { get; set; }
    }
}
