using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO keeps
        (id, name, description, userId, img, isPrivate, views, keeps, vaulted)
        VALUES
        (@Id, @Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Keeps, @Vaulted)";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }
    public IEnumerable<Keep> GetByUser(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }
    public Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    public void Edit(Keep newKeep)
    {
      string sql = "UPDATE keeps SET views = @Views, keeps = @Keeps, vaulted = @Vaulted WHERE id = @Id";
      _db.Execute(sql, newKeep);
    }
    public void Delete(int id, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @id AND userId = @userId";
      _db.Execute(sql, new { id, userId });
    }
  }
}