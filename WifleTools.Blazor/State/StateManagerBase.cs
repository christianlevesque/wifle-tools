using System;

namespace WifleTools.State;

public abstract class StateManagerBase
{
	protected bool HasChanges;
	protected bool IsFrozen;

	public event Action? OnChange;

	protected void NotifyStateChanged()
	{
		if (IsFrozen)
		{
			HasChanges = true;
			return;
		}

		OnChange?.Invoke();
	}

	public void Freeze() => IsFrozen = true;

	public void Unfreeze()
	{
		if (HasChanges)
		{
			NotifyStateChanged();
			HasChanges = false;
		}

		IsFrozen = false;
	}
}