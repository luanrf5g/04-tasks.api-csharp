using System;
using Tasks.Communication.Enums;

namespace Tasks.Communication.Entities;

public class Task
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public Status Status { get; set; }
  public Priority Priority { get; set; }
  public DateTime LimitTime { get; set; }
}
