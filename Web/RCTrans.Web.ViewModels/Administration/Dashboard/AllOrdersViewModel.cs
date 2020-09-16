namespace RCTrans.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using RCTrans.Web.ViewModels.Order;

    public class AllOrdersViewModel
    {
        public IEnumerable<SingleOrderViewModel> Orders { get; set; }
    }
}
