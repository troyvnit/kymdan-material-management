using System.Collections.Generic;
using KMM.Data.Infrastructure;
using KMM.Data.Repository;
using KMM.Model.Models;

namespace KMM.Data.Service
{
    public interface IMaterialRequestService
    {
        MaterialRequest GetMaterialRequest(int id);
        IEnumerable<MaterialRequest> GetMaterialRequests();
        bool AddOrUpdateMaterialRequest(MaterialRequest materialRequest);
        bool DeleteMaterialRequest(MaterialRequest materialRequest);
    }
    public class MaterialRequestService : IMaterialRequestService
    {
        private readonly IMaterialRequestRepository _materialRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialRequestService(IMaterialRequestRepository materialRequestRepository, IUnitOfWork unitOfWork)
        {
            this._materialRequestRepository = materialRequestRepository;
            this._unitOfWork = unitOfWork;
        }

        public MaterialRequest GetMaterialRequest(int id)
        {
            return _materialRequestRepository.GetById(id);
        }
        public IEnumerable<MaterialRequest> GetMaterialRequests()
        {
            var materialRequests = _materialRequestRepository.GetAll();
            return materialRequests;
        }

        public bool AddOrUpdateMaterialRequest(MaterialRequest materialRequest)
        {
            if (materialRequest.Id != 0)
            {
                _materialRequestRepository.Update(materialRequest);
                _unitOfWork.Commit();
            }
            else
            {
                _materialRequestRepository.Add(materialRequest);
                _unitOfWork.Commit();
            }
            return true;
        }

        public bool DeleteMaterialRequest(MaterialRequest materialRequest)
        {
            _materialRequestRepository.Delete(materialRequest);
            _unitOfWork.Commit();
            return true;
        }
    }
}
