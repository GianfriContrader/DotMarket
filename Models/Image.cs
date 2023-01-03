using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotMarket.Models
{
    public class Image
    {
        public long Id { get; set; }

        public string  PathImage { get; set; } = string.Empty;

        public string Data { get; set; } = string.Empty;

        public virtual Product Product { get; set; }

    }
}