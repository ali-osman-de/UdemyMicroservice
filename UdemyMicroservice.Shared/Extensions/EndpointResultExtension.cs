using Microsoft.AspNetCore.Http;
using System.Net;

namespace UdemyMicroservice.Shared.Extensions;

public static class EndpointResultExtension
{
    public static IResult ToResult<T>(this ServiceResult<T> result)
    {
        return result.Status switch
        {
            HttpStatusCode.OK => Results.Ok(result.Data),
            HttpStatusCode.Created => Results.Created(result.UrlAsCreated, result.Data),
            HttpStatusCode.BadRequest => Results.BadRequest(result.Fail!),
            HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
            _ => Results.Problem(result.Fail!)
        };
    }
    public static IResult ToResult(this ServiceResult result)
    {
        return result.Status switch
        {
            HttpStatusCode.NoContent => Results.NoContent(),
            HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
            HttpStatusCode.BadRequest => Results.BadRequest(result.Fail!),
            _ => Results.Problem(result.Fail!)
        };
    }
}
