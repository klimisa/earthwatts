using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EarthWatts.Api.Models
{
    public class ResponseView
    {
        public ResponseView()
        {
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}