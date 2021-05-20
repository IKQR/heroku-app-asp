using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HerokuApplication.Dal;
using HerokuApplication.Dal.Entity;

namespace HerokuApplication.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeuralLearnMasksController : ControllerBase
    {
        private readonly NeuralDbContext _context;

        public NeuralLearnMasksController(NeuralDbContext context)
        {
            _context = context;
        }

        // GET: api/NeuralLearnMasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NeuralLearnMask>>> GetNeuralLearnMasks()
        {
            return await _context.NeuralLearnMasks.Skip(0).Take(2).ToListAsync();
        }

        //// GET: api/NeuralLearnMasks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<NeuralLearnMask>> GetNeuralLearnMask(int id)
        //{
        //    var neuralLearnMask = await _context.NeuralLearnMasks.FindAsync(id);

        //    if (neuralLearnMask == null)
        //    {
        //        return NotFound();
        //    }

        //    return neuralLearnMask;
        //}

        //// PUT: api/NeuralLearnMasks/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNeuralLearnMask(int id, NeuralLearnMask neuralLearnMask)
        //{
        //    if (id != neuralLearnMask.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(neuralLearnMask).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NeuralLearnMaskExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/NeuralLearnMasks
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<NeuralLearnMask>> PostNeuralLearnMask(NeuralLearnMask neuralLearnMask)
        //{
        //    _context.NeuralLearnMasks.Add(neuralLearnMask);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetNeuralLearnMask", new { id = neuralLearnMask.Id }, neuralLearnMask);
        //}

        //// DELETE: api/NeuralLearnMasks/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<NeuralLearnMask>> DeleteNeuralLearnMask(int id)
        //{
        //    var neuralLearnMask = await _context.NeuralLearnMasks.FindAsync(id);
        //    if (neuralLearnMask == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.NeuralLearnMasks.Remove(neuralLearnMask);
        //    await _context.SaveChangesAsync();

        //    return neuralLearnMask;
        //}

        //private bool NeuralLearnMaskExists(int id)
        //{
        //    return _context.NeuralLearnMasks.Any(e => e.Id == id);
        //}
    }
}
