using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Service.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
