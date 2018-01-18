using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly BookingSystemContext _context;

        public StudentController(BookingSystemContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(bool hasPaid, string studentCourse, string searchString)
        {
            //Use LINQ to go list of courses
            IQueryable<string> courseQuery = from m in _context.Student
                                             orderby m.Course
                                             select m.Course;
            
            IQueryable<bool> ifPaid =  from p in _context.Student
                                        orderby p.Paid
                                        select p.Paid;

            var students = from m in _context.Student
                           select m;
                        
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(studentCourse))
            {
                students = students.Where(x => x.Course == studentCourse);
            }

            // LINQ for boolean model.Paid
            if(hasPaid && !hasPaid)
            {
                students = students.Where(s => s.Paid && !s.Paid);
            }    
            else if(hasPaid)
            {
                students = students.Where(s => s.Paid);
            }
            // else if(!hasPaid)
            // {
            //     students = students.Where(s => !s.Paid);
            // }
            
            var studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.courses = new SelectList(await courseQuery.Distinct().ToListAsync());
            studentCourseVM.students = await students.ToListAsync();
            studentCourseVM.paid = new SelectList(await ifPaid.Distinct().ToListAsync());

            return View(studentCourseVM);


        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Course,Paid,PaidDate,Email,Comments")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Course,Paid,PaidDate,Email,Comments")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
