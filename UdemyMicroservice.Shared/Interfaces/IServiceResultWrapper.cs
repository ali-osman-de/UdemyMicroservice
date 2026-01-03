using MediatR;

namespace UdemyMicroservice.Shared.Interfaces;

public interface IServiceResultWrapper
{
    public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestByServiceResult : IRequest<ServiceResult>;
}
