using KpProjects.Api.Controllers.Base;
using KpProjects.Classes;
using KpProjects.Data;
using Microsoft.AspNetCore.Mvc;

namespace KpProjects.Api.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(KpProjectsContext context) : base(context)
        {
        }
    }
}
