using BillApiArchitecture.Data;
using BillApiArchitecture.DTO.Owner;
using Microsoft.EntityFrameworkCore;


namespace BillApiArchitecture.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MainContext _mainContext;
        public OwnerRepository(MainContext mainContext) { 
            _mainContext = mainContext;
        }

        public void Delete(Guid id)
        {
            var owners = _mainContext.Owners?.Find(id);

            if(owners != null)
            {
                _mainContext.Owners?.Remove(owners);
                Save();
            }            
        }

        public Owner Get(Guid id)
        {
            var owner = _mainContext.Owners?.Find(id);

            if (owner != null)
                return owner;
            else
                return new Owner();
        }

        public IEnumerable<Owner> GetAll()
        {
            var list = _mainContext.Owners?.ToList();

            if (list != null)
                return list;
            else
                return new List<Owner>();
        }

        public Guid Insert(CreateOwnerModel owner)
        {
            var newOwner = new Owner();

            newOwner.Id = Guid.NewGuid();
            newOwner.Name = owner.Name;

            _mainContext.Owners?.Add(newOwner);
            Save();

            return newOwner.Id;
        }

        public void Update(UpdateOwnerModel owner)
        {
            Owner updatedOwner = new Owner();
            updatedOwner.Id = owner.Id; 
            updatedOwner.Name = owner.Name;

            _mainContext.Entry(updatedOwner).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _mainContext.SaveChanges();
        }
    }
}
