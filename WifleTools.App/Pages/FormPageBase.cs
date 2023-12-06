using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace WifleTools.Pages;

public abstract class FormPageBase<TPage, TService, TModel> : ActionPageBase<TPage, TService, TModel>
	where TPage : ComponentBase
	where TModel : new()
{
	protected abstract Task OnSubmit();

	protected void Reset()
	{
		Model = new TModel();
		ResetError();
	}
}