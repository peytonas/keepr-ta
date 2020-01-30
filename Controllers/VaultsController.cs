using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace keepr2.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault newVault) //STUB CREATE VAULT WORKS
    {
      try
      {
        string id = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetByUser() //STUB GET VAULTS BY USER ID
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.GetByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultId}")]
    public ActionResult<Vault> Get(int vaultId, string userId) //STUB GET VAULT BY VAULT ID WORKS
    {
      try
      {
        string user = HttpContext.User.FindFirstValue("Id"); //NOTE check this
        return Ok(_vs.Get(vaultId, user));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{vaultId}")]
    public ActionResult<string> Delete(int vaultId) //STUB DELETE WORKS
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Delete(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}