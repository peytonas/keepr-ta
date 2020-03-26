using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class TagsRepository
  {
    private readonly IDbConnection _db;
    public TagsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Tag newTag)
    {
      string sql = @"
        INSERT INTO Tags
        (id, name, userId)
        VALUES
        (@Id, @Name, @UserId)";
      return _db.ExecuteScalar<int>(sql, newTag);
    }
    public IEnumerable<Tag> Get()
    {
      string sql = "SELECT * FROM tags";
      return _db.Query<Tag>(sql);
    }

    public Tag Get(int id)
    {
      string sql = "SELECT * FROM tags WHERE id = @id";
      return _db.QueryFirstOrDefault<Tag>(sql, new { id });
    }

    public void Delete(int id, string userId)
    {
      string sql = "DELETE FROM tags WHERE id = @id AND userId = @userId";
      _db.Execute(sql, new { id, userId });
    }
  }
}