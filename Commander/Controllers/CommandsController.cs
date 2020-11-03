using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: Controller
    {
        private readonly ICommanderRepo _repo ;
        private readonly IMapper _mapper;

        public CommandsController( ICommanderRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}",Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commantItem = _repo.GetCommandById(id);
            if(commantItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commantItem));
            }

            return NotFound();
            
        }

        //post api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var cmdModel = _mapper.Map<Command>(commandCreateDto);
            _repo.Create(cmdModel);
            _repo.Savechanges();

            var cmdCreateDto = _mapper.Map<CommandReadDto>(cmdModel);
            return CreatedAtRoute(nameof(GetCommandById), new { id = cmdModel.Id }, cmdCreateDto);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommanderUpdateDto commanderUpdateDto)
        {
          var cmd = _repo.GetCommandById(id);
            if (cmd == null)
            {
                return NotFound();
            }

            _mapper.Map(commanderUpdateDto, cmd);

            _repo.Savechanges();
            return NoContent();
        }

    }
}
