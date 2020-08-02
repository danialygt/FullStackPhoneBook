using FullStackPhoneBook.Core.Contracts.Tags;
using FullStackPhoneBook.Domain.Core.Tags;
using FullStackPhoneBook.EndPoints.MVC.Models.Tags;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace FullStackPhoneBook.EndPoints.MVC.Controllers
{


    //[Authorize]

    public class TagController : Controller
    {

        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }



        public IActionResult Index()
        {
            TagViewModel viewModel = new TagViewModel
            {
                tags = _tagRepository.GetAll().ToList()
            };

            if (viewModel.tags == null)
            {
                ModelState.AddModelError("NotExictsTag", "There is no tag. please add one!");
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(TagModel model)
        {
            Tag newTag = new Tag
            {
                Title = model.Title
            };
            var tags = _tagRepository.GetAll().ToList();
            foreach (var item in tags)
            {
                if (item.Title == newTag.Title)
                {
                    ModelState.AddModelError("ExictsTag", "Already Exicts this Tag.");
                    break;
                }
            }
            if (ModelState.IsValid)
            {
                _tagRepository.Add(newTag);
            }

            return RedirectToAction("Index");

        }



        public IActionResult Delete(int id)
        {
            var tag = _tagRepository.Get(id);
            var model = new TagModel();

            if (tag == null)
            {
                ModelState.AddModelError("NotExictsTag", "Tag Not Found.");
            }
            else
            {
                model.Title = tag.Title;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, TagModel tagModel)
        {
            _tagRepository.Delete(id);

            return RedirectToAction("Index");
        }


    }
}
