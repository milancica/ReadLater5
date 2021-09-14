using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;

        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }

        public Bookmark CreateBookmark(Bookmark bookmark, string userId)
        {
            bookmark.ApplicationUserId = userId;
            bookmark.CreateDate = DateTime.UtcNow;

            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            var existingBookmark = GetBookmark(bookmark.ID);

            existingBookmark.URL = bookmark.URL;
            existingBookmark.ShortDescription = bookmark.ShortDescription;

            _ReadLaterDataContext.Update(existingBookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public List<Bookmark> GetBookmarks(string userId)
        {
            return _ReadLaterDataContext.Bookmarks.Where(x => x.ApplicationUserId == userId).OrderByDescending(x => x.NumberOfClicks).ToList();
        }

        public Bookmark GetBookmark(int Id)
        {
            return _ReadLaterDataContext.Bookmarks.Include(x => x.Category).Where(c => c.ID == Id).FirstOrDefault();
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmarks.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public void Clicked(Bookmark bookmark)
        {
            bookmark.NumberOfClicks++;

            _ReadLaterDataContext.Bookmarks.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }
    }
}
