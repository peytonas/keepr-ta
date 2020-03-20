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
    public string Create(Chip newChip)
    {
      string sql = @"
        INSERT INTO chips
        (name)
        VALUES
        (@Name)";
      return _db.ExecuteScalar<string>(sql, newChip);
    }

    public IEnumerable<Chip> Get()
    {
      string sql = "SELECT * FROM chips";
      return _db.Query<Chip>(sql);
    }

    public Chip Get(string name)
    {
      string sql = "SELECT * FROM keeps WHERE name = @name";
      return _db.QueryFirstOrDefault<Chip>(sql, new { name });
    }

    public void Delete(string name)
    {
      string sql = "DELETE FROM keeps WHERE name = @name";
      _db.Execute(sql, new { name });
    }
  }
}