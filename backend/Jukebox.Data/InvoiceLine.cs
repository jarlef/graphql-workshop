using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Jukebox.Data;

[DebuggerDisplay("InvoiceLineId = {InvoiceLineId}")]
public class InvoiceLine
{
    [Key]
    public int InvoiceLineId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int TrackId { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    [ForeignKey("InvoiceId")]
    public Invoice Invoice { get; set; }
}
