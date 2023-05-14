using Juegos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Juegos.Core.Interfaces
{
    public interface IClientService
    {
        OperationResult<Cliente> Create(Cliente cliente);
        OperationResult<Cliente> GetById(int id, int videoId);
    }
}
