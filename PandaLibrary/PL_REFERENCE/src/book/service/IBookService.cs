using System.Threading.Tasks;
using System.Collections.Generic;

namespace Reference.Books.Services
{

    public interface IBookService
    {
        public Task<List<Book>> GetAsync();

        public Task<Book> GetAsync(string id);

        public Task CreateAsync(Book newBook);

        public Task UpdateAsync(string id, Book updatedBook);

        public Task RemoveAsync(string id);
    }
}