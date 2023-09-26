using Core.DTOs.Order;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.Areas.UserPanel.Controllers;

[Area("UserPanel")]
[Authorize]
public class MyOrdersController : Controller
    {
    private IOrderService _orderOrderService;

    public MyOrdersController(IOrderService orderOrderService)
    {
        _orderOrderService = orderOrderService;
    }
    public IActionResult Index()
    {
        return View(_orderOrderService.GetUserOrders(User.Identity.Name));
    }

    public IActionResult ShowOrder(int id, bool finaly = false, string type = "")
    {
        var order = _orderOrderService.GetOrderForUserPanel(User.Identity.Name, id);

        if (order == null)
        {
            return NotFound();
        }
        ViewBag.typeDiscount = type;
        ViewBag.finaly = finaly;
        return View(order);
    }

    public IActionResult FinalyOrder(int Id)
    {
        if (_orderOrderService.FinalyOrder(User.Identity.Name, Id))
        {
            return Redirect("/UserPanel/MyOrders/ShowOrder/" + Id + "?finaly=true");
        }

        return BadRequest();
    }

    public IActionResult UseDiscount(int orderId, string code)
    {
        DiscountUseType type = _orderOrderService.UseDiscount(orderId, code);
        return Redirect("/UserPanel/MyOrders/ShowOrder/" + orderId + "?type=" + type.ToString());

    }



}

