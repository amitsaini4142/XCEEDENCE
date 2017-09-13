using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystemBusiness
{
    public interface IBusinessData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetData();

        /// <summary>
        /// Gets the valid user.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        int ValidUser(LoginModel Model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        int InsertSkill(SkillsModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<SkillsModel> FetchSkill();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateModel"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        int InsertCandidate(CandidateModel candidateModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        List<CandidateModel> FetchAllCandidateFromSkillId(int skillId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        CandidateModel FetchCandidateById(int Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateModel"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        int UpdateCandidate(CandidateModel candidateModel);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<CandidateModel> FetchAllCandidate();
    }
}
