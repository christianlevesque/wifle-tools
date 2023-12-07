using System.ComponentModel.DataAnnotations;

namespace WifleTools;

public abstract class AddressableEntity : Entity
{
	[Required]
	[MinLength(5)]
	[MaxLength(100)]
	public string Name { get; set; } = default!;

	[MaxLength(100)]
	public string? Address1 { get; set; }

	[MaxLength(100)]
	public string? Address2 { get; set; }

	[MaxLength(100)]
	public string? City { get; set; }

	[MaxLength(20)]
	public string? State { get; set; }
}