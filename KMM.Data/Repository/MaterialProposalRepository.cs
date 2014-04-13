using KMM.Data.Infrastructure;
using KMM.Model.Models;

namespace KMM.Data.Repository
{
    public class MaterialProposalRepository : RepositoryBase<MaterialProposal>, IMaterialProposalRepository
    {
        public MaterialProposalRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IMaterialProposalRepository : IRepository<MaterialProposal>
    {
    }
}
