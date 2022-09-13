using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync (int id, BookModel bookModel);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int id);
    }
}
