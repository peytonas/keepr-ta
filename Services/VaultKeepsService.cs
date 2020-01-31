using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep Create(VaultKeep newVaultKeep, string userId)
    {
      newVaultKeep.UserId = userId;
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }
    public IEnumerable<Keep> Get(int vaultId, string userId)
    {
      return _repo.Get(vaultId, userId);
    }
    public string Delete(VaultKeep vaultKeep)
    {
      VaultKeep exists = _repo.GetId(vaultKeep.VaultId, vaultKeep.KeepId);
      if (exists == null) { throw new Exception("nothing here broh"); }
      _repo.Delete(exists.Id);
      return "it's gone broh";
    }
  }
}