using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using WebApiCarros.Repository.Interface;

namespace WebApiCarros.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        public ObjectId Id { get; set; }
    }
}
