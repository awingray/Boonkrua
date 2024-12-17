using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Vendors;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.Service.Features.Notifications.Factories;

public sealed class NotificationServiceFactory(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public INotificationService GetService(NotificationType type) =>
        type switch
        {
            NotificationType.Discord => _provider.GetRequiredService<DiscordService>(),
            NotificationType.Line => _provider.GetRequiredService<LineService>(),
            _ => throw new ArgumentException(
                NotificationMessages.Invalid.Provider.ToString(),
                nameof(type)
            ),
        };
}
