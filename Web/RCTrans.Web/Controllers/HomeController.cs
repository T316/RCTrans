namespace RCTrans.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data.Interfaces;
    using RCTrans.Services.Messaging;
    using RCTrans.Web.ViewModels;
    using RCTrans.Web.ViewModels.Blog;
    using RCTrans.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly IBlogsService blogsService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IEmailSender emailSender,
            IBlogsService blogsService,
            UserManager<ApplicationUser> userManager)
        {
            this.emailSender = emailSender;
            this.blogsService = blogsService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var articles = this.blogsService.GetTopThree<IndexArticleViewModel>();
            viewModel.Articles = articles;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult Terms()
        {
            return this.View();
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacts(ContactsInputModel input)
        {
            if (input.Email != "t.3@abv.bg")
            {
                this.ModelState.AddModelError(string.Empty, "Не можем да пратим съобщение от този имейл адрес.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.emailSender
                .SendEmailAsync(input.Email, input.FullName, "todor.yordanov93@gmail.com", "RCTrans", input.Content);

            return this.Redirect("/Home/ContactComplete");
        }

        public IActionResult ContactComplete()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public new IActionResult NotFound()
        {
            return this.View();
        }

        // public async Task<IActionResult> AddAdministrator()
        // {
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    var result = await this.userManager.AddToRoleAsync(user, "Administrator");
        //    return this.Json(result);
        // }
    }
}
