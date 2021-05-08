using System;
namespace CoreJwt.Models
{
    public class CalanderLog
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string CategoryColor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}