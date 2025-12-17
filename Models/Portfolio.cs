using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Api.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int StockId { get; set; }

        [Required]
        public int TotalQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AveragePrice { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
