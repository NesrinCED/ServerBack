using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DataContxt;
using Server.models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ContextApp _context;

        public TemplateController(ContextApp context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Template>>> GetTemplates()
        {
            return Ok(await _context.templates.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTemplate([FromRoute] Guid id)
        {
            var template= await _context.templates.FirstOrDefaultAsync(x => x.Id == id);
            if (template == null)  
            {
                return NotFound();
            }
            

            return Ok(template);
        }

        /* [HttpPost]
         public async Task<ActionResult<List<Template>>> CreateTemplate([FromBody] Template templateRequest)
         {
             templateRequest.Id=Guid.NewGuid(); 
             await _context.templates.AddAsync(templateRequest);
             await _context.SaveChangesAsync();
             return Ok(await _context.templates.ToListAsync());
         }*/
        [HttpPost]
        public async Task<ActionResult> CreateTemplate([FromBody] Template templateRequest)
        {
            templateRequest.Id = Guid.NewGuid();
            await _context.templates.AddAsync(templateRequest);
            await _context.SaveChangesAsync();
            return Ok(templateRequest);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTemplate([FromRoute] Guid id,Template template)
        {
            var dbTemplate = await _context.templates.FindAsync(id);
            if (dbTemplate == null)
            {
                return BadRequest("Template Not Found !!!");
            }
            dbTemplate.Language = template.Language;
            dbTemplate.Name = template.Name;
            dbTemplate.ModifiedDate = DateTime.Now;
            dbTemplate.Content = template.Content;
            dbTemplate.CreatedBy = template.CreatedBy;
            dbTemplate.ModifiedBy = template.ModifiedBy;
            dbTemplate.Project = template.Project;


            await _context.SaveChangesAsync();
            return Ok(dbTemplate);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTemplate([FromRoute] Guid id)
        {
            var dbTemplate = await _context.templates.FindAsync(id);
            if (dbTemplate == null)
            {
                return BadRequest("Template Not Found !!!");
            }

            _context.Remove(dbTemplate);
            await _context.SaveChangesAsync();
            return Ok(dbTemplate);
        }
    }
}
