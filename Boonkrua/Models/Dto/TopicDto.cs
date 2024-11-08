using Boonkrua.Extensions;
using Boonkrua.Models.Data;
using Boonkrua.Models.Dto.Interfaces;
using Boonkrua.Models.Request;

namespace Boonkrua.Models.Dto;

public sealed record TopicDto
    : IDtoMapper<Topic>,
        IRequestMapper<CreateTopicRequest, TopicDto>,
        IEntityMapper<Topic, TopicDto>
{
    public string? Id { get; init; }
    public required string Title { get; init; }
    public List<TopicDto> ChildTopics { get; init; } = [];
    public string? Description { get; init; }

    private TopicDto() { }

    public Topic ToEntity() =>
        Topic.Create(Title, ChildTopics.ToMappedList(t => t.ToEntity()), Description);

    public static TopicDto FromRequest(CreateTopicRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            ChildTopics = request.ChildTopics?.ToMappedList(FromRequest) ?? [],
        };

    public static TopicDto FromEntity(Topic entity) =>
        new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
        };
}
