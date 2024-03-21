using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SSE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SSEController : ControllerBase
    {
        [HttpGet]
        public async Task Home()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            while (true)
            {
                var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                byte[] data = Encoding.UTF8.GetBytes(currentTime + "\n");

                await Response.Body.WriteAsync(data, 0, data.Length);

                await Task.Delay(1000);
            }
        }
    }
}
