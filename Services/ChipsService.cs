using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Services
{
  public class ChipsService
  {
    private readonly ChipsRepository _repo;
    public ChipsService(ChipsRepository repo)
    {
      _repo = repo;
    }
    public Chip Create(Chip newChip, string userId)
    {
      string Name = _repo.Create(newChip);
      return newChip;
    }

    public IEnumerable<Chip> Get()
    {
      return _repo.Get();
    }

    public Chip Get(string name)
    {
      Chip exists = _repo.Get(name);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      return exists;
    }

    public string Delete(string name)
    {
      Chip exists = _repo.Get(name);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      _repo.Delete(name);
      return "it's gone, Jim";
    }
  }
}