using Dominio.Entidades;
using Dominio.IRepositories;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class CriarVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public CriarVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task Executar(Veiculo veiculo)
        {
            await _veiculoRepository.Criar(veiculo);
        }
    }
}
