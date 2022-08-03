using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Core.Services.Interfaces
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}
