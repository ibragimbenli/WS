using App_Service_Layer.DTOs;
using App_Service_Layer.Services.Interfaces;
using AutoMapper;
using Common_Types_Layer.Interfaces.Dapper;
using Model_Layer.Entities;
namespace Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;
        public PersonService(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        //{
        //    return await _repository.GetAllAsync();
        //}
        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            var persons = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }
        //public async Task<Person?> GetPersonByIdAsync(int id)
        //{
        //    return await _repository.GetByIdAsync(id);
        //}
        public async Task<PersonDto?> GetPersonByIdAsync(int id)
        {
            var person = await _repository.GetByIdAsync(id);
            return _mapper.Map<PersonDto?>(person);
        }


        public async Task AddPersonAsync(Person person)
        {
            await _repository.AddAsync(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _repository.UpdateAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
