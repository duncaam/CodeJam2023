using System;
using System.ComponentModel.DataAnnotations;

namespace IS7024Project.Models
{
    public class googleVAPIResponse
    {
        [Key]
        public Guid googleVAPIResponseId { get; set; }
        public decimal? joyIndex { get; set; }
        public decimal? sorrowIndex { get; set; }
        public decimal? angerIndex { get; set; }
        public decimal? surpriseIndex { get; set; }
        public decimal? detectionConfidence { get; set; }
    }
}