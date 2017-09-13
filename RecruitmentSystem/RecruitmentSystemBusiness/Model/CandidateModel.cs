using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystemBusiness
{
    /// <summary>
    /// 
    /// </summary>
    public class CandidateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public List<SkillList> SkillList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SkillList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFake { get; set; }
        public bool IsActive { get; set; }
    }
}
