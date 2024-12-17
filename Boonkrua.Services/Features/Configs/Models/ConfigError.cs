using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Services.Features.Configs.Models;

public sealed record ConfigError : AError
{
    private ConfigError(Message errorMessage)
        : base(errorMessage) { }

    public static ConfigError NotFound => new(ConfigMessages.NotFound.Config);

    public static ConfigError NotFoundUser => new(ConfigMessages.NotFound.User);

    public static ConfigError Duplicate => new(ConfigMessages.AlreadyExists.Config);
}
