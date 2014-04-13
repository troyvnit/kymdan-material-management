using System.Collections.Generic;
using KMM.Data.Infrastructure;
using KMM.Data.Repository;
using KMM.Model.Models;

namespace KMM.Data.Service
{
    public interface IMaterialProposalService
    {
        MaterialProposal GetMaterialProposal(int id);
        IEnumerable<MaterialProposal> GetMaterialProposals();
        bool AddOrUpdateMaterialProposal(MaterialProposal materialProposal);
        bool DeleteMaterialProposal(MaterialProposal materialProposal);
    }
    public class MaterialProposalService : IMaterialProposalService
    {
        private readonly IMaterialProposalRepository _materialProposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialProposalService(IMaterialProposalRepository materialProposalRepository, IUnitOfWork unitOfWork)
        {
            this._materialProposalRepository = materialProposalRepository;
            this._unitOfWork = unitOfWork;
        }

        public MaterialProposal GetMaterialProposal(int id)
        {
            return _materialProposalRepository.GetById(id);
        }
        public IEnumerable<MaterialProposal> GetMaterialProposals()
        {
            var materialProposals = _materialProposalRepository.GetAll();
            return materialProposals;
        }

        public bool AddOrUpdateMaterialProposal(MaterialProposal materialProposal)
        {
            if (materialProposal.Id != 0)
            {
                _materialProposalRepository.Update(materialProposal);
                _unitOfWork.Commit();
            }
            else
            {
                _materialProposalRepository.Add(materialProposal);
                _unitOfWork.Commit();
            }
            return true;
        }

        public bool DeleteMaterialProposal(MaterialProposal materialProposal)
        {
            _materialProposalRepository.Delete(materialProposal);
            _unitOfWork.Commit();
            return true;
        }
    }
}
