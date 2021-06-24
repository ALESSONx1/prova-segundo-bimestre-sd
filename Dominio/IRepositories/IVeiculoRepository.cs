using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.IRepositories
{
    public interface IVeiculoRepository
    {
        Task Criar(Veiculo veiculo);

        Task Alterar(Veiculo veiculo);

        Task Excluir(int id);

        Task<Veiculo> BuscarPorId(int id);

        Task<Veiculo> BuscarPorModelo(string modelo);

        Task<IEnumerable<Veiculo>> ListarPorMarca(string marca);

        Task<IEnumerable<Veiculo>> ListarTodosVeiculos();
    }
}
