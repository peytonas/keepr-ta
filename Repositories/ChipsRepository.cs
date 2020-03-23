using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class ChipsRepository
  {
    private readonly IDbConnection _db;
    public ChipsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Chip newChip)
    {
      string sql = @"
        INSERT INTO chips
        (id, name, userId)
        VALUES
        (@Id, @Name, @UserId)";
      return _db.ExecuteScalar<int>(sql, newChip);
    }

    public IEnumerable<Chip> Get()
    {
      string sql = "SELECT * FROM chips";
      return _db.Query<Chip>(sql);
    }

    public Chip Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Chip>(sql, new { id });
    }

    public void Delete(int id, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id, userId });
    }
  }
}