using ContactManager.Application.Commands.CreateContact;
using ContactManager.Application.Commands.RemoveContact;
using ContactManager.Application.Commands.UpdateContact;
using ContactManager.Application.Commands.GetAllContacts;
using ContactManager.Application.Commands.GetContactById;
using ContactManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using ContactManager.WebApi.DTOs;

namespace ContactManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto createContactDto)
        {
            var command = new CreateContactCommand
            {
                Name = createContactDto.Name,
                Phone = createContactDto.Phone,
                Birthday = createContactDto.Birthday,
                Salary = createContactDto.Salary,
                IsMarried = createContactDto.IsMarried
            };

            var result = await _mediator.Send(command);
            return result.IsSuccess 
                ? Ok() 
                : BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactDto updateContactDto)
        {
            var command = new UpdateContactCommand
            {
                Id = updateContactDto.Id,
                Name = updateContactDto.Name,
                Phone = updateContactDto.Phone,
                Birthday = updateContactDto.Birthday,
                Salary = updateContactDto.Salary,
                IsMarried = updateContactDto.IsMarried
            };

            var result = await _mediator.Send(command);
            return result.IsSuccess 
                ? NoContent() 
                : BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var command = new RemoveContactCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command);
            return result.IsSuccess 
                ? NoContent() 
                : NotFound(result.Error);
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonViewModel>>> GetAllContacts()
        {
            var query = new GetAllContactsQuery();
            var result = await _mediator.Send(query);
            return result.IsSuccess 
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> GetContactById(long id)
        {
            var query = new GetContactByIdQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            return result.IsSuccess 
                ? Ok(result.Value) 
                : NotFound(result.Error);
        }

        [HttpPost("upload-csv")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File wasn`t provided.");
            }

            try
            {
                using var stream = new StreamReader(file.OpenReadStream());
                using var csvReader = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                });
                var records = csvReader.GetRecords<CreateContactCommand>().ToList();

                foreach (var record in records)
                {
                    var result = await _mediator.Send(record);
                    if (result.IsFailure)
                    {
                        return BadRequest(result.Error);
                    }
                }

                return Ok("Contacts successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error parsing CSV file: {ex.Message}");
            }
        }
    }
}
