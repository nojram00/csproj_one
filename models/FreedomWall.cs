using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace csproj_one.Models
{
    [Table("freedom-wall")]
    public class FreedomWall : BaseModel
    {
        [PrimaryKey("id", false)]
        public string? Id { get; }

        [Column("username")]
        public string? Sender { get; set; } = "Anonymous";

        [Column("password")]
        public string? Content { get; set; }
    }
}