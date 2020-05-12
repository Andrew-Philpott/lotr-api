using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lotr.Entities;
using Lotr.Models;
using Lotr.Helpers;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace Lotr.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ApiController : ControllerBase
  {
    private IMapper _mapper;
    private readonly ILogger<ApiController> _logger;
    private readonly LotrContext _db;
    public ApiController(LotrContext db, ILogger<ApiController> logger, IMapper mapper)
    {
      _mapper = mapper;
      _logger = logger;
      _db = db;
    }

    [HttpGet("characters")]
    public async Task<IActionResult> GetAll()
    {
      IEnumerable<Character> model = await _db.Characters.ToListAsync();
      return Ok(model);
    }

    [HttpGet("characters/{id}")]
    public async Task<IActionResult> Get(int id)
    {
      Character model = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
      return Ok(model);
    }
    [HttpPost("characters")]
    public async Task<IActionResult> CreateCharacter([FromBody] CreateCharacter model)
    {
      try
      {
        if (model == null)
        {
          return BadRequest("Beer object is null");
        }
        if (!ModelState.IsValid)
        {
          return BadRequest("Invalid model object");
        }

        Character entity = _mapper.Map<Character>(model);
        await _db.Characters.AddAsync(entity);
        await _db.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Error in CreateCharacter action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }

    }

    [HttpPut("characters/{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, [FromBody] UpdateCharacter model)
    {
      try
      {
        if (model == null)
        {
          _logger.LogError("Character object sent from client is null.");
          return BadRequest("Character object is null");
        }

        if (!ModelState.IsValid)
        {
          _logger.LogError("Invalid Character object sent from client.");
          return BadRequest("Invalid model object");
        }

        Character entity = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
        {
          _logger.LogError($"Character with id: {id}, hasn't been found in db.");
          return NotFound();
        }

        _mapper.Map(model, entity);
        _db.Characters.Update(entity);
        await _db.SaveChangesAsync();

        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside UpdateCharacter action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Character model = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
      if (model == null)
      {
        return NotFound();
      }
      _db.Characters.Remove(model);
      await _db.SaveChangesAsync();
      return Ok();
    }
  }
}
