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
    public class ModuleController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        [HttpGet]
        public ActionResult GetModule(int? skillId)
        {
            return View(_context.Skills
                .First(skill => skill.SkillId == skillId));
        }

        [HttpGet]
        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(CreateTaskViewModel taskViewModel)
        {
            if (taskViewModel == null || taskViewModel.SkillId == 0)
            {
                return null;
            }

            Task task = new Task()
            {
                Number = taskViewModel.Number,
                Name = taskViewModel.Name,
                Description = taskViewModel.Description,
                Note = taskViewModel.Note,
                Materials = Mapper.Map<ICollection<Material>>(taskViewModel.Materials),
                SkillId = taskViewModel.SkillId
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult AddMaterial(int? skillId)
        {
            SelectList tasks = new SelectList(_context.Tasks.Where(x=>x.SkillId == skillId), "TaskId", "Name");
            ViewBag.Tasks = tasks;
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterial(MaterialViewModel materialViewModel)
        {
            if (materialViewModel == null)
            {
                return null;
            }

            Material material = new Material()
            {
                Name = materialViewModel.Name,
                TaskId = materialViewModel.TaskId
            };

            _context.Materials.Add(material);
            _context.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult AddPoint(int? skillId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPoint(CreateAgendaPointModelView pointViewModel)
        {
            if (pointViewModel == null)
            {
                return null;
            }

            ModulePoint point = new ModulePoint()
            {
                Description = pointViewModel.Description,
                SkillId = pointViewModel.SkillId
            };

            _context.ModulePoints.Add(point);
            _context.SaveChanges();

            return View();
        }
    }
}