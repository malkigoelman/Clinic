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
        public ActionResult<IEnumerable<ClientDTO>> Get()
        {
            var list=_clientService.GetClients();
            var listDTO = list.Select(c => _mapper.Map<ClientDTO>(c));
            return Ok(listDTO);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> Get(int id)
        {
            var c = _clientService.GetClientById(id);
            if (c == null)
                NotFound();
            var cDTO= _mapper.Map<ClientDTO>(c);
            return Ok(cDTO);
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] ClientPostModel client)
        {
            var c=_mapper.Map<Client>(client);
            _clientService.AddClient(c);

        }
        [HttpPost("{id}/comments")]
        public ActionResult AddComment(int id, [FromBody] CommentPostModel comment)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                NotFound();
            _clientService.AddComments(id, _mapper.Map<Comment>(comment));
            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClientPostModel client)
        {
            var client1 = _clientService.GetClientById(id);
            if (client1 == null)
                NotFound();
            _mapper.Map(client, client1);
            _clientService.UpdateClient(id, client1);
            return Ok(_mapper.Map<ClientDTO>(client1));
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Client client1 = _clientService.GetClientById(id);
            if (client1 == null)
                NotFound();
            _clientService.DeleteClient(id);
            return Ok();
        }
        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetComments(int id)
        {
            Client client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();
            return Ok(_clientService.GetComments(id));
        }
    }
}
