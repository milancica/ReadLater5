using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;

namespace ReadLater5.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;
        UserManager<ApplicationUser> _userManager;

        public BookmarksController(
            IBookmarkService bookmarkService,
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        // GET: Bookmarks
        public IActionResult Index()
        {
            List<Bookmark> model = _bookmarkService.GetBookmarks(_userManager.GetUserId(User));

            return View(model);
        }

        // GET: Bookmarks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            Bookmark category = _bookmarkService.GetBookmark((int)id);
            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            return View(category);
        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            var model = new Bookmark
            {
                Categories = _categoryService.GetCategories()
            };

            return View(model);
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.CreateBookmark(bookmark, _userManager.GetUserId(User));
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateAjax([FromBody] Bookmark bookmark)
        {
            _bookmarkService.CreateBookmark(bookmark, _userManager.GetUserId(User));

            return Json("Success");
        }

        [HttpPost]
        public JsonResult BookmarkClicked([FromBody] int? id)
        {
            if (id == null)
                throw new ArgumentException();

            var bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
                throw new ArgumentException();

            _bookmarkService.Clicked(bookmark);

            return Json("Success");
        }

        // GET: Bookmarks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            bookmark.Categories = _categoryService.GetCategories();

            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public JsonResult EditAjax([FromBody] Bookmark bookmark)
        {
            _bookmarkService.UpdateBookmark(bookmark);

            return Json(true);
        }

        // GET: Bookmarks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark category = _bookmarkService.GetBookmark((int)id);
            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(category);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bookmark category = _bookmarkService.GetBookmark(id);
            _bookmarkService.DeleteBookmark(category);
            return RedirectToAction("Index");
        }

        // GET: Bookmarks/Preview/5
        [AllowAnonymous]
        public IActionResult Preview(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            _bookmarkService.Clicked(bookmark);

            return Redirect(bookmark.URL);
        }
    }
}
