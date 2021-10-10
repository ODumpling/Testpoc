﻿namespace API.Models
{
    public class OsUptime
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public double TotalDays { get; set; }
        public double TotalHours { get; set; }
        public double TotalMilliseconds { get; set; }
        public double TotalMinutes { get; set; }
        public double TotalSeconds { get; set; }
    }
}