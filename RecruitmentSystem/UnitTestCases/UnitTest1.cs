using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitmentSystemBusiness;
using System.Configuration;

namespace UnitTestCases
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ValidUserTest()
        {
            LoginModel model = new LoginModel
            {
                UserName = "Admin",
                Password = "123"
            };
            int expected = 1;

            var obj = new BusinessData();
            int actualresult = obj.ValidUser(model);
            Assert.AreEqual(expected, actualresult, "Login Successfully");
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void InValidUserTest()
        {
            LoginModel model = new LoginModel
            {
                UserName = "Admin",
                Password = "123456"
            };
            int expected = 0;

            var obj = new BusinessData();
            int actualresult = obj.ValidUser(model);
            Assert.AreEqual(expected, actualresult, "Login Failed");
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //[TestMethod]
        //public void InsertSkillTest()
        //{
        //    SkillsModel model = new SkillsModel
        //    {
        //        Name = "TestSkill"
        //    };
        //    int expected = 1;

        //    var obj = new BusinessData();
        //    int actualresult = obj.InsertSkill(model);
        //    Assert.AreEqual(expected, actualresult, "Insert Skill Successfully");
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //[TestMethod]
        //public void InsertSkillFailedTest()
        //{
        //    SkillsModel model = new SkillsModel();
        //    int expected = 0;

        //    var obj = new BusinessData();
        //    int actualresult = obj.InsertSkill(model);
        //    Assert.AreEqual(expected, actualresult, "Insert Skill Failed");
        //} 
    }
}
