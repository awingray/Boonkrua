using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Models.Error.Notifications;

public sealed record NotificationConfigError : AError
{
    private NotificationConfigError(string errorMessage)
        : base(errorMessage) { }

    public static NotificationConfigError NotFound => new(NotificationMessages.ConfigNotFound);
}
