﻿namespace Timesheet_API.Models.Parameters
{
    public class ClientParameters : QueryStringParameters
    {
        public char? FirstLetter { get; set; } = null;

        public string? Name { get; set; } = null;
    }
}
