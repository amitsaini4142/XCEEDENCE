using Newtonsoft.Json;
using RecruitmentSystemBusiness;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentSystemPresentation.Controllers.Admin
{
    public class AdminController : Controller
    {

        string hostURL = string.Empty;
        public AdminController()
        {
            hostURL = ConfigurationManager.AppSettings["HostURL"];
        }
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            List<SkillsModel> model = new List<SkillsModel>();
            string msg = string.Empty;
            var data = string.Empty;
            string apiUrl = string.Format("{0}Login/GetSkills", hostURL);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<SkillsModel>>(data);
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skills"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Searchskills(int skillId = 0)
        {
            List<CandidateModel> model = new List<CandidateModel>();
            string msg = string.Empty;
            var data = string.Empty;
            string apiUrl = string.Format("{0}Login/GetAllCandidateFromSkillId/{1}", hostURL, skillId);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<CandidateModel>>(data);
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewSkills()
        {
            SkillsModel model = new SkillsModel();
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> NewSkills(SkillsModel model)
        {

            string msg = string.Empty;
            var data = string.Empty;
            string apiUrl = string.Format("{0}Login/InsertSkill", hostURL);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, model);
                data = await response.Content.ReadAsStringAsync();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CandidateDetails(int id = 0)
        {
            CandidateModel model = new CandidateModel();
            string msg = string.Empty;
            var data = string.Empty;
            string apiUrl = string.Format("{0}Login/GetCandidateById/{1}", hostURL, id);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                data = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<CandidateModel>(data);
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CandidateDetails(CandidateModel model)
        {

            string msg = string.Empty;
            var data = string.Empty;
            string apiUrl = string.Format("{0}Login/UpdateCandidateDetails", hostURL);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, model);
                data = await response.Content.ReadAsStringAsync();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}