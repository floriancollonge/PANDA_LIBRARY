using Reference.Books.Services;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Reference.Dilicom;
using System.IO;

namespace Reference.Books
{

    [ApiController]
    [Route("/")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Route("/book/integrate")]
        public void Integrate()
        {
            using (StreamReader reader = new StreamReader("/media/fcollonge/0D2F-12D1/Documentation/Société/Panda's Library/DOCS TECHNIQUES LIBRAIRE ONIX/exemples notices enrichies.zip"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OnixMessage));
                OnixMessage onixMessage = (OnixMessage) serializer.Deserialize(reader);
            }


            // await _booksService.CreateAsync(newBook);

            // return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

    }
}