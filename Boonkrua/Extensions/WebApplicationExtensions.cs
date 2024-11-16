using Boonkrua.Handlers;
using Boonkrua.Models.Request.Topics;
using Boonkrua.Services;
using Boonkrua.Services.Topics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Boonkrua.Extensions;

public static class WebApplicationExtensions
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/topic/{objectId}",
            async (string objectId, [FromServices] ITopicService service) =>
                await TopicHandler.GetTopicById(objectId, service)
        );

        app.MapGet(
            "/topic",
            async ([FromServices] ITopicService service) => await TopicHandler.GetAllTopic(service)
        );

        app.MapPost(
            "/topic",
            async ([FromBody] CreateTopicRequest request, [FromServices] ITopicService service) =>
                await TopicHandler.CreateTopic(request, service)
        );

        app.MapPut(
            "/topic",
            async ([FromBody] UpdateTopicRequest request, [FromServices] ITopicService service) =>
                await TopicHandler.UpdateTopic(request, service)
        );

        app.MapDelete(
            "/topic/{objectId}",
            async (string objectId, [FromServices] ITopicService service) =>
                await TopicHandler.DeleteTopic(objectId, service)
        );

        app.MapPost(
            "/topic/{objectId}/notify/{type}",
            async (
                string objectId,
                string type,
                [FromServices] NotificationOrchestrator orchestrator
            ) => await TopicHandler.NotifyTopic(objectId, type, orchestrator)
        );
    }
}
