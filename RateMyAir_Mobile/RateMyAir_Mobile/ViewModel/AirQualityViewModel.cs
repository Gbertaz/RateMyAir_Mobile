using RateMyAir.Common.Entities.DTO;
using RateMyAir.Common.Interfaces.Filters;
using RateMyAir.Common.Interfaces.Services;
using RateMyAir_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateMyAir_Mobile.ViewModel
{
    public class AirQualityViewModel : BaseViewModel
    {
        public int _airQualityIndex;
        public string _airQualityIndexColor;

        private readonly IAirQualityIndexProvider _airQualityIndexProvider;

        public int AirQualityIndex
        {
            get => _airQualityIndex;
            set => SetProperty(ref _airQualityIndex, value);
        }

        public string AirQualityIndexColor
        {
            get => _airQualityIndexColor;
            set => SetProperty(ref _airQualityIndexColor, value);
        }

        public AirQualityViewModel(IAirQualityIndexProvider airQualityIndexProvider)
        {
            IsBusy = true;
            _airQualityIndexProvider = airQualityIndexProvider;
            _airQualityIndex = 0;
            _airQualityIndexColor = "#fff";

            Task.Run(async () =>
            {
                await UpdateAirQuality();
            });

            IsBusy = false;
        }

        private async Task UpdateAirQuality()
        {
            DateTime fromDate = DateTime.Today.AddDays(-365);
            DateTime toDate = DateTime.Today;

            IParametersFormatter filterDateFrom = new FilterDateFrom(fromDate);
            IParametersFormatter filterDateRange = new FilterDateRange(fromDate, toDate);

            // Without date filter
            //List<AirQualityIndexDtoOut> dtoOut = await _airQualityIndexProvider.GetAirQualityIndexAsync();

            // Date from filter
            //List<AirQualityIndexDtoOut> dtoOut = await _airQualityIndexProvider.GetAirQualityIndexAsync(filterDateFrom);

            // Date range filter
            List<AirQualityIndexDtoOut> dtoOut = await _airQualityIndexProvider.GetAirQualityIndexAsync(filterDateRange);

            if (dtoOut == null) return;
            AirQualityIndexDtoOut last = dtoOut.First();
            if (last == null) return;

            _airQualityIndex = (int)last.Pm25Concentration;
            _airQualityIndexColor = "#" + last.Pm25Color;
        }

    }
}
