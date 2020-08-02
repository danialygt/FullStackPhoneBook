using FullStackPhoneBook.Core.Contracts.People;
using FullStackPhoneBook.Core.Contracts.Phones;
using FullStackPhoneBook.Core.Contracts.Tags;
using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Domain.Core.Phones;
using FullStackPhoneBook.EndPoints.Models.People;
using FullStackPhoneBook.EndPoints.MVC.Models.Phones;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FullStackPhoneBook.EndPoints.MVC.Controllers
{

    public class PeopleController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonTagRepository _personTagRepository;
        private readonly IPhoneRepository _phoneRepository;


        public PeopleController(
            ITagRepository tagRepository,
            IPersonRepository personRepository,
            IPersonTagRepository personTagRepository,
            IPhoneRepository phoneRepository)
        {
            _tagRepository = tagRepository;
            _personRepository = personRepository;
            _personTagRepository = personTagRepository;
            _phoneRepository = phoneRepository;



        }

        public IActionResult Index()
        {
            var people = _personRepository.GetAll().ToList();

            return View(people);
        }





        public IActionResult Add()
        {
            AddNewPersonDisplayViewModel model = new AddNewPersonDisplayViewModel();
            model.TagsForDisplay = _tagRepository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddNewPersonGetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    Tags = new List<PersonTag>(model.SelectedTag.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList())
                };
                if (model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        person.Image = Convert.ToBase64String(fileBytes);
                    }
                }
                _personRepository.Add(person);
                return RedirectToAction("Index");
            }

            AddNewPersonDisplayViewModel modelForDisplay = new AddNewPersonDisplayViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Image = model.Image,
                Address = model.Address
            };
            modelForDisplay.TagsForDisplay = _tagRepository.GetAll().ToList();
            return View(modelForDisplay);
        }




        public IActionResult Detail(int id)
        {
            var allPersonTags = _personTagRepository.GetAll().ToList();
            var allTags = _tagRepository.GetAll().ToList();
            var allPhones = _phoneRepository.GetAll().ToList();
            var person = _personRepository.Get(id);

            try
            {

                if (person.Image != null)
                {
                    person.Image = String.Format("data:image/png;base64,{0}", person.Image);
                }
            }
            catch { }
            
               return View(person);
        }







        public IActionResult AddPhone(int id)
        {
            PhoneAddModel p = new PhoneAddModel
            {
                person = _personRepository.Get(id)
            };
            if ( p.person == null)
            {
                ModelState.AddModelError("NotExictsUser", "This user not found!");
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult AddPhone(int id, PhoneAddModel phoneAddModel)
        {
            phoneAddModel.phone.PersonId = id;
            _phoneRepository.Add(phoneAddModel.phone);
            return Detail(id);
        }





        public IActionResult EditPhone(int id)
        {
            var phonesh = _phoneRepository.Get(id);
            var personesh = _personRepository.Get(phonesh.PersonId);
            var phoneAddModel = new PhoneAddModel
            {

                phone = phonesh,
                person = personesh

            };


            return View(phoneAddModel);
        }

        [HttpPost]
        public IActionResult EditPhone(int id, PhoneAddModel phoneAddModel)
        {
            
            if (Enum.IsDefined(typeof(PhoneType), phoneAddModel.phone.PhoneType.ToString()))
            {
                _phoneRepository.Delete(id);
                _phoneRepository.Add(phoneAddModel.phone);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("NotExicstType", "Phone type not exicts! please select one of the list");
                return View(phoneAddModel);
            }
        }
    }

}
