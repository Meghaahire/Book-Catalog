using Microsoft.AspNetCore.Mvc;
using MVC3.Data;
using MVC3.Models.ViewModel;
using MVC3.Models.Domain;
using Microsoft.EntityFrameworkCore;




namespace MVC3.Controllers
{
    public class BooksController : Controller
    {

        private readonly MVC3DbContext dbContext;


        public BooksController(MVC3DbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books =await dbContext.Books.ToListAsync();
            return View(books);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddBookViewModel addbookRequest)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                BookName = addbookRequest.BookName,
                AuthorName = addbookRequest.AuthorName,
                PublishDate = addbookRequest.PublishDate,
                Price = addbookRequest.Price
                
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
            return RedirectToAction("Add");
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var b = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (b != null)
            {
                var ViewModel = new UpdateBookViewModel()
                {
                    Id = b.Id,
                    BookName = b.BookName,
                    AuthorName = b.AuthorName,
                    PublishDate = b.PublishDate,
                    Price = b.Price
                   
                };
                return await Task.Run(() => View("View", ViewModel));
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateBookViewModel model)
        {
            var b = dbContext.Books.Find(model.Id);
            if (b != null)
            {
                b.BookName = model.BookName;
                b.AuthorName = model.AuthorName;
                b.PublishDate= model.PublishDate;
                b.Price = model.Price;
                

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateBookViewModel model)
        {
            var b = await dbContext.Books.FindAsync(model.Id);
            if (b != null)
            {
                dbContext.Books.Remove(b);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
