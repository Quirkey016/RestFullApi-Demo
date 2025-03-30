using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerRestFullApi.Models;

namespace ProjectTrackerRestFullApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartController : Controller
    {
        private static Cart _cart = new Cart();



        //get the whole list
        [HttpGet()]
        public IActionResult Index()
        {
            return Ok(_cart.Projects);
        }
        


    //get just a specific project from an id
        [HttpGet("{Id}")]
        public IActionResult Index(int Id)
        {
            var cart = _cart.Projects.FirstOrDefault(x => x.Id == Id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(_cart);
        }



        // put a project into the list
        [HttpPost()]
        public IActionResult Post([FromBody] ProjectTracker newProject) 
            {
                if (_cart.Projects.Any(x=> x.Id == newProject.Id)) 
                {
                    return BadRequest();
                }

                _cart.Projects.Add(newProject);
                return Ok();
        }



        //update a project in the list
        [HttpPut("{Update}")]
        public IActionResult Put(int Id, [FromBody] ProjectTracker updatedProject) 
        { 
            var existingItem = _cart.Projects.FirstOrDefault(x=> x.Id == Id);

            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.projectNumber = updatedProject.projectNumber;
            existingItem.projectName = updatedProject.projectName;
            existingItem.completionPercent = updatedProject.completionPercent;

            return Ok();
        }



        //delete a project from the list
        [HttpDelete()]
        public IActionResult Delete(int Id) 
        {
            var item = _cart.Projects.FirstOrDefault(x=>x.Id == Id);
            if (item==null)
            {
                return NotFound();
            }
            _cart.Projects.Remove(item);
            return Ok();
        }
    }
}
