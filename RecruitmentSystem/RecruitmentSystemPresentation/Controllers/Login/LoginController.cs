using RecruitmentSystemBusiness;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentSystemPresentation.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        string hostURL = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public LoginController()
        {
            hostURL = ConfigurationManager.AppSettings["HostURL"];
        }

        // GET: Login        
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var loginModel = new LoginModel();
            ViewBag.msg = string.Empty;
            return View(loginModel);
        }
        /// <summary>
        /// Indexes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel model)
        {
            string msg = string.Empty;
            string apiUrl = string.Format("{0}Login/ValidUser", hostURL);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, model);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    if (data == "1")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    ViewBag.msg = "You are not a valid user!";
                }
                return View(model);
            }

        }
    }
}