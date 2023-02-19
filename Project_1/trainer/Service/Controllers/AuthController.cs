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


        //[EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpPost]
        public TokenClass post([FromBody] LoginClass loginClass)
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
                TokenClass token = new TokenClass();
                token.Token = authId;
                //return Ok($"Token : {authId}");
                return token;
            }
            else
            {
                TokenClass token = new TokenClass();
                token.Token = "0";
                return token;
                //return Ok("Wrong EmailId Or Password");
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
                    user1.EmailId = us.EmailId;
                    user1.Password = "";
                    user1.PhoneNo = us.PhoneNo;
                    user1.City = us.City;

                }

                return Ok(user1);
            }

            else
            {
                return Ok("SignUp Failed");
            }

        }

        [HttpGet("Education/{token}")]
        public IActionResult EducationList([FromRoute] string token)
        {
            //if (tokenClass.Token == authId)
            if (token == authId)
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

        [HttpGet("Skill")]
        public IActionResult SkillList([FromBody] TokenClass tokenClass)
        {
            if (tokenClass.Token == authId)
            {
                //EducationLogic ed = new EducationLogic();
                SkillLogic sk = new SkillLogic();
                var qq = sk.GetAll(UserIdRecieved);

                return Ok(qq);
            }
            else
            {
                return Ok($"Wrong Token Passed");
            }

        }

        [HttpPost("Skill/Add")]
        public IActionResult SkillAdd([FromBody] ASkillModel aSkillModel)
        {
            if (aSkillModel.Token == authId)
            {
                SkillLogic skillLogic = new SkillLogic();
                bool ql = skillLogic.Add(UserIdRecieved, aSkillModel);
                if (ql == true)
                {
                    return Created("Created Successfully", aSkillModel);
                }
                else
                {
                    return Ok("Unable to Create");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }

        [HttpDelete("Skill/Delete")]
        public IActionResult SkillDelete([FromBody] UserIdToken userIdToken)
        {
            if (userIdToken.Token == authId)
            {
                SkillLogic skillLogic = new SkillLogic();
                bool q = skillLogic.Delete(userIdToken.Id);
                if (q == true)
                {
                    return Ok("Skill deleted successfully");
                }
                else
                {
                    return Ok("Unable to delete");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }


        [HttpPut("Skill/Update")]
        public IActionResult SkillUpdate([FromBody] USkillModel uSkillModel)
        {
            if (uSkillModel.Token == authId)
            {
                SkillLogic skillLogic = new SkillLogic();
                bool q = skillLogic.Update(UserIdRecieved, uSkillModel);
                if (q == true)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return Ok("Unable to update");
                }

            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }

        [HttpGet("Company")]
        public IActionResult CompanyList([FromBody] TokenClass tokenClass)
        {
            if (tokenClass.Token == authId)
            {
                CompLogic compLogic = new CompLogic();
                var qq = compLogic.GetAll(UserIdRecieved);

                return Ok(qq);

            }
            else
            {
                return Unauthorized("Wrong Token Passed");
            }
        }



        [HttpPost("Company/Add")]
        public IActionResult CompAdd([FromBody] ACompModel aCompModel)
        {
            if (aCompModel.Token == authId)
            {
                CompLogic compLogic = new CompLogic();
                bool ql = compLogic.Add(UserIdRecieved, aCompModel);
                if (ql = true)
                {
                    return Created("Created Successfully", aCompModel);
                }
                else
                {
                    return Ok("Unable to create");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }


        [HttpDelete("Company/Delete")]
        public IActionResult CompDelete([FromBody] UserIdToken userIdToken)
        {
            if (userIdToken.Token == authId)
            {
                CompLogic compLogic = new CompLogic();
                bool q = compLogic.Delete(userIdToken.Id);
                if (q == true)
                {
                    return Ok("Company deleted successfully");
                }
                else
                {
                    return Ok("Unable to delete");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }


        [HttpPut("Company/Update")]
        public IActionResult CompUpdate([FromBody] UCompModel uCompModel)
        {
            if (uCompModel.Token == authId)
            {
                CompLogic compLogic = new CompLogic();
                bool q = compLogic.Update(UserIdRecieved, uCompModel);
                if (q == true)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return Ok("Unable to update");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }


        [HttpGet("Certification")]
        public IActionResult CertList([FromBody] TokenClass tokenClass)
        {
            if (tokenClass.Token == authId)
            {
                CertLogic certLogic = new CertLogic();
                var qq = certLogic.GetAll(UserIdRecieved);

                return Ok(qq);
            }
            else
            {
                return Unauthorized("Wrong Token Passed");
            }
        }


        [HttpPost("Certification/Add")]
        public IActionResult CertAdd([FromBody] ACertModel aCertModel)
        {
            if (aCertModel.Token == authId)
            {
                CertLogic certLogic = new CertLogic();
                bool ql = certLogic.Add(UserIdRecieved, aCertModel);
                if (ql == true)
                {
                    return Created("Created successfuly", aCertModel);

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


        [HttpDelete("Certification/Delete")]
        public IActionResult CertDelete([FromBody] UserIdToken userIdToken)
        {
            if (userIdToken.Token == authId)
            {
                CertLogic certLogic = new CertLogic();
                bool q = certLogic.Delete(userIdToken.Id);
                if (q == true)
                {
                    return Ok("Education deleted ");
                }
                else
                {
                    return Ok("Unable to delete");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }




        [HttpPut("Certification/Update")]
        public IActionResult CertUpdate([FromBody] UCertModel uCertModel)
        {
            if (uCertModel.Token == authId)
            {
                CertLogic certLogic = new CertLogic();
                bool q = certLogic.Update(UserIdRecieved, uCertModel);

                if (q == true)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return Ok("Unable to update");
                }
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }

        [HttpGet("GetAll/{token}")]
        public IActionResult GetAll([FromRoute] string token)
        {
            if (token == authId)
            {
                List<object> list = new List<object>();

                //Edu
                EducationLogic ed = new EducationLogic();
                var qq = ed.GetAll(UserIdRecieved);
                list.Add(qq);

                //Skill
                SkillLogic sk = new SkillLogic();
                var q1 = sk.GetAll(UserIdRecieved);
                list.Add(q1);

                //Comp
                CompLogic compLogic = new CompLogic();
                var q2 = compLogic.GetAll(UserIdRecieved);
                list.Add(q2);

                //Cert
                CertLogic certLogic = new CertLogic();
                var q3 = certLogic.GetAll(UserIdRecieved);
                list.Add(q3);

                //user details
                Login login = new Login();
                var q4 = login.getUser(UserIdRecieved);
                list.Add(q4);

                return Ok(list);
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }


        [HttpPost("Logout")]
        public IActionResult LogOut([FromBody] TokenClass tokenClass)
        {
            if (tokenClass.Token == authId)
            {
                authId = null;
                UserIdRecieved = 0;

                return Ok("Successfully Logged Out");
            }
            else
            {
                return Unauthorized("Wrong Token");
            }
        }




    }




}








