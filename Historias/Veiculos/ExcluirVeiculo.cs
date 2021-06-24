using Dominio.IRepositories;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class ExcluirVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ExcluirVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task Executar(int id)
        {
            await _veiculoRepository.Excluir(id);
        }
    }
}
