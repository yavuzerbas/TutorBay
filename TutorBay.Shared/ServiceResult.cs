using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TutorBay.Shared
{
    public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestByServiceResult : IRequest<ServiceResult>;
    public class ServiceResult
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public ProblemDetails? Fail { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Fail is null;

        [JsonIgnore]
        public bool IsFail => Fail is not null;

        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult { Status = HttpStatusCode.NoContent };
        }

        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found"
                }
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode status)
        {
            return new ServiceResult()
            {
                Fail = problemDetails,
                Status = status
            };
        }

        public static ServiceResult Error(string title, string description, HttpStatusCode status)
        {
            return new ServiceResult()
            {
                Status = status,
                Fail = new ProblemDetails() { Title = title, Detail = description, Status = status.GetHashCode() }
            };
        }

        public static ServiceResult Error(string title, HttpStatusCode status)
        {
            return new ServiceResult() { Status = status, Fail = new ProblemDetails() { Title = title, Status = status.GetHashCode() } };
        }
        public static ServiceResult ErrorFromProblemDetails(Refit.ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult()
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,
                    }
                };
            }

            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(
                exception.Content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

            return new ServiceResult()
            {
                Status = exception.StatusCode,
                Fail = problemDetails,
            };
        }

        public static ServiceResult ErrorFromValidation(IDictionary<string, object?> errors)
        {
            return new ServiceResult()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "",
                    Detail = "",
                    Status = HttpStatusCode.BadRequest.GetHashCode(),
                    Extensions = errors
                }
            };
        }

    }
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public string? UrlAsCreated { get; set; }

        public static ServiceResult<T> SuccessAsOk(T data) => new() { Status = HttpStatusCode.OK, Data = data };

        public static ServiceResult<T> SuccessAsCreated(T data, string url) => new() { Status = HttpStatusCode.Created, Data = data, UrlAsCreated = url };

        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode status)
        {
            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                Status = status
            };
        }

        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode status)
        {
            return new ServiceResult<T>()
            {
                Status = status,
                Fail = new ProblemDetails() { Title = title, Detail = description, Status = status.GetHashCode() }
            };
        }

        public new static ServiceResult<T> Error(string title, HttpStatusCode status)
        {
            return new ServiceResult<T>() { Status = status, Fail = new ProblemDetails() { Title = title, Status = status.GetHashCode() } };
        }
        public new static ServiceResult<T> ErrorFromProblemDetails(Refit.ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>()
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,
                    }
                };
            }

            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(
                exception.Content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

            return new ServiceResult<T>()
            {
                Status = exception.StatusCode,
                Fail = problemDetails,
            };
        }

        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object?> errors)
        {
            return new ServiceResult<T>()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "",
                    Detail = "",
                    Status = HttpStatusCode.BadRequest.GetHashCode(),
                    Extensions = errors
                }
            };
        }
    }
}