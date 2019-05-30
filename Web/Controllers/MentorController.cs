using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.SkillModels;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class MentorController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        public MentorController()
        {
        }
        
        public ActionResult Index(int? categoryId)
        {
            if(categoryId != null)
            {
                return View(_context.Categories.Where(x=>x.CategoryId == categoryId).ToList());
            }
            else
            {
                return View(_context.Categories.ToList());
            }
        }

        [Authorize(Roles = "Mentor")]
        [HttpGet]
        public ActionResult AddCategory() => View();

        [Authorize(Roles = "Mentor")]
        [HttpPost]
        public ActionResult AddCategory(CreateCategoryOfSkill viewModel)
        {
            if(viewModel.Name == null)
            {
                return null;
            }

            CategoryOfSkill category = new CategoryOfSkill()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult AddSkill()
        {
            SelectList categories = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewBag.Categories = categories;

            return View();
        }
        
        [HttpPost]
        public ActionResult AddSkill(SkillViewModel skillViewModel)
        {
            if (skillViewModel == null || skillViewModel.CategoryId == 0)
            {
                return null;
            }

            Skill skill = new Skill()
            {
                Name = skillViewModel.Name,
                Description = skillViewModel.Description,
                CategoryId = skillViewModel.CategoryId
            };
            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}