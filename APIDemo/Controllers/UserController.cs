using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_Select_All_User();

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpGet("{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.PR_SelectByPK_User(UserID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (UserID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase bal = new User_BALBase();
            int delete = bal.PR_Delete_User(UserID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (delete == 1)
            {
                response.Add("status", true);
                response.Add("message", "Delete Record.");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "No Data Found.");
                return NotFound(response);
            }
        }

        [HttpPost()]
        public IActionResult Post(UserModel user)
        {
            User_BALBase bal = new User_BALBase();

            int insert = bal.PR_Insert_User(user);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (insert == 1)
            {
                response.Add("status", true);   
                response.Add("message", "Insert Successfull.");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Insert.");
                return NotFound(response);
            }
        }

        [HttpPut]
        public IActionResult Put(UserModel user)
        {
            User_BALBase bal = new User_BALBase();

            int update = bal.PR_Update_User(user);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (update == 1)
            {
                response.Add("status", true);
                response.Add("message", "Update Successfull.");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Update.");
                return NotFound(response);
            }
        }

        [HttpGet("{UserName},{Email}")]
        public IActionResult Filter(String Username, String? Email)
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_Filter_User(Username, Email);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (users.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
    }
}
