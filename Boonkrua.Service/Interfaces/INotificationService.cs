using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Models.Error.Notifications;

namespace Boonkrua.Service.Interfaces;

public interface INotificationService
{
    Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(string message);
}