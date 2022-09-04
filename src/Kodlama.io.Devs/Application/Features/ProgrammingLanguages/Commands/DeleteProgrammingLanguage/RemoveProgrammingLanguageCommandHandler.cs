using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommandHandle : IRequestHandler<RemoveProgrammingLanguageCommandRequest, RemovedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public RemoveProgrammingLanguageCommandHandle(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<RemovedProgrammingLanguageDto> Handle(RemoveProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

            await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
            RemovedProgrammingLanguageDto removedProgrammingLanguageDto = _mapper.Map<RemovedProgrammingLanguageDto>(programmingLanguage);

            return removedProgrammingLanguageDto;
        }
    }
}
