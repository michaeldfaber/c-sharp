namespace EFCoreDemo.Controllers
{
    using System.Linq;
    using EFCoreDemo.DbContext;
    using EFCoreDemo.EFModels;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILocalDbContext localDbContext;

        public ValuesController(ILocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        [HttpGet]
        [Route("/Persons/{id}")]
        public ActionResult<Person> Get(int id)
        {
            return localDbContext.Persons.Where(person => person.Id == id)?.FirstOrDefault();
        }
    }
}
