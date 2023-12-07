#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using WifleTools.Banking;
using WifleTools.Clients;
using WifleTools.Recipients;

namespace WifleTools.Invoicing;

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


	public Recipient Recipient { get; set; }
	public Client Client { get; set; }
	public Account Account { get; set; }
}