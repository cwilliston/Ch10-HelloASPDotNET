using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" + 
                "<input type='text' name='name' />" +
                "<select name='language'><option value='english'>English</option><option value='french'>French</option><option value='hungarian'>Hungarian</option><option value='estonian'>Estonian</option><option value='dutch'>Dutch</option>" +
                "<input type ='submit' value='Greet Me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        //GET: /hello/welcome
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string language, string name = "World")
        {
            return Content($"<h1>{CreateMessage(language, name)}<h2>", "text/html");
        }

        public static string CreateMessage(string language, string name)
        {
            string message = "";
            
            switch (language)
            {
                case "english":
                    message = "Hello";
                    break;
                case "french":
                    message = "Bonjour";
                    break;
                case "hungarian":
                    message = "Szia";
                    break;
                case "estonian":
                    message = "Tere";
                    break;
                case "dutch":
                    message = "Hallo";
                    break;
                default:
                    message = "Hello";
                    break;

            }

            return message + ", " + name;
        }
    }
}
