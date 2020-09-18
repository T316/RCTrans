namespace RCTrans.Web.Areas.Identity.Pages.Account.ErrorDescriber
{
    using Microsoft.AspNetCore.Identity;

    public class AppErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            var error = base.DuplicateUserName(userName);
            error.Description = $"Имейл адресът {userName} вече е зает.";
            return error;
        }
    }
}
