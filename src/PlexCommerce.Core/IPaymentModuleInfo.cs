using System;

namespace PlexCommerce
{
    public interface IPaymentModuleInfo
    {
        string Name { get; }

        Type ModuleType { get; }
    }
}