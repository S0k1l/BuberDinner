using BuberDinner.Application.Common.Interfaces.Services;

namespace DuberDinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
