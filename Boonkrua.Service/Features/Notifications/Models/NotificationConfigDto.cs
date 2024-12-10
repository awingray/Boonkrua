using Boonkrua.Data.Features.Notifications.Models;
using Boonkrua.Service.Interfaces;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Service.Features.Notifications.Models;

public sealed record NotificationConfigDto
    : IEntityMapper<NotificationConfig, NotificationConfigDto>,
        IDtoMapper<NotificationConfig>
{
    public string? Id { get; init; }

    public required string UserId { get; init; }

    public List<VendorDto> Vendors { get; init; } = [];

    private NotificationConfigDto() { }

    public static NotificationConfigDto Create(
        string userId,
        List<VendorDto>? vendors = null,
        string? id = null
    ) =>
        new()
        {
            UserId = userId,
            Vendors = vendors ?? [],
            Id = id,
        };

    public static NotificationConfigDto FromEntity(NotificationConfig entity) =>
        Create(entity.UserId, entity.Vendors.ToMappedList(VendorDto.FromEntity), entity.Id);

    public NotificationConfig ToEntity() =>
        NotificationConfig.Create(UserId, Vendors.ToMappedList(v => v.ToEntity()), Id);
}