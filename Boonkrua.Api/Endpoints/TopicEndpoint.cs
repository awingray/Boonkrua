using Boonkrua.Api.Handlers;
using Boonkrua.Api.Payloads.Requests.Topics;
using Boonkrua.Service.Interfaces.Topics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boonkrua.Api.Endpoints;

internal static class TopicEndpoint
{
    internal static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapGet(
                Routes.ApiRoutes.Topic.GetById,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.GetById(objectId, service)
            )
            .RequireAuthorization();

        app.MapGet(
                Routes.ApiRoutes.Topic.GetAll,
                [Authorize]
                async ([FromServices] ITopicService service) => await TopicHandler.GetAll(service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.ApiRoutes.Topic.Create,
                [Authorize]
                async (
                    [FromBody] CreateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.Create(request, service, context)
            )
            .RequireAuthorization();

        app.MapPut(
                Routes.ApiRoutes.Topic.Update,
                [Authorize]
                async (
                    [FromBody] UpdateTopicRequest request,
                    [FromServices] ITopicService service,
                    HttpContext context
                ) => await TopicHandler.Update(request, service, context)
            )
            .RequireAuthorization();

        app.MapDelete(
                Routes.ApiRoutes.Topic.Delete,
                [Authorize]
                async (string objectId, [FromServices] ITopicService service) =>
                    await TopicHandler.Delete(objectId, service)
            )
            .RequireAuthorization();

        app.MapPost(
                Routes.ApiRoutes.Topic.Notify,
                [Authorize]
                async (
                    string objectId,
                    string type,
                    [FromServices] ITopicNotificationService service
                ) => await TopicHandler.Notify(objectId, type, service)
            )
            .RequireAuthorization();
    }
}
