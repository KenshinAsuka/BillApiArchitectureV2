using BillApiArchitecture.Data;
using BillApiArchitecture.DTO.Owner;

namespace BillApiArchitecture.Repository
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner Get(Guid id);

        Guid Insert(CreateOwnerModel owner);

        void Update(UpdateOwnerModel owner);

        void Delete(Guid id);

        void Save();
    }
}
