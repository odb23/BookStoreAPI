using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Helpers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Books, BookModel>();
        }
    }
}
