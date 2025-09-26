using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {

            // اگر FluentValidation خطایی پیدا کنه خودش BadRequest برمی‌گردونه
            return Ok(new { message = "کاربر با موفقیت ایجاد شد", data = user });
        }
    }
}
