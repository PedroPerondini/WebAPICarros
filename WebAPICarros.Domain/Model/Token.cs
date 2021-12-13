using System;

namespace WebAPICarros.Domain.Model
{
    public class Token
    {
        private readonly string _token = Environment.GetEnvironmentVariable("Token");
    }
}
