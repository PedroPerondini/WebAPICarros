using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICarros.Domain.Model.Interfaces;

namespace WebAPICarros.Domain.Model
{
    public class UserDatabaseSettings : IUserDatabaseSettings
    {
        public string CollectionName { get; set; } = "Users";
        public string ConnectionString { get; set; } = "mongodb+srv://pedroperondini:senha123@carrosdb.8nwor.mongodb.net/CarrosDB?retryWrites=true&w=majority";
        public string DatabaseName { get; set; } = "UserDB";
    }
}
