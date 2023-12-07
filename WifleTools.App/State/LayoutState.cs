using System.Collections;
using System.Collections.Generic;
using MudBlazor;

namespace WifleTools.State;

public class LayoutState : StateManagerBase, IList<(string Url, string Text, string Icon)>
{
	private readonly List<(string Url, string Text, string Icon)> _navLinks = new();
	private string? _subtext;
	private string? _backUrl;
	private MaxWidth _maxWidth = MaxWidth.False;
	private bool _fixedWidth = true;
	private bool _isDarkMode = true;

	public string? Subtext
	{
		get => _subtext;
		set
		{
			if (_subtext == value)
			{
				return;
			}

			_subtext = value;
			NotifyStateChanged();
		}
	}

	public string? BackUrl
	{
		get => _backUrl;
		set
		{
			if (_backUrl == value)
			{
				return;
			}

			_backUrl = value;
			NotifyStateChanged();
		}
	}

	public MaxWidth MaxWidth
	{
		get => _maxWidth;
		set
		{
			if (_maxWidth == value)
			{
				return;
			}

			_maxWidth = value;
			NotifyStateChanged();
		}
	}

	public bool FixedWidth
	{
		get => _fixedWidth;
		set
		{
			if (_fixedWidth == value)
			{
				return;
			}

			_fixedWidth = value;
			NotifyStateChanged();
		}
	}

	public bool IsDarkMode
	{
		get => _isDarkMode;
		set
		{
			if (_isDarkMode == value)
			{
				return;
			}

			_isDarkMode = value;
			NotifyStateChanged();
		}
	}

	/// <summary>
	/// Completely resets the <see cref="LayoutState"/>
	/// </summary>
	/// <remarks>
	/// This method call not only clears the navigation links in the backing <see cref="List"/>, but also resets the <see cref="Subtext"/> and <see cref="BackUrl"/> properties to null.
	/// </remarks>
	public void Reset()
	{
		_subtext = null;
		_backUrl = null;
		_navLinks.Clear();
		NotifyStateChanged();
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <inheritdoc />
	public IEnumerator<(string Url, string Text, string Icon)> GetEnumerator() => _navLinks.GetEnumerator();

	/// <inheritdoc />
	public void Add((string, string, string) item)
	{
		_navLinks.Add(item);
		NotifyStateChanged();
	}

	/// <inheritdoc />
	public void Clear()
	{
		_navLinks.Clear();
		NotifyStateChanged();
	}

	/// <inheritdoc />
	public bool Contains((string, string, string) item) => _navLinks.Contains(item);

	/// <inheritdoc />
	public void CopyTo((string, string, string)[] array, int arrayIndex) => _navLinks.CopyTo(array, arrayIndex);

	/// <inheritdoc />
	public bool Remove((string, string, string) item)
	{
		var result = _navLinks.Remove(item);
		NotifyStateChanged();
		return result;
	}

	/// <inheritdoc />
	public int Count => _navLinks.Count;

	/// <inheritdoc />
	public bool IsReadOnly => false;

	/// <inheritdoc />
	public int IndexOf((string, string, string) item) => _navLinks.IndexOf(item);

	/// <inheritdoc />
	public void Insert(int index, (string, string, string) item)
	{
		_navLinks.Insert(index, item);
		NotifyStateChanged();
	}

	/// <inheritdoc />
	public void RemoveAt(int index)
	{
		_navLinks.RemoveAt(index);
		NotifyStateChanged();
	}

	/// <inheritdoc />
	public (string Url, string Text, string Icon) this[int index]
	{
		get => _navLinks[index];
		set
		{
			_navLinks[index] = value;
			NotifyStateChanged();
		}
	}
}