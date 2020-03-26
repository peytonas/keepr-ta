using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagsController : ControllerBase
  {
    private readonly TagsService _ts;
    public TagsController(TagsService ts)
    {
      _ts = ts;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Tag>> Get()
    {
      try
      {
        return Ok(_ts.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Tag> Create([FromBody] Tag newTag)
    {
      try
      {
        string id = HttpContext.User.FindFirstValue("Id");
        return Ok(_ts.Create(newTag, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Tag> Get(int id)
    {
      try
      {
        return Ok(_ts.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ts.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}