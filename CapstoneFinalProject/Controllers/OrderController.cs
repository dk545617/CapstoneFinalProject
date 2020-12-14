using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using CapstoneFinalProject.Interfaces;

namespace CapstoneFinalProject.Controllers
{
    public class OrderController : Controller
    {
       // private readonly IOrderRepository _orderRepository;
       // private readonly Cart _cart;
       // public OrderController(IOrderRepository orderRepository, Cart cart)
       // {
       //     _orderRepository = orderRepository;
       //     _cart = cart;

       // } 
        public ViewResult Checkout() => View(new Order());
    }

 /*   public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var purchases = _cart.GetCartPurchases();
        _cart.CartPurchases = purchases;
        if (_cart.CartPurchases.Count == 0)
        {
            ModelState.AddModelError("", "There is nothing in your cart yet.");
        }

        if (ModelState.IsValid)
        {
            _orderRepository.CreateOrder(order);
            _cart.ClearCart();
            return RedirectToAction("Confirmation");
        }

        return View(order);
    }*/
}