namespace RCTrans.Web.ViewModels.Order
{
    using System.Collections.Generic;

    public class MyOrdersViewModel
    {
        public IEnumerable<SingleOrderViewModel> Orders { get; set; }
    }
}
