namespace RCTrans.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RCTrans.Data.Common.Models;

    public class Article : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
