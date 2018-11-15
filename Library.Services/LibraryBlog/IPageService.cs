namespace Library.Services.LibraryBlog
{
    using System;
    using System.Threading.Tasks;

    public interface IPageService
    {
        int TotalPages(Func<string, Task<int>> input);
    }
}
