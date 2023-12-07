#nullable disable
using System.ComponentModel.DataAnnotations;

namespace WifleTools.Banking;

public class Account : Entity
{
	[Required]
	public string Name { get; set; } 

	[Required]
	public string AccountNumber { get; set; }

	[Required]
	public string AbaNumber { get; set; }
}