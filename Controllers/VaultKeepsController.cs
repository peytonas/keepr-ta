using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    private readonly VaultsService _vs;
    private readonly KeepsService _ks;
    public VaultKeepsController(VaultKeepsService vks, VaultsService vs, KeepsService ks)
    {
      _vks = vks;
      _vs = vs;
      _ks = ks;
    }

    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Get(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(vaultKeep, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut]
    public ActionResult<string> Delete([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        return Ok(_vks.Delete(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}