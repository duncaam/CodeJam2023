using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IS7024Project.Serializations
{

    

    public class WalkScoreResponse
    {
        public Guid WalkScoreResponseId { get; set; }
        public int? status { get; set; }
        public int? walkscore { get; set; }
        public string description { get; set; }
        public DateTime updated { get; set; }
        public string logoUrl { get; set; }
        public string moreInfoIcon { get; set; }
        public string moreInfoLink { get; set; }
        public string wsLink { get; set; }
        public string helpLink { get; set; }
        public double? snappedLat { get; set; }
        public double? snappedLon { get; set; }

            public int? Transitscore { get; set; }
            public string Transitdescription { get; set; }
            public string Transitsummary { get; set; }
        
            public int? Bikescore { get; set; }
            public string Bikedescription { get; set; }
            public string Bikesummary { get; set; }
            }



}
