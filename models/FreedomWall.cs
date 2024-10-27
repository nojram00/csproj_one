using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace csproj_one.Models
{
    [Table("freedom-wall")]
    public class FreedomWall : BaseModel
    {
        [PrimaryKey("id", false)]
        public string? Id { get; set; }

        [Column("sender")]
        public string? Sender { get; set; } = "Anonymous";

        [Column("content")]
        public string? Content { get; set; }
    }
}