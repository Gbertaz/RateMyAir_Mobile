using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Net.Http.Headers;
using RateMyAir_Mobile.ViewModel;
using RateMyAir.Common.Interfaces.Services;
using static RateMyAir.Common.Entities.Enums.Enums;
using RateMyAir.Common.Services.RateMyAirApi;

namespace RateMyAir_Mobile
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureSyncfusionCore()
				.ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

			builder.Services.AddHttpClient(HttpClients.RateMyAir.ToString(), httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://yourdomain.duckdns.org/ratemyair/api/");
				httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
				httpClient.DefaultRequestHeaders.Add("ApiKey", "YOUR API KEY");
			});

			builder.Services.AddTransient<IAirQualityIndexProvider, AirQualityIndexApiService>();
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<AirQualityViewModel>();

			return builder.Build();
		}
	}
}