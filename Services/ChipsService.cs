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
      newChip.UserId = userId;
      int id = _repo.Create(newChip);
      newChip.Id = id;
      return newChip;
    }

    public IEnumerable<Chip> Get()
    {
      return _repo.Get();
    }

    public Chip Get(int id)
    {
      Chip exists = _repo.Get(id);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      return exists;
    }

    public string Delete(int id, string userId)
    {
      Chip exists = _repo.Get(id);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      _repo.Delete(id, userId);
      return "it's gone, Jim";
    }
  }
}