using System;
using System.Collections.Generic;

namespace XamarinConnect.Models
{
    public class ResultsItem
    {
        public string Id { get; set; }
        public string Display { get; set; }
        public Dictionary<string, object> Properties;

        public ResultsItem() => Properties = new Dictionary<string, object>();
    }
}
