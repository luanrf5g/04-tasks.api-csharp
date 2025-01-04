using System;
using Tasks.Communication.Enums;

namespace Tasks.Communication.Requests;

public class RequestUpdateTaskJson
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public Status Status { get; set; }
  public Priority Priority { get; set; }
}
