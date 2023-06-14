﻿using Library.Contracts;
using Library.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> All()
        {
            try
            {
                var books = await bookService.GetAllAsync();
                return View(books);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        public async Task<IActionResult> Mine()
        {
            try
            {
                var currUserId = User.GetId();

                var books = await bookService.GetUserBooksAsync(currUserId);

                return View(books);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
           
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            try
            {
                var currUserId = User.GetId();

                bool userHaveBook = await bookService.DoesUserHaveBookAsync(currUserId, id);

                if(userHaveBook)
                {
                    return RedirectToAction("All", "Book");
                }

                await bookService.AddBookToUserCollectionAsync(currUserId, id);

                return RedirectToAction("All", "Book");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            try
            {
                var currUserId = User.GetId();

                bool userHaveBook = await bookService.DoesUserHaveBookAsync(currUserId, id);

                if (!userHaveBook)
                {
                    return RedirectToAction("All", "Book");
                }

                await bookService.RemoveBookFromUserCollectionAsync(currUserId, id);

                return RedirectToAction("All", "Book");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}