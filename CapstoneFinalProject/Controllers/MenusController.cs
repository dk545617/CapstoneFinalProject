using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneFinalProject.Data;
using CapstoneFinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using CapstoneFinalProject.Infrastructure;

namespace CapstoneFinalProject.Controllers
{
    public class MenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Menus.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        public IActionResult AddToCart(string id, string returnUrl)
        {
            Menu menu = _context.Menus.FirstOrDefault(m => m.MenuId == id);

            if(menu != null)
            {
                Cart cart = GetCart();
                cart.AddItem(menu, 1);
                SaveCart(cart);
            }

            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public IActionResult RemoveFromCart(string id, string returnUrl)
        {
            Menu menu = _context.Menus.FirstOrDefault(m => m.MenuId == id);

            if (menu != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(menu);
                SaveCart(cart);
            }

            return View("AddToCart", new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;

        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);

        }

        [Authorize(Roles = "Admin")]
        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["MenuCategoryId"] = new SelectList(_context.MenuCategories, "MenuCategoryId", "Name");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Name,Price,Description,MenuCategoryId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuCategoryId"] = new SelectList(_context.MenuCategories, "MenuCategoryId", "MenuCategoryId", menu.MenuCategoryId);
            return View(menu);
        }
        [Authorize(Roles = "Admin")]
        // GET: Menus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["MenuCategoryId"] = new SelectList(_context.MenuCategories, "MenuCategoryId", "MenuCategoryId", menu.MenuCategoryId);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MenuId,Name,Price,Description,MenuCategoryId")] Menu menu)
        {
            if (id != menu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuCategoryId"] = new SelectList(_context.MenuCategories, "MenuCategoryId", "MenuCategoryId", menu.MenuCategoryId);
            return View(menu);
        }
        [Authorize(Roles ="Admin")]
        // GET: Menus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var menu = await _context.Menus.SingleOrDefaultAsync(m => m.MenuId == id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(string id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}
