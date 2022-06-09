using Reference.Books.Services;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Reference.Dilicom;
using System.IO;
using System.Xml.Linq;
using System.Linq;

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
            using (StreamReader reader = new StreamReader("/media/fcollonge/0D2F-12D1/notices.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(OnixMessage));
                OnixMessage onixMessage = (OnixMessage) serializer.Deserialize(reader);
                Console.WriteLine("OK");
            }


            // await _booksService.CreateAsync(newBook);

            // return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

    }
}