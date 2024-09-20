using AutoMapper;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.UnitOfWorks;
using EmircanBlog_Entity.Dtos;
using EmircanBlog_Entity.Entities;
using EmircanBlog_Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Concrete
{
    public class ContactService : IContactService
    {

        private readonly IContactDal _contactDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IMapper mapper , IContactDal contactDal , IUnitOfWork unitOfWork)
        {
            _contactDal = contactDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsyncService(ContactDto Entity)
        {
           var contact = _mapper.Map<Contact>(Entity);
            await _contactDal.AddAsync(contact);
            await _unitOfWork.SaveAsync();
        }

        public Task<bool> AnyAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactDto>> GetAllAsyncService()
        {
            var contacts = await _contactDal.GetAllAsync();
            var contactsDto = _mapper.Map<List<ContactDto>>(contacts);
            return contactsDto;


        }

        public Task<ContactDto> GetAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> GetByGuidAsyncService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> UpdateAsyncService(ContactDto Entity)
        {
            throw new NotImplementedException();
        }
    }
}