using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private string? authId;
        public string AuthId
        {
            set
            {
                authId = value;
            }
            get
            {
                if (authId == null)
                {
                    return "AuthFail";
                }
                else
                {
                    return authId;
                }
            }
        }

        [HttpPost]
        public IActionResult post([FromBody] LoginClass loginClass)
        {
            Login login = new Login();

            bool res = login.LoginSubmit(loginClass.EmailID, loginClass.Password);

            if (res)
            {
                string tk = TokenGenerator.TokenGeneratorToken();
                AuthId = tk;
                return Ok($"Token : {tk} ");
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

    }



    /// <summary>
    /// To generate tokens
    /// </summary>
    //public static class TokenGenerator
    //{

    //    public static string TokenGeneratorToken()
    //    {
    //        Random rnd = new Random();
    //        string[] words = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    //        string generatedToken = $"{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}";

    //        return generatedToken;

    //    }
    //}
}

