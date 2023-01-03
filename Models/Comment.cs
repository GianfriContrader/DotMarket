using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DotMarket.Models
{

    public class Comment
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsLike { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Product Product { get; set; }

    }
}
