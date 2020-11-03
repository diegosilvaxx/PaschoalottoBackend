using AutoMapper;
using DevIO.Api.Controllers.Common;
using DevIO.Api.DTO;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PesquisaDebitoController : MainController
    {
        private readonly IPesquisaDebitoRepository _pesquisaDebitoRepository;
        private readonly IPesquisaDebitoService _pesquisaDebitoService;
        private readonly IMapper _mapper;

        public PesquisaDebitoController(INotificador notificador,
                                    IMapper mapper,
                                    IPesquisaDebitoRepository pesquisaDebitoRepository,
                                    IPesquisaDebitoService pesquisaDebitoService,
                                    IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _pesquisaDebitoRepository = pesquisaDebitoRepository;
            _pesquisaDebitoService = pesquisaDebitoService;
        }

        [HttpGet("{userId:guid}")]
        public async Task<PesquisaDebitoDto> ObterDebito(Guid userId)
        {
            var pesquisaDebito = await _pesquisaDebitoRepository.ObterDebito(userId);
            

            var result = await _pesquisaDebitoService.CalcularDebito(pesquisaDebito);
            var pesquisaDebitoDto = _mapper.Map<PesquisaDebitoDto>(result);

            return pesquisaDebitoDto;
        }
    }
}