using MudBlazor;

namespace WifleTools.Tools;

public class DefaultTheme : MudTheme
{
	private readonly string[] _fontFamily =
	{
		"Exo 2",
		"sans-serif"
	};

	private const string HeadingFontSize = "2rem";
	private const int FontWeight = 300;

	/// <inheritdoc />
	public DefaultTheme()
	{
		Typography = new Typography
		{
			Default = new Default
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			H1 = new H1
			{
				FontFamily = _fontFamily,
				FontSize = "3rem",
				FontWeight = FontWeight
			},
			H2 = new H2
			{
				FontFamily = _fontFamily,
				FontSize = HeadingFontSize,
				FontWeight = FontWeight
			},
			H3 = new H3
			{
				FontFamily = _fontFamily,
				FontSize = HeadingFontSize,
				FontWeight = FontWeight
			},
			H4 = new H4
			{
				FontFamily = _fontFamily,
				FontSize = HeadingFontSize,
				FontWeight = FontWeight
			},
			H5 = new H5
			{
				FontFamily = _fontFamily,
				FontSize = HeadingFontSize,
				FontWeight = FontWeight
			},
			H6 = new H6
			{
				FontFamily = _fontFamily,
				FontSize = "1rem",
				FontWeight = FontWeight
			},
			Subtitle1 = new Subtitle1
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Subtitle2 = new Subtitle2
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Body1 = new Body1
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Body2 = new Body2
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Button = new Button
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Caption = new Caption
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			},
			Overline = new Overline
			{
				FontFamily = _fontFamily,
				FontWeight = FontWeight
			}
		};

		Palette = new Palette { Tertiary = "#FFFFFF" };
	}
}