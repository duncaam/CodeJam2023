using System;
using System.ComponentModel.DataAnnotations;

namespace IS7024Project.Models
{
    public class imgBBResponse
    {
        public Guid imgBBResponseId { get; set; }
        public string imageLocalName { get; set; }
        public bool imgBBsuccess { get; set; }
        public int? imgBBstatus { get; set; }
        public string imgBBDeleteUrl { get; set; }
        public string imgBBUrl { get; set; }
        public string imgLocal { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime imgBBResponseTime { get; set; }
        public bool callSuccess { get; set; }
        public bool faceSuccess { get; set; }
        public int? responseCount { get; set; }
        public decimal? joyIndex { get; set; }
        public decimal? sorrowIndex { get; set; }
        public decimal? angerIndex { get; set; }
        public decimal? surpriseIndex { get; set; }
        public decimal? detectionConfidence { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime googleVAPIResponseTime { get; set; }
        public bool isSafe { get; set; }
        public string EmotionalResult { get; set; }
        public string ReturnLine1 { get; set; }
        public string ReturnLine2 { get; set; }
        public string PhotoReturnUrl { get; set; }
        public int? EmotionCount { get; set; }
        public int? PrimaryEmotionId { get; set; }
        public int? SecondaryEmotionId { get; set; }
        public decimal? PrimaryEmotionIndex { get; set; }
        public decimal? SecondaryEmotionIndex { get; set; }
        public bool CanShare { get; set; }
        public bool CannotShare { get; set; }
        public bool WeDoGood { get; set; }
        public bool WeDoBad { get; set; }
    }
}
