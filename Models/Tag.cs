using System.Collections.Generic;
using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Tag : ITag
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
  }
}