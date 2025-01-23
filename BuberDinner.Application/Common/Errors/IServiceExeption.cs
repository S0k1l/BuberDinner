﻿using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public interface IServiceExeption
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
