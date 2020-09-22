using System;
using Orders.Application.Utils;

namespace Orders.Infrastructure.Utils
{
    public class UidGenerator : IUidGenerator
    {
        public string GetUid()
            => Guid.NewGuid().ToString();
    }
}