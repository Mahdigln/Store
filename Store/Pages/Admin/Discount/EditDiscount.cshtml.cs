using System.Globalization;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable
namespace Store.Pages.Admin.Discount
{
    public class EditDiscountModel : PageModel
    {
        private IOrderService _orderService;

        public EditDiscountModel(IOrderService orderService)
        {
            _orderService = orderService;

        }
        [BindProperty]
        public DataLayer.Entities.Order.Discount Discount { get; set; }
        public void OnGet(int id)
        {
            Discount = _orderService.GetDiscountById(id);
        }
        public IActionResult OnPost(string stDate = "", string edDate = "")
        {
            if (stDate != null)
            {
                string[] std = stDate.Split('/');
                Discount.StartDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                );
            }
            if (edDate != null)
            {
                string[] edd = edDate.Split('/');
                Discount.EndDate = new DateTime(int.Parse(edd[0]),
                    int.Parse(edd[1]),
                    int.Parse(edd[2]),
                    new PersianCalendar()
                );
            }
            if (!ModelState.IsValid)
                return Page();

            _orderService.UpdateDiscount(Discount);

            return RedirectToPage("Index");
        }

    }
}
