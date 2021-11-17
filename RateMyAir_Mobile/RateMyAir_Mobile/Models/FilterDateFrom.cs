using RateMyAir.Common.Interfaces.Filters;
using System;

namespace RateMyAir_Mobile.Models
{
    public class FilterDateFrom : IParametersFormatter
    {
        private readonly DateTime _fromDate;

        public FilterDateFrom(DateTime fromDate)
        {
            _fromDate = fromDate;
        }

        public string CreateQueryStringParameters()
        {
            return string.Format("fromDate={0}", IParametersFormatter.FormatDate(_fromDate));
        }
    }
}
