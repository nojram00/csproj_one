using csproj_one.Models;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace csproj_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Client _client;

        public UserController (Client client){
            _client = client;
        }

        // GET: UserController
        [HttpGet(Name="GetUsers")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _client.From<User>().Get();

            return Ok(users.Models);
        }


        public struct UserDto {
            public string? Username {get; set;}
            public string? Password {get; set;}
        }

        [HttpPost(Name="AddUser")]
        public async Task<ActionResult<User>> AddUser(UserDto user){

            var data = new User {
                Username = user.Username,
                Password = user.Password  
            };
            var result = await _client.From<User>().Insert(data);

            return Ok(result.Model);
        }

        public struct ApiResponse {
            public string Message {get; set;}
        }

        [HttpDelete("{uid}",Name="DeleteUser")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int uid){
            await _client.From<User>()
                        .Where(user => user.Uid == uid)
                        .Delete();

            return Ok(new {
                Message = "Delete Success!"
            });
        }


        [HttpPatch("{uid}", Name="UpdateUser")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int uid, UserDto _user){

            User new_data = new()
            {
                Username = _user.Username,
                Password = _user.Password,
            };

            await _client.From<User>()
                    .Where(user => user.Uid == uid)
                    .Set(user => user, new_data)
                    .Update();

            return Ok(new {
                Message = "User Updated!"
            });
        }

    }
}
