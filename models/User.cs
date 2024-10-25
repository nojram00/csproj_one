using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace csproj_one.Models
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey("uid", false)]
        public int Uid { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("password")]
        public string? Password { get; set; }
    }
}