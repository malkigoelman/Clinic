using AutoMapper;
using Clinic.API.Model;
using Clinic.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirpaha.Controllers
{
    [Route("clinic/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService,IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var list=await _clientService.GetClientsAsync();
            var listDTO = list.Select(c => _mapper.Map<ClientDTO>(c));
            return Ok(listDTO);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            var c =await _clientService.GetClientByIdAsync(id);
            if (c == null)
                NotFound();
            var cDTO= _mapper.Map<ClientDTO>(c);
            return Ok(cDTO);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task Post([FromBody] ClientPostModel client)
        {
            var c=_mapper.Map<Client>(client);
          await  _clientService.AddClientAsync(c);

        }
        [HttpPost("{id}/comments")]
        public async Task<ActionResult> AddComment(int id, [FromBody] CommentPostModel comment)
        {
            var client =await _clientService.GetClientByIdAsync(id);
            if (client == null)
                NotFound();
           await _clientService.AddCommentsAsync(id, _mapper.Map<Comment>(comment));
            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientPostModel client)
        {
            var client1 =await _clientService.GetClientByIdAsync(id);
            if (client1 == null)
                NotFound();
            _mapper.Map(client, client1);
           await _clientService.UpdateClientAsync(id, client1);
            return Ok(_mapper.Map<ClientDTO>(client1));
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Client client1 =await _clientService.GetClientByIdAsync(id);
            if (client1 == null)
                NotFound();
             await _clientService.DeleteClientAsync(id);
            return Ok();
        }
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            Client client =await _clientService.GetClientByIdAsync(id);
            if (client == null)
                return NotFound();
            return  Ok(await _clientService.GetCommentsAsync(id));
        }
    }
}
