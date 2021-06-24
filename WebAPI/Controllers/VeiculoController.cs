using Dominio.IRepositories;
using Historias.Veiculos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Factories;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/veiculos")]
    public class VeiculoController : ControllerBase
    {
        private readonly CriarVeiculo _criarVeiculo;
        private readonly ConsultarVeiculo _consultarVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _criarVeiculo = new CriarVeiculo(veiculoRepository);
            _consultarVeiculo = new ConsultarVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);
        }

        [HttpPost("criar-veiculo")]
        public async Task<IActionResult> Criar([FromBody] VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Todos os campos são obrigatórios" });

            var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

            await _criarVeiculo.Executar(veiculo);

            return Ok(new { message = "Veiculo criado com sucesso" });
        }

        [HttpPut("alterar-veiculo")]
        public async Task<IActionResult> Alterar([FromBody] VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Todos os campos são obrigatórios" });

            try
            {
                var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);

                await _alterarVeiculo.Executar(veiculoViewModel.Id, veiculo);

                return Ok(new { mensagem = "Veiculo atualizado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao alterar o veiculo" });
            }
        }

        [HttpDelete("excluir-veiculo/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _excluirVeiculo.Executar(id);

                return Ok(new { mensagem = "Veiculo excluido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { erro = "Erro ao excluir o veiculo" });
            }
        }

        [HttpGet("buscar-veiculo-por-id/{id}")]
        public async Task<VeiculoViewModel> BuscarPorId(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPorId(id);

            if (veiculo == null)
                return null;

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return veiculoViewModel;
        }

        [HttpGet("buscar-veiculo-por-modelo/{id}")]
        public async Task<VeiculoViewModel> BuscarPorModelo(string modelo)
        {
            var veiculo = await _consultarVeiculo.BuscarPorModelo(modelo);

            if (veiculo == null)
                return null;

            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);

            return veiculoViewModel;
        }

        [HttpGet("listar-veiculos-por-marca")]
        public async Task<IEnumerable<VeiculoViewModel>> ListarPorMarca(string marca)
        {
            var listaDeVeiculos = await _consultarVeiculo.ListarPorMarca(marca);

            if (listaDeVeiculos == null)
                return null;

            var listaDeVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(listaDeVeiculos);
            return listaDeVeiculosViewModel;
        }

        [HttpGet("listar-veiculos")]
        public async Task<IEnumerable<VeiculoViewModel>> ListarTodosVeiculos()
        {
            var listaDeVeiculos = await _consultarVeiculo.ListarTodosVeiculos();

            if (listaDeVeiculos == null)
                return null;

            var listaDeVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(listaDeVeiculos);
            return listaDeVeiculosViewModel;
        }
    }
}
