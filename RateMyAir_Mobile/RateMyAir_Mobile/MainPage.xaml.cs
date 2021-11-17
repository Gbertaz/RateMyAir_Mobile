using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using RateMyAir_Mobile.ViewModel;

namespace RateMyAir_Mobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage(AirQualityViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

	}
}
