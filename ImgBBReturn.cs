using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace IS7024Project.Models
{
    public class imgBBReturn
    {
        public Guid imgBBReturnId { get; set; }
        public string imgBBUrl { get; set; }
        public bool isSafe { get; set; }
        public string EmotionalResult { get; set; }
        public int? EmotionCount { get; set; }
        public int? PrimaryEmotionId { get; set; }
        public int? SecondaryEmotionId { get; set; }
        public decimal? PrimaryEmotionIndex { get; set; }
        public decimal? SecondaryEmotionIndex { get; set; }
        public bool CanShare { get; set; }
    }
}
