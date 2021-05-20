using HerokuApplication.Dal;
using HerokuApplication.Dal.Entity;
using HerokuApplication.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerokuApplication.Web.Model;

namespace HerokuApplication.Web.Controllers.Api
{
    [Route("api/NeuralLearnMasks")]
    [SecretKeyAuth]
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
        [Route("{percentage}")]
        public async Task<IEnumerable<NeuralLearnMaskGetDto>> GetNeuralLearnMasks([FromRoute]double percentage = 0.2)
        {
            return await _context.NeuralLearnMasks
                .OrderBy(x => x.BadAccuracyPercentage)
                .ThenBy(x => x.GoodAccuracyPercentage)
                .Where(x => x.BadAccuracyPercentage >= percentage && x.GoodAccuracyPercentage >= percentage)
                .Select(x => new NeuralLearnMaskGetDto
                {
                    Id = x.Id,
                    Symbol = x.Symbol,
                    BadAccuracyPercentage = x.BadAccuracyPercentage,
                    GoodAccuracyPercentage = x.GoodAccuracyPercentage,
                })
                .ToListAsync();
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
