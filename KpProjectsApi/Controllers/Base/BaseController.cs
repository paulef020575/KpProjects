using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KpProjects.Classes;
using KpProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace KpProjects.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<TDataItem> : Controller
        where TDataItem : DataClass
    {
        protected KpProjectsContext _context;

        public BaseController(KpProjectsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TDataItem>> Index()
            => await _context.Set<TDataItem>().ToListAsync();

        [HttpPost]
        public virtual async Task<ActionResult> Create(TDataItem dataItem)
        {
            try
            { 
                _context.Set<TDataItem>().Add(dataItem);
                await _context.SaveChangesAsync();

                return Ok(dataItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult> Update(TDataItem dataItem)
        {
            try
            {
                TDataItem currentItem = _context.Set<TDataItem>().FirstOrDefault(x => x.Id == dataItem.Id);

                
                if (currentItem == null)
                    return NotFound(dataItem);
                _context.Remove(currentItem);
                _context.Update(dataItem);
                await _context.SaveChangesAsync();

                return Ok(dataItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            TDataItem item = _context.Set<TDataItem>().FirstOrDefault(x => x.Id == id);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpDelete]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            TDataItem item = _context.Set<TDataItem>().FirstOrDefault(x => x.Id == id);

            if (item == null) return NotFound();

            _context.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }
    }
}
