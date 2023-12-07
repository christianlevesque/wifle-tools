using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WifleTools.Pages;

public abstract class FormPageBase<TPage, TModel> : ActionPageBase<TPage, TModel>
	where TPage : ComponentBase
	where TModel : Entity, new()
{
	[Parameter]
	public Guid? Id { get; set; }

	protected bool IsEditing => Id.HasValue;

	protected abstract Task OnSubmit();

	protected void Reset()
	{
		Model = new TModel();
	}
}