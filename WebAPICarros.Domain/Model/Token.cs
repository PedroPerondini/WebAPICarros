using System;

namespace WebAPICarros.Domain.Model
{
    public class Token
    {
        public static string TokenKey = Environment.GetEnvironmentVariable("Token");
    }
}
