using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystemBusiness
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessData : IBusinessData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetData()
        {
            return 1;
        }

        /// <summary>
        /// Gets the valid user.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        public int ValidUser(LoginModel Model)
        {
            if ((Model.UserName == "Admin" || Model.UserName == "User") && (Model.Password == "123"))
            {
                if (Model.UserName == "Admin")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSkill(SkillsModel model)
        {
            if (model == null)
            {
                return 0;
            }
            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var path = JsonFilePath + "t_skills.json";

            var jsonData = System.IO.File.ReadAllText(path);
            var lstSkillsModel = JsonConvert.DeserializeObject<List<SkillsModel>>(jsonData) ?? new List<SkillsModel>(); 

            lstSkillsModel.Add(new SkillsModel()
            {
                Id = lstSkillsModel.Count() + 1,
                Name = model.Name,
                IsActive = true
            });
            jsonData = JsonConvert.SerializeObject(lstSkillsModel);
            System.IO.File.WriteAllText(path, jsonData);
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<SkillsModel> FetchSkill()
        {
            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var path = JsonFilePath + "t_skills.json";
            var jsonData = System.IO.File.ReadAllText(path);
            var lstSkillsModel = JsonConvert.DeserializeObject<List<SkillsModel>>(jsonData) ?? new List<SkillsModel>();
            return lstSkillsModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateModel"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public int InsertCandidate(CandidateModel candidateModel)
        {
            try
            {
                if (candidateModel == null)
                {
                    return 0;
                }
                var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
                var path = JsonFilePath + "t_candidates.json";
                var jsonCandidate = System.IO.File.ReadAllText(path);
                List<CandidateModel> lstCandidate;
                if (string.IsNullOrEmpty(jsonCandidate) || string.IsNullOrWhiteSpace(jsonCandidate))
                {
                    lstCandidate = new List<CandidateModel>();
                    lstCandidate.Add(candidateModel);
                }
                else
                {
                    var lstCandidateCount = FetchAllCandidate().ToList();

                    lstCandidate = JsonConvert.DeserializeObject<List<CandidateModel>>(jsonCandidate);
                    candidateModel.Id = lstCandidateCount.Count() + 1;
                    candidateModel.IsActive = true;
                    lstCandidate.Add(candidateModel);
                }

                string jsonString = JsonConvert.SerializeObject(lstCandidate);

                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path))
                {

                    file.WriteLine(jsonString);
                }
                return 1;
            }
            catch (Exception ex) { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<CandidateModel> FetchAllCandidateFromSkillId(int skillId)
        {
            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var path = JsonFilePath + "t_candidates.json";
            string text = System.IO.File.ReadAllText(path);
            var lstCandidateModel = JsonConvert.DeserializeObject<List<CandidateModel>>(text);
            List<CandidateModel> lstCandidateModelSkillWise = lstCandidateModel.FindAll(x => x.SkillList.Any(m => m.Id == skillId && m.IsFake==false));
            return lstCandidateModelSkillWise;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public CandidateModel FetchCandidateById(int Id)
        {
            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var path = JsonFilePath + "t_candidates.json";
            string text = System.IO.File.ReadAllText(path);
            var lstCandidateModel = JsonConvert.DeserializeObject<List<CandidateModel>>(text);
            CandidateModel CandidateModelIdWise = lstCandidateModel.Where(x => x.Id == Id).FirstOrDefault();
            return CandidateModelIdWise;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateModel"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public int UpdateCandidate(CandidateModel candidateModel)
        {

            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var path = JsonFilePath + "t_candidates.json";
            string jsonCandidate = System.IO.File.ReadAllText(path);
            List<CandidateModel> lstCandidate;
            if (string.IsNullOrEmpty(jsonCandidate) || string.IsNullOrWhiteSpace(jsonCandidate))
            {
                return 0;
            }
            else
            {
                lstCandidate = JsonConvert.DeserializeObject<List<CandidateModel>>(jsonCandidate);
                CandidateModel candidateModel1 = lstCandidate.Find(x => x.Id == candidateModel.Id);
                lstCandidate.Remove(candidateModel1);
                lstCandidate.Add(candidateModel);
            }

            string jsonString = JsonConvert.SerializeObject(lstCandidate);

            using (System.IO.StreamWriter file =new System.IO.StreamWriter(path))
            {

                file.WriteLine(jsonString);
            }
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CandidateModel> FetchAllCandidate()
        {
            var JsonFilePath = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["JsonFile"]);
            var t_candidatesPath = JsonFilePath + "t_candidates.json";
            string text = System.IO.File.ReadAllText(t_candidatesPath);
            var lstCandidateModel = JsonConvert.DeserializeObject<List<CandidateModel>>(text);
            List<CandidateModel> lstCandidate = lstCandidateModel.ToList();
            return lstCandidate;
        }
    }
}
