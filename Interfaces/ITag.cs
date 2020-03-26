using System.Collections.Generic;
using Keepr.Models;

namespace Keepr.Interfaces
{
  public interface ITag
  {
    int Id { get; set; }
    string Name { get; set; }
    string UserId { get; set; }
  }
}