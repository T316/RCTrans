namespace RCTrans.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using RCTrans.Data.Models;
    using RCTrans.Web.ViewModels.Order;

    public class AllOrdersViewModel
    {
        public IEnumerable<SingleOrderViewModel> Orders { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
