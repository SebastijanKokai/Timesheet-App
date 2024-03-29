﻿namespace Timesheet_API.Models.Parameters
{
    public abstract class QueryStringParameters
    {
        public char? FirstLetter { get; set; } = null;
        public string? Name { get; set; } = null;

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
