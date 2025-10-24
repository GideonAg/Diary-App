using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DiaryEntriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> diaryEntryList = _dbContext.DiaryEntries.ToList();
            return View(diaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry diaryEntry)
        {
            if (diaryEntry != null && diaryEntry.Title?.Length < 3)
            {
                ModelState.AddModelError("Title", "Title is too short");
            }

            if (ModelState.IsValid)
            {
                _dbContext.DiaryEntries.Add(diaryEntry);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(diaryEntry);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            DiaryEntry? diaryEntry = _dbContext.DiaryEntries.Find(id);

            if (diaryEntry == null)
                return NotFound();

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry diary)
        {
            if (diary != null && diary.Title?.Length < 3)
            {
                ModelState.AddModelError("Title", "Title is too short");
            }

            if (ModelState.IsValid && diary != null)
            {
                _dbContext.DiaryEntries.Update(diary);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diary);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            DiaryEntry? diaryEntry = _dbContext.DiaryEntries.Find(id);

            if (diaryEntry == null)
                return NotFound();

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry diaryEntry)
        {            
            if (diaryEntry != null && ModelState.IsValid)
            {
                _dbContext.DiaryEntries.Remove(diaryEntry);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
