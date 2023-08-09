using BillApiArchitecture.Data;
using BillApiArchitecture.DTO.Owner;
using BillApiArchitecture.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var owners = _ownerRepository.GetAll();
            return new OkObjectResult(owners);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var owner = _ownerRepository.Get(id);
            return new OkObjectResult(owner);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOwnerModel owner)
        {
            using (var scope = new TransactionScope())
            {
                var ownerId = _ownerRepository.Insert(owner);
                scope.Complete();
                Owner newOwner = new Owner();
                newOwner.Id = ownerId;
                newOwner.Name = owner.Name;
                return CreatedAtAction(nameof(Get), new { id = ownerId }, newOwner);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateOwnerModel owner)
        {
            if (owner != null)
            {
                using (var scope = new TransactionScope())
                {
                    _ownerRepository.Update(owner);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _ownerRepository.Delete(id);
            return new OkResult();
        }
    }
}