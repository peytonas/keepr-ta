using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public Keep Create(Keep newKeep, string userId)
    {
      newKeep.UserId = userId;
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public IEnumerable<Keep> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      return exists;
    }
    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.Get(editKeep.Id);
      if (keep == null) { throw new Exception("doesn't exist broh"); }
      keep.Views = editKeep.Views;
      _repo.Edit(keep);
      return keep;
    }
    public string Delete(int id, string userId)
    {
      Keep exists = _repo.Get(id);
      if (exists == null || exists.UserId != userId) { throw new Exception("doesn't exist broh"); }
      _repo.Delete(id, userId);
      return "it's gone, Jim";
    }
  }
}