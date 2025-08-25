using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Ok<T>(T data)
    {
        return base.Ok(data);
    }

    protected IActionResult Created<T>(string routeName, object routeValues, T data)
    {
        return base.CreatedAtRoute(routeName, routeValues, new ApiResponseWithData<T> { Data = data, Success = true });
    }

    protected IActionResult BadRequest(string message)
    {
        return base.BadRequest(new ApiResponse { Message = message, Success = false });
    }

    protected IActionResult NotFound(string message = "Resource not found")
    {
        return base.NotFound(new ApiResponse { Message = message, Success = false });
    }

    protected IActionResult OkPaginated<T>(PaginatedList<T> pagedList)
    {
        return Ok(new PaginatedResponse<T>
        {
            Data = pagedList,
            CurrentPage = pagedList.CurrentPage,
            TotalPages = pagedList.TotalPages,
            TotalCount = pagedList.TotalCount,
            Success = true
        });
    }
}
