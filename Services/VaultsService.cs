using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public Vault Create(Vault newVault, string userId) //STUB CREATE VAULT WORKS
    {
      newVault.UserId = userId;
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }
    public IEnumerable<Vault> GetByUser(string userId) //STUB GET VAULTS BY USER ID WORKS
    {
      return _repo.Get(userId);
    }
    public Vault Get(int vaultId, string userId) //STUB GET VAULT BY VAULT ID WORKS
    {
      Vault exists = _repo.GetById(vaultId);
      if (exists == null) { throw new Exception("doesn't exist broh"); }
      if (exists.UserId != userId) { throw new Exception("doesn't belong to you, monkey"); }
      return exists;
    }
    [Authorize]
    public string Delete(int id, string userId) //STUB DELETE VAULT WORKS
    {
      Vault exists = _repo.GetById(id);
      if (exists == null || exists.UserId != userId) { throw new Exception("doesn't exist broh"); }
      _repo.Delete(id);
      return "it's gone, Jim";
    }
  }
}