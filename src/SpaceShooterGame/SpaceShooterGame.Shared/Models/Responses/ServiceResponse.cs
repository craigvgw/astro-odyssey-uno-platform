﻿using System.Net;

namespace SpaceShooterGame
{
    public class ServiceResponse
    {
        public string RequestUri { get; set; }

        public string ExternalError { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;

        public object Result { get; set; }
    }
}
