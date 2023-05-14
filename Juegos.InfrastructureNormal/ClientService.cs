using Juegos.Core;
using Juegos.Core.Entities;
using Juegos.Core.Interfaces;
using System.Xml.Linq;

namespace Juegos.InfrastructureNormal
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Videojuego> videojuegoRepository;
        private readonly IRepository<Cliente> clienteRepository;

        public ClientService(
        IRepository<Videojuego> videojuegoRepository,
        IRepository<Cliente> clienteRepository)
        {
            this.videojuegoRepository = videojuegoRepository;
            this.clienteRepository = clienteRepository;
        }
        public OperationResult<Cliente> Create(Cliente cliente)
        {
            var juego = this.videojuegoRepository.GetById(cliente.Id);
            if (juego is null)
            {
                return new OperationResult<Cliente>(new Error
                {
                    Message=$"No se encontro un juego con id {cliente.Id} para rentar",
                    Code=ErrorCode.BadRequest
                });
            }

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                return new OperationResult<Cliente>(new Error
                {
                    Code = ErrorCode.BadRequest,
                    Message = "El cliente debe tener nombre"
                });
            }

            this.clienteRepository.Add(cliente);
            return new OperationResult<Cliente>(cliente);
        }

        public OperationResult<Cliente> GetById(int id, int videoId)
        {
            var video = this.videojuegoRepository.GetById(videoId);
            if (video is null)
            {
                return new OperationResult<Cliente>(new Error
                {
                    Code = ErrorCode.BadRequest,
                    Message = $"No se encontró un video juego con id {videoId}"
                });
            }

            var client = this.clienteRepository.GetById(id);
            if (client is null)
            {
                return new OperationResult<Cliente>(new Error
                {
                    Code = ErrorCode.BadRequest,
                    Message = $"No se encontró un cliente con el id {videoId}"
                });
            }

            return client;
        }
    }
}