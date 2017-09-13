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

namespace RecruitmentSystemPresentation.Controllers.User
{
    public class CandidateController : Controller
    {
            string hostURL = string.Empty;
            public CandidateController()
            {
                hostURL = ConfigurationManager.AppSettings["HostURL"];
            }
            // GET: Candidate
            [HttpGet]
            public async Task<ActionResult> Index()
            {
                CandidateModel model = new CandidateModel();

                //List<SkillsModel> model = new List<SkillsModel>();
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
                    model.SkillList = JsonConvert.DeserializeObject<List<SkillList>>(data);
                }
                return View(model);
            }
            [HttpPost]
            public async Task<ActionResult> Index(CandidateModel model, string skill)
            {
                string msg = string.Empty;
                var data = string.Empty;
                
                    string apiUrl = string.Format("{0}Login/SaveCandidate", hostURL);
                    var skillList = new List<SkillList>();
                    if (!string.IsNullOrEmpty(skill))
                    {
                        skillList = JsonConvert.DeserializeObject<List<SkillList>>(skill);
                    }
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        model.SkillList = skillList;

                        HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, model);
                        data = await response.Content.ReadAsStringAsync();
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }

            }
    }
}