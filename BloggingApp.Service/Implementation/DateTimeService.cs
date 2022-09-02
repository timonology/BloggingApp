using BloggingApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
