using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ChipsController : ControllerBase
  {
    private readonly ChipsService _cs;
    public ChipsController(ChipsService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Chip>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Chip> Create([FromBody] Chip newChip)
    {
      try
      {
        string name = HttpContext.User.FindFirstValue("Name");
        return Ok(_cs.Create(newChip, name));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{name}")]
    public ActionResult<Keep> Get(string name)
    {
      try
      {
        return Ok(_cs.Get(name));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{name}")]
    public ActionResult<string> Delete(string name)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Name");
        return Ok(_cs.Delete(name));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}