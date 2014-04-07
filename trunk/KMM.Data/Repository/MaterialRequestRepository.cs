using KMM.Data.Infrastructure;
using KMM.Model.Models;

namespace KMM.Data.Repository
{
    public class MaterialRequestRepository : RepositoryBase<MaterialRequest>, IMaterialRequestRepository
    {
        public MaterialRequestRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IMaterialRequestRepository : IRepository<MaterialRequest>
    {
    }
}
