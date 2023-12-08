#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WifleTools.Data;

public class Invoice : Entity
{
	[Required]
	[MaxLength(100)]
	public string For { get; set; } = default!;
	public int Amount { get; set; }
	public Guid RecipientId { get; set; }
	public Guid ClientId { get; set; }
	public Guid AccountId { get; set; }
	public DateOnly Date { get; set; }
	public DateTime CreatedAt { get; set; }

	public Recipient Recipient { get; set; }
	public Client Client { get; set; }
	public Account Account { get; set; }

	[NotMapped]
	// ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
	public string InvoiceNumber { get; set; } = string.Empty;
}