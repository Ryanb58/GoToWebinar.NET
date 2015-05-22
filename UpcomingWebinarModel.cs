using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class UpcomingWebinar
    {
        public List<Time> times { get; set; }
        public string description { get; set; }
        public string subject { get; set; }
        public bool inSession { get; set; }
        public long organizerKey { get; set; }
        public object webinarKey { get; set; }
        public string timeZone { get; set; }
        public string registrationUrl { get; set; }
    }
    public class Time
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}