using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using School.Business;
using School.Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace School.Website.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISchoolService schoolService;
        private readonly IUserService userService;
        

        public HomeController(ISchoolService schoolService, IUserService userService)
        {
            this.schoolService = schoolService;
            this.userService = userService;
        }

        public IActionResult Index()
        {

            // returns School.Business.Model.ClassMasterModel[]
            var classList = schoolService.Classes;

            // convert to School.Website.Model.ClassMasterModel[]

            var myClassList = classList
                                        .Select(c => new ClassMasterModel
                                        {
                                            ClassId = c.ClassId,
                                            ClassName = c.ClassName,
                                            ClassDescription = c.ClassDescription,
                                            ClassPrice = c.ClassPrice,
                                            ClassSessions = c.ClassSessions
                                        }).ToArray();
            HomePageModel model = new HomePageModel();
            model.Classes = myClassList;
            return View(model);

        }

        public IActionResult ClassList()
        {
            // returns School.Business.Model.ClassMasterModel[]
            var classList = schoolService.Classes;

            // convert to School.Website.Model.ClassMasterModel[]
            var myClassList = classList
                                        .Select(c => new ClassMasterModel
                                        {
                                            ClassId = c.ClassId,
                                            ClassName = c.ClassName,
                                            ClassDescription = c.ClassDescription,
                                            ClassPrice = c.ClassPrice,
                                            ClassSessions = c.ClassSessions
                                        }).ToArray();
            HomePageModel model = new HomePageModel();
            model.Classes = myClassList;
            return View(model);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "About us.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewData["ReturnUrl"] = Request.Query["returnUrl"];
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userService.LogIn(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User email and password do not match.");
                }
                else
                {
                    // Create json for user session variable
                    var json = JsonConvert.SerializeObject(new School.Website.Models.UserModel
                    {
                        UserName =  user.UserName,
                        UserId = user.UserId,
                        Email = user.UserEmail,
                        Password = user.UserPassword
                    });

                    // Set User session variable
                    HttpContext.Session.SetString("User", json);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserEmail),
                    new Claim(ClaimTypes.Role, "User"),
                };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),

                        IsPersistent = false,

                        IssuedUtc = DateTimeOffset.UtcNow,
 
                    };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties).Wait();

                    return Redirect(returnUrl ?? "~/");
                }
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel registerUserModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Register(registerUserModel.UserName, registerUserModel.Email, registerUserModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("msg", "This email has already registered.");
                    return View();
                }


                return Redirect("~/");
            }

            return View();
        }

        [Authorize]
        public IActionResult EnrollInClass()
        {
            // Get list of all Classes
            SelectList classListSL = schoolService.PopulateClassesDropDownList();
            
            // create the EnrollViewModel with list of all classes
            var model = new EnrollViewModel
            {
                ClassListSL = classListSL
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EnrollInClass(int classid)
        {
            var user = JsonConvert.DeserializeObject<Models.UserModel>(HttpContext.Session.GetString("User"));
            schoolService.AddClassForUser(user.UserId, classid);

            return RedirectToAction("StudentClass");

        }

        [Authorize]
        public IActionResult StudentClass()
        {
            // use session variable to get the user
            var user = JsonConvert.DeserializeObject<Models.UserModel>(HttpContext.Session.GetString("User"));

            //Get the classes for this userId
            var studentClasses = schoolService.GetClassesForStudent(user.UserId)
                        .Select(c => new School.Website.Models.StudentClassModel
                        {
                            UserId = c.UserId,
                            ClassId = c.ClassId,
                            ClassName = c.ClassName,
                            ClassDescription = c.ClassDescription,
                            ClassPrice = c.ClassPrice
                        })
                        .ToList();

            return View(studentClasses);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Remove("User");

            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }
    }
}
