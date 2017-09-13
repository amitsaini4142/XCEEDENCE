using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystemBusiness
{
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Display(Name = "User Name")]
        public string UserName { get; set; }       
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }       
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
       /// <summary>
       /// 
       /// </summary>
        public LoginModel()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginModel"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="password">The password.</param>
        public LoginModel(string userName, string userEmail, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
