using System.Windows.Input;

namespace WifleTools.Utils;

public class MainMenuItem
{
	public string Text { get; }
	public ICommand Command { get; }

	public MainMenuItem(string text, ICommand command)
	{
		Text = text;
		Command = command;
	}
}