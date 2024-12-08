using Boonkrua.Service.Models.Error.Topics;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces.Topics;

public interface ITopicNotificationService
{
    Task<Result<Message, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
