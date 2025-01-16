using DevoloperJokesApp.Data;
using DevoloperJokesApp.Models;
using DevoloperJokesApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DevoloperJokesApp.Controllers
{
    public class JokesController(ApplicationDbContext context, UserManager<User> userManager) : Controller
    {
        
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<User> _userManager = userManager;

                // GET: Jokes
        public async Task<IActionResult> Index()
        {
            var jokes = await _context.Jokes
                .Include(j => j.User)
                .Select(j => new JokeViewModel
                {
                    Id = j.Id,
                    JokeAnswer = j.JokeAnswer,
                    JokeQuestion = j.JokeQuestion,
                    Developer = j.User!.Email
                }).ToListAsync();

            return View(jokes);
        }

        //Get: ShowSearchForm
        public Task<IActionResult> ShowSearchForm()
        {
            return Task.FromResult<IActionResult>(View());
        }

        //Post: ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.Jokes.Where(j =>
            j.JokeQuestion.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Jokes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Jokes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

        // GET: Jokes/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jokes/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JokeQuestion,JokeAnswer")] Joke joke)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                joke.CreatedById = userId!;
                joke.CreatedDateTime = DateTime.Now;
                _context.Add(joke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joke);
        }

        // GET: Jokes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }
            return View(joke);
        }

        // POST: Jokes/Edit/5
         [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JokeQuestion,JokeAnswer")] Joke joke)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (id != joke.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    joke.EditedDateTime = DateTime.Now;
                    joke.EditedById = userId!;
                    _context.Update(joke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JokeExists(joke.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(joke);
        }

        private bool JokeExists(int id)
        {
            return _context.Jokes.Any(e => e.Id == id);
        }

        // GET: Jokes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joke = await _context.Jokes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joke == null)
            {
                return NotFound();
            }

            return View(joke);
        }

         // POST: Jokes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);
            if (joke != null)
            {
                joke.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        


    }
}