using System.Collections.Generic;
using Business;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookController : ControllerBase
    {
        readonly IBlBook _blBook;

        public BookController(BlBook blBook)
        {
            _blBook = blBook;
        }

        public List<ListBookModel> List(string query)
        {
            return _blBook.List(query);
        }


    }
}