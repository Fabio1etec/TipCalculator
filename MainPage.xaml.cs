﻿namespace TipCalculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		// Counter.Clicked += OnCounterClicked;

		
		// Nesse contexto, o +=
		billInput.TextChanged += (s, e) => CalculateTip(false, false);
		roundDown.Clicked += (s, e) => CalculateTip(false, true);
		roundUp.Clicked += (s, e) => CalculateTip(true, false);

		tipPercentSlider.ValueChanged += (s, e) =>
		{
			double pct = Math.Round(e.NewValue);
			tipPercent.Text = pct + "%";
			CalculateTip(false, false);
		};
	}
    void CalculateTip(bool roundUp, bool roundDown)
	{
		double t;
		if (Double.TryParse (billInput.Text, out t) && t > 0)
		{
			double pct = Math.Round(tipPercentSlider.Value);
			double tip = Math.Round(t * (pct / 100.0), 2);

			double final = t + tip;

			if (roundUp)
			{
				final = Math.Ceiling(final);
				tip = final - t;
			}
			else if (roundDown) 
			{
				final = Math.Floor(final);
				tip = final = t;
			}

			TipOutput.Text = tip.ToString("C");
			TotalOutput.Text = final.ToString("C");
		}
	}
	private void OnCounterClicked(object sender, EventArgs e) 
	{
	}
	void OnNormalTip(object sender, EventArgs e) 
	{
		tipPercentSlider.Value = 15;
	}
    void OnGenerousTip(object sender, EventArgs e)
	{
		tipPercentSlider.Value = 20;
	}

}

