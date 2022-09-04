using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommandRequest createProgrammingLanguageRequest)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageRequest);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQueryRequest getListBrandQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommandRequest updateProgrammingLanguageRequest)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageRequest);
            return Ok( result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQueryRequest getByIdProgrammingLanguageQueryRequest )
        {
            ProgrammingLanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQueryRequest);
            return Ok(languageGetByIdDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] RemoveProgrammingLanguageCommandRequest removeProgrammingLanguageCommandRequest )
        {
            RemovedProgrammingLanguageDto result = await Mediator.Send(removeProgrammingLanguageCommandRequest);

            return Created("", result);
        }
    }
}
