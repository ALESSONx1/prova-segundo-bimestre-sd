using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public static class VeiculoFactory
    {
        public static Veiculo MapearVeiculo(VeiculoViewModel veiculoViewModel)
        {
            return new Veiculo(
                veiculoViewModel.Marca,
                veiculoViewModel.Modelo,
                veiculoViewModel.Ano,
                veiculoViewModel.Quilometragem);
        }

        public static VeiculoViewModel MapearVeiculoViewModel(Veiculo veiculo)
        {
            return new VeiculoViewModel
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Quilometragem = veiculo.Quilometragem
            };
        }

        public static IEnumerable<VeiculoViewModel> MapearListaVeiculoViewModel(IEnumerable<Veiculo> listaDeVeiculos)
        {
            var listaDeVeiculoViewModel = new List<VeiculoViewModel>();

            VeiculoViewModel veiculoViewModel;

            foreach (var veiculo in listaDeVeiculos)
            {
                veiculoViewModel = new VeiculoViewModel
                {
                    Id = veiculo.Id,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Ano = veiculo.Ano,
                    Quilometragem = veiculo.Quilometragem
                };

                listaDeVeiculoViewModel.Add(veiculoViewModel);
            }

            return listaDeVeiculoViewModel;
        }
    }
}
