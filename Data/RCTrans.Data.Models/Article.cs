namespace RCTrans.Data.Models
{
    using RCTrans.Data.Common.Models;

    public class Article : BaseModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
