using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using KpProjects.Api.Controllers.Base;
using KpProjects.Classes;
using KpProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace KpProjects.Api.Controllers
{
    public class KpProjectController : BaseController<KpProject>
    {
        public KpProjectController(KpProjectsContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> GetMembers(Guid id)
        {
            KpProject project = await _context.Projects
                .Include(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (project == null) return NotFound(id);

            return Ok(project.Members);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddMember(Guid id, Guid idPerson)
        {
            KpProject project = await _context.Projects.Include(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (project == null) return NotFound($"Project with id = {id}");
            if (project.Members.Any(x => x.Id == idPerson))
                return Conflict($"Person is member");

            Person person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == idPerson);
            if (person == null) return NotFound($"Person with id = {idPerson}");

            project.Members.Add(person);
            await _context.SaveChangesAsync();

            return Ok("Person is added");
        }

        [HttpGet]
        [Route("{id}/[action]")]
        public async Task<ActionResult> Milestones(Guid id)
        {
            KpProject project = await _context.Projects.Include(x => x.Milestones)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (project == null) return NotFound(id);

            return Ok(project.Milestones);
        }
    }
}
