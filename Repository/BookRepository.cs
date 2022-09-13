using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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

             this._dbContext.Books.Add(book);
            await this._dbContext.SaveChangesAsync();

            return book.Id;
        }
        public async Task UpdateBookAsync(int id, BookModel bookModel)
        {
            /*var book = await this._dbContext.Books.FindAsync(id);

            if (book !=null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;
                await this._dbContext.SaveChangesAsync();   
            }*/

            var book = new Books()
            {
                Id=id,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            this._dbContext.Books.Update(book);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument bookModel)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await this._dbContext.SaveChangesAsync();
            }
        }
    }
}
