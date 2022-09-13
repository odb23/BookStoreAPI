using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _dbContext;

        public BookRepository(BookStoreContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await this._dbContext.Books.Select(book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
            }).ToListAsync();

            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var record = await this._dbContext.Books.Where(book => book.Id == bookId).Select(book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description
            }).FirstOrDefaultAsync();

            return record;
        }

        public async Task<int> AddBookAsync (BookModel bookModel)
        {
            var book = new Books() { 
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            var record = this._dbContext.Books.Add(book);
            await this._dbContext.SaveChangesAsync();

            return book.Id;
        } 
    }
}
