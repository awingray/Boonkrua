using Boonkrua.Handlers;
using Boonkrua.Models.Dto;
using Boonkrua.Models.Request;
using Boonkrua.Repositories;
using Boonkrua.Repositories.Topics;
using MongoDB.Bson;

namespace Boonkrua.Extensions;

public static class WebApplicationExtensions
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                "/topic/{objectId}",
                async (string objectId, ITopicRepository repository) =>
                    await TopicHandler.GetTopicById(objectId, repository)
            )
            .WithName("GetTopicById")
            .WithOpenApi();

        app.MapGet(
                "/topic",
                async (ITopicRepository repository) => await TopicHandler.GetAllTopic(repository)
            )
            .WithName("GetAllTopic")
            .WithOpenApi();

        app.MapPost(
                "/topic",
                async (CreateTopicRequest request, ITopicRepository repository) =>
                    await TopicHandler.CreateParentTopic(request, repository)
            )
            .WithName("CreateTopic")
            .WithOpenApi();
    }
}
