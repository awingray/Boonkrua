using Boonkrua.Constants;
using Boonkrua.Enums;

namespace Boonkrua.Models.Error;

public record TopicError(TopicErrorCode Code, string Message)
{
    public static TopicError NullId => new(TopicErrorCode.NullId, TopicMessages.NullId);
    public static TopicError NotFound => new(TopicErrorCode.NotFound, TopicMessages.NotFound);
}
