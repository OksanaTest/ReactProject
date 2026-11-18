using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Region
    {
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; } = string.Empty;

            [MaxLength(100)]
            public string regionCapital { get; set; } = string.Empty;
        }

    }
