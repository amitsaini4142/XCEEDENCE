using Newtonsoft.Json;
using RecruitmentSystemBusiness;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentSystemAPI.Controllers.api
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// The business data
        /// </summary>
        IBusinessData businessData = new BusinessData();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="_businessData"></param>
        //public LoginController(IBusinessData _businessData)
        //{
        //    businessData = _businessData;
        //}
        /// <summary>
        /// 
        /// </summary>
        public LoginController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployee")]
        public HttpResponseMessage GetEmployee(int employeeId)
        {
            var temp = this.businessData.GetData();
            if (employeeId == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Chirag");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Devashish");
            }
        }

        /// <summary>
        /// Gets the valid user.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ValidUser")]
        public HttpResponseMessage GetValidUser(LoginModel Model)
        {
            HttpResponseMessage response;
            if (Model == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, 0);
            }

            try
            {
                var detailsResponse = this.businessData.ValidUser(Model);
                if (detailsResponse != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertSkill")]
        public HttpResponseMessage AddSkill(SkillsModel model)
        {
            HttpResponseMessage response;
            if (model == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, 0);
            }
            try
            {

                var detailsResponse = this.businessData.InsertSkill(model);
                if (detailsResponse != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("GetSkills")]
        public HttpResponseMessage GetSkills()
        {
            HttpResponseMessage response;           
            try
            {

                var detailsResponse = this.businessData.FetchSkill();
                if (detailsResponse != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("SaveCandidate")]
        public HttpResponseMessage SaveCandidate(CandidateModel candidateModel)
        {
            HttpResponseMessage response;
            if (candidateModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Candidate model is null");
            }
            try
            {              
                var detailsResponse = this.businessData.InsertCandidate(candidateModel);
                if (detailsResponse != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllCandidateFromSkillId/{id}")]
        public HttpResponseMessage GetAllCandidateFromSkillId(int id)
        {
            HttpResponseMessage response;
            try
            {
                var detailsResponse = this.businessData.FetchAllCandidateFromSkillId(id);              
                if (detailsResponse != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("GetCandidateById/{id}")]
        public HttpResponseMessage GetCandidateById(int id)
        {
            HttpResponseMessage response;            
            try
            {
                var detailsResponse = this.businessData.FetchCandidateById(id);
                if (detailsResponse != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateCandidateDetails")]
        public HttpResponseMessage UpdateCandidateDetails(CandidateModel candidateModel)
        {
            if (candidateModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Candidate model is null");
            }
            HttpResponseMessage response;
            try
            {
                var detailsResponse = this.businessData.UpdateCandidate(candidateModel);
                if (detailsResponse != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("GetAllCandidate")]
        public HttpResponseMessage GetAllCandidate()
        {
            HttpResponseMessage response;

            try
            {
                var detailsResponse = this.businessData.FetchAllCandidate();
                if (detailsResponse != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, detailsResponse);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, detailsResponse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
