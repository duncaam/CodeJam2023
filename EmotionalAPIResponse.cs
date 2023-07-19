using System.ComponentModel.DataAnnotations;

namespace IS7024Project
{
    public class EmotionalAPIResponse
    {
        [Key]
        public int EmotionalAPIResponseId { get; set; }
        public string ReturnLine1 { get; set; }
        public string ReturnLine2 { get; set; }
        public string PhotoReturnUrl { get; set; }
    }
}
