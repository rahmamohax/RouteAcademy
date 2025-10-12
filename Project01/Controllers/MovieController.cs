using Microsoft.AspNetCore.Mvc;
using Project01.Models;
namespace Project01.Controllers
{
    public class MovieController : Controller
    {
        public string Index(int id)
        {
            return string.Empty;
        }

        [HttpGet]
        //Get BaseUrl/Movie/GetMovie?id=XX&name=XX      <= query request
        public ActionResult GetMovie(int? id, string name)
        {
            //ContentResult result = new ContentResult();
            //result.Content = $"<h1>Movie name is {name}</h1>";
            //result.ContentType = "text/html";

            if (id == null || id == 0) return new BadRequestResult();
            if (id < 10) return NotFound();
            return Content($"<h1>Movie id {id} and name is {name}</h1>", "text/html");

        }

        [HttpGet]
        public IActionResult amazon(int id)
        {

            //return RedirectToAction("GetMovie", new { Controller = "Movie", Action = "GetMovie" });
            //return RedirectToAction("GetMovies"); // Use it When The Action In The Same Cnotroller use the name of the action
            //return RedirectToAction(nameof(GetMovie), "Movies",new {id=15,name="test" }); // Use it When The Action In The Different Cnotroller use the name of the action and the controller
            return Redirect("https://www.amazon.com");

        }

        [HttpPost]
        //form > route > query > body > header
        public ActionResult ModelBindeing([FromRoute] int id, [FromQuery] string name)
        {
            return Content($"Hello {name} Your Id is {id}", "text/html");
        }

        //Complex
       [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie) //doesnt bing automatically from body
        {
            return Content($"Hello {movie.Title} Your Id Is {movie.Id}");
        }

        //Simple
        [HttpPost]
        public IActionResult AddMovie([FromHeader] int Id, [FromHeader] string Title)
        {
            return Content($"Hello {Title} Your Id Is {Id}");
        }

        //Mix
        public IActionResult AddMovie([FromHeader] int Id, Movie movie, [FromHeader] string Title)
        {
            return Content($"Hello {Title} Your Id Is {Id}");
        }

        //Collection
        public IActionResult AddMovie(int[] arr)
        {
            return Content($"Hello {arr[0]} Your Id Is {arr[1]}");
        }
    }
}
