using Tasks.Communication.Enums;

namespace Tasks.Communication.Responses;

public class ResponseShortTaskJson
{
  public string Title { get; set; } = string.Empty;
  public DateTime LimitTime { get; set; }
  public Priority Priority { get; set; }
}
