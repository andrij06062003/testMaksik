using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using test.Models;

namespace test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JokesController : ControllerBase
{
   private readonly IJokesServices _jokesServices;

   public JokesController(IJokesServices _jokesServices) => this._jokesServices = _jokesServices;

   [HttpGet]
   public async Task<List<Jokes>> Get()
   {
      return await _jokesServices.JokesListAsync();
   }

   [HttpGet("{jokesId:length(24)}")]
   public async Task<ActionResult<Jokes>> GetById(string jokesId)
   {
      var jokesDetail = await _jokesServices.GetProductDetailByIdAsync(jokesId);
      if (jokesDetail == null)
      {
         return NotFound();
      }

      return Ok(jokesDetail);
   }

   [HttpPost]
   public async Task<IActionResult> Post(Jokes jokes)
   {
      await _jokesServices.AddJokesAsync(jokes);
      return CreatedAtAction(nameof(Get), new { id = jokes.Id }, jokes);
   }

   [HttpPut("{jokesId:length(24)}")]
   public async Task<IActionResult> Put(string jokesId, Jokes jokes)
   {
      var jokesDetails = await _jokesServices.GetProductDetailByIdAsync(jokesId);
      if (jokesDetails == null)
      {
         return NotFound();
      }

      jokes.Id = jokesDetails.Id;
      await _jokesServices.ReplaceJikesAsync(jokesId, jokesDetails);
      return Ok();
   }

   [HttpDelete("{jokesId:length(24)}")]
   public async Task<IActionResult> Delete(string jokesId)
   {
      var jokesDetails = await _jokesServices.GetProductDetailByIdAsync(jokesId);
      if (jokesDetails==null)
      {
         return NotFound();
         
      }

      await _jokesServices.DeleteJokesAsync(jokesId);
      return Ok();

   }







}