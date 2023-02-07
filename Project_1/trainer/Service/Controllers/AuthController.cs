using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //For saving User Id
        public static int UserIdRecieved;
        //For saving tokens
        public static string authId;
        public string AuthId { get; set; }

        [HttpPost]
        public IActionResult post([FromBody] LoginClass loginClass)
        {
            Login login = new Login();

            int res = login.LoginSubmit(loginClass.EmailID, loginClass.Password);
            UserIdRecieved = res;
            if (res > 0)
            {
                //string tk = TokenGenerator.TokenGeneratorToken();
                authId = TokenGenerator.TokenGeneratorToken();
                //AuthId = tk;
                //authId = tk;
                return Ok($"Token : {authId} {UserIdRecieved}");
            }
            else
            {

                return Ok("Wrong EmailId Or Password");
            }
        }

        [HttpPost("SignUp")]
        public IActionResult SignupPost([FromBody] UserModel user)
        {
            Login login = new Login();
            int i = login.SignUpSubmit(user);
            UserModel user1 = new UserModel();
            if (i > 0)
            {
                var q = login.SignUpUser();
                foreach (DataEf.Entities.User us in q)
                {

                    user1.FirstName = us.FirstName;
                    user1.LastName = us.LastName;
                    user1.EmailId = us.Password;
                    user1.Password = "";
                    user1.PhoneNo = us.PhoneNo;

                }

                return Ok(user1);
            }

            else
            {
                return Ok("SignUp Failed");
            }

        }

        [HttpGet("Education")]
        public IActionResult EducationList([FromBody] TokenClass tokenClass)
        {
            if (tokenClass.Token == authId)
            {
                EducationLogic ed = new EducationLogic();
                var qq = ed.GetAll(UserIdRecieved);

                return Ok(qq);
            }
            else
            {
                return Ok($"Wrong Token Passed");
            }

        }

        [HttpPost("Education/Add")]
        public IActionResult EducationAdd([FromBody] AEduModel aEduModel)
        {
            if (aEduModel.Token == authId)
            {
                EducationLogic education = new EducationLogic();
                bool ql = education.Add(UserIdRecieved, aEduModel);

                if (ql == true)
                {
                    return Created("Created Successfully", aEduModel);
                }
                else
                {
                    return Ok("Unable to Create");
                }
            }
            else
            {
                return Ok("Wrong Token");
            }
        }

        [HttpDelete("Education/Delete")]
        public IActionResult EducationDelete([FromBody] UserIdToken userIdToken)
        {
            if (userIdToken.Token == authId)
            {
                EducationLogic education = new EducationLogic();
                bool q = education.Delete(userIdToken.Id);

                if (q == true)
                {
                    return Ok("Education deleted successfully");
                }
                else
                {
                    return Ok("Unable to delete");
                }
            }
            else
            {
                return Ok("Wrong Token");
            }
        }

        [HttpPut("Education/Update")]
        public IActionResult EducationUpdate([FromBody] UEduModel uEduModel)
        {
            if (uEduModel.Token == authId)
            {
                EducationLogic educationLogic = new EducationLogic();
                bool q = educationLogic.Update(UserIdRecieved, uEduModel);

                if (q == true)
                {
                    return Ok("Updated Sucessfully");
                }
                else
                {
                    return Ok("Unable to update");
                }


            }
            else
            {
                return Ok("Wrong Token");
            }
        }

    }




}

