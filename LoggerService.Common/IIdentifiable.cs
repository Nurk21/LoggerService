using System;

namespace LoggerService.Common
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
