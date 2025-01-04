using System;

namespace Tasks.Communication.Responses;

public class ResponseFetchTasksJson
{
  public List<ResponseShortTaskJson> Tasks { get; set; } = [];
}
