using System.ComponentModel.DataAnnotations;

namespace IS7024Project.Models
{
    public class PhotoshopResponse
    {
        [Key]
        public int PhotoshopResponseId { get; set; }
        public string EmotionalResult { get; set; }
        public string ReturnLine1 { get; set; }
        public string ReturnLine2 { get; set; }
        public string PhotoReturnUrl { get; set; }
        public int? EmotionCount { get; set; }
        public int? EmotionOneId { get; set; }
        public decimal? EmotionOneIndex { get; set; }
        public int? EmotionTwoId { get; set; }
        public decimal? EmotionTwoIndex { get; set; }
        public int? PrimaryEmotionId { get; set; }
        public int? SecondaryEmotionId { get; set; }
        public decimal? PrimaryEmotionIndex { get; set; }
        public decimal? SecondaryEmotionIndex { get; set; }

    }
}
