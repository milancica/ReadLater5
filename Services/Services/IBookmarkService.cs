using Entity;
using System.Collections.Generic;
using System.Security.Principal;

namespace Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark category, string userId);
        List<Bookmark> GetBookmarks(string userId);
        Bookmark GetBookmark(int Id);
        void UpdateBookmark(Bookmark category);
        void DeleteBookmark(Bookmark category);
        void Clicked(Bookmark bookmark);
    }
}
