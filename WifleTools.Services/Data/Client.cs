using System.ComponentModel.DataAnnotations;

namespace WifleTools.Data;

public class Client : AddressableEntity
{
	[Range(1, int.MaxValue)]
	public int Rate { get; set; }
}