using csproj_one.Models;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace csproj_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreedomWallController : ControllerBase
    {
        private readonly Client _client;

        public FreedomWallController(Client client)
        {
            _client = client;
        }


        [HttpGet("list", Name ="Walls")]
        public async Task<ActionResult<List<FreedomWall>>> Get()
        {
            var results = await _client.From<FreedomWall>()
                            .Get();

            return Ok(results);
        }


        public struct AddFreedomWallDTO
        {
            public string Sender { get; set; }
            public string Content { get; set; }
        }

        [HttpPost("add-wall", Name ="AddWall")]
        public async Task<ActionResult<FreedomWall>> Add(AddFreedomWallDTO data)
        {
            FreedomWall new_wall = new FreedomWall{
                Sender = data.Sender,
                Content = data.Content
            } ;
            var result = await _client.From<FreedomWall>()
                            .Insert(new_wall);

            return Ok(result);
        }

        [HttpGet("post/{id}", Name ="Wall")]
        public async Task<ActionResult<FreedomWall>> Find(string id)
        {
            var result = await _client.From<FreedomWall>()
                            .Where(wall => wall.Id == id)
                            .Get();

            return Ok(result);
        }
        
    }
}
