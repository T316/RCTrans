namespace RCTrans.Web.ViewModels.Blog
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleCreateInputModel
    {
        [Required(ErrorMessage = "Заглавието е задължително.")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително.")]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Картинката е задължителна.")]
        [Display(Name = "Картинка")]
        public string ImageUrl { get; set; }
    }
}