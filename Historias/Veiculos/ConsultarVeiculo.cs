using Dominio.Entidades;
using Dominio.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class ConsultarVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ConsultarVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Veiculo> BuscarPorId(int id)
        {
            return await _veiculoRepository.BuscarPorId(id);
        }

        public async Task<Veiculo> BuscarPorModelo(string modelo)
        {
            return await _veiculoRepository.BuscarPorModelo(modelo);
        }

        public async Task<IEnumerable<Veiculo>> ListarPorMarca(string marca)
        {
            return await _veiculoRepository.ListarPorMarca(marca);
        }

        public async Task<IEnumerable<Veiculo>> ListarTodosVeiculos()
        {
            return await _veiculoRepository.ListarTodosVeiculos();
        }
    }
}
