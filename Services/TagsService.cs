using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Services
{
  public class TagsService
  {
    private readonly TagsRepository _repo;
    public TagsService(TagsRepository repo)
    {
      _repo = repo;
    }
    public Tag Create(Tag newTag, string userId)
    {
      newTag.UserId = userId;
      int id = _repo.Create(newTag);
      newTag.Id = id;
      return newTag;
    }

    public IEnumerable<Tag> Get()
    {
      return _repo.Get();
    }
    public Tag Get(int id)
    {
      Tag exists = _repo.Get(id);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      return exists;
    }

    public string Delete(int id, string userId)
    {
      Tag exists = _repo.Get(id);
      if (exists == null || exists.UserId != userId) { throw new Exception("doesn't exist broh"); }
      _repo.Delete(id, userId);
      return "it's gone, Jim";
    }
  }
}