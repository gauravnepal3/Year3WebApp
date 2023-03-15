using System;
using CleanArchitecture.Application.Common.Interface;

namespace CleanArchitecture.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}

