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
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return Ok(_clientService.GetClients());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            Client c = _clientService.GetClientById(id);
            if (c == null)
                NotFound();
            return Ok(c);
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] Client client)
        {
            _clientService.AddClient(client);
        }
        [HttpPost("{id}/comments")]
        public ActionResult AddComment(int id, [FromBody] Comment comment)
        {
            Client client = _clientService.GetClientById(id);
            if (client == null)
                NotFound();
            _clientService.AddComments(id, comment);
            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Client client)
        {
            Client client1 = _clientService.GetClientById(id);
            if (client1 == null)
                NotFound();
            _clientService.UpdateClient(id, client);
            return Ok();
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
