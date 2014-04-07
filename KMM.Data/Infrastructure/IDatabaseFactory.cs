using System;

namespace KMM.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        KMMEntities Get();
    }
}
