using RateMyAir.Common.Interfaces.Filters;
using System;

namespace RateMyAir_Mobile.Models
{
    public class FilterDateRange : IParametersFormatter
    {
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;

        public FilterDateRange(DateTime fromDate, DateTime toDate)
        {
            _fromDate = fromDate;
            _toDate = toDate;
        }

        public string CreateQueryStringParameters()
        {
            return string.Format("fromDate={0}&toDate={1}", IParametersFormatter.FormatDate(_fromDate), IParametersFormatter.FormatDate(_toDate));
        }
    }
}
