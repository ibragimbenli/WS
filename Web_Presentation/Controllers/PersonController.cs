using App_Service_Layer.DTOs;
using App_Service_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.Entities;

namespace Web_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllPersonsAsync();
            return Ok(persons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) { return NotFound(); }
            return Ok(person);
        }
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] Person person)
        //{
        //    await _personService.AddPersonAsync(person);
        //    return Ok();
        //}
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Person person)
        {
            await _personService.AddPersonAsync(person);
            return Ok("Kayıt başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            await _personService.UpdatePersonAsync(person);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.DeletePersonAsync(id);
            return Ok();
        }
    }
}
