using Microsoft.AspNetCore.Mvc;
using Store.Core.DTO;
using System;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route ("api/[controller]")]
    public class ContactController : Controller
    {
        [HttpPost ("")]
        public async Task<IActionResult> Post ([FromBody] ContactDTO contact) {
            
             return NoContent();
        }
    }
}