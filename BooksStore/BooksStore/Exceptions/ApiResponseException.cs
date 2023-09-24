using BooksStore.Models;
using System.Net;

namespace BooksStore.Exceptions;

public class ApiResponseException : Exception
{
    public ApiResponseException(ApiErrorResponse errorDetails)
    {
        ErrorDetails = errorDetails;
         
    }

    public ApiErrorResponse ErrorDetails { get; }
}
