using System.Net;

namespace aplication.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public object Obj { get; set; }

    public CustomException(HttpStatusCode statusCode, object obj) : base("")
    {
        StatusCode = statusCode;
        Obj = obj;
    }

    public static CustomException BadRequest(object obj) =>
         new(HttpStatusCode.BadRequest, obj); //400

    public static CustomException EntityNotFound(object obj) =>
        new(HttpStatusCode.NotFound, obj); //404

    public static CustomException ErroValidacao(object obj) =>
        new(HttpStatusCode.UnprocessableEntity, obj); //422

    public static CustomException Conflito(object obj) =>
        new(HttpStatusCode.Conflict, obj); //409

}