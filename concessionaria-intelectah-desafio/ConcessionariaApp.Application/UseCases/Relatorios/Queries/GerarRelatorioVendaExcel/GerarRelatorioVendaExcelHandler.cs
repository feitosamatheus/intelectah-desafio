using ConcessionariaApp.Application.Dtos.Relatorios;
using ConcessionariaApp.Domain.Interfaces.Repositories;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.UseCases.Relatorios.Queries.GerarRelatorioVendaExcel
{
    public sealed class GerarRelatorioVendaExcelHandler : IRequestHandler<GerarRelatorioVendaExcelQuery, byte[]>
    {
        private readonly IVendaRepository _vendaRepository;

        public GerarRelatorioVendaExcelHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<byte[]> Handle(GerarRelatorioVendaExcelQuery request, CancellationToken cancellationToken)
        {
            var relatorioVenda = await BuscarRelatorioVenda(request.Mes, request.Ano);

            using (var package = new ExcelPackage())
            {
                var veiculoksheet = package.Workbook.Worksheets.Add("Veículos");
                veiculoksheet.Cells[1, 1, 1, 3].Merge = true;
                veiculoksheet.Cells[1, 1].Value = "Relatório Veículo";
                veiculoksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                veiculoksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                veiculoksheet.Cells[1, 1].Style.Font.Bold = true;
                veiculoksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                veiculoksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                
                veiculoksheet.Cells[2, 1].Value = "Modelo";
                veiculoksheet.Cells[2, 2].Value = "Quantidade vendida";
                veiculoksheet.Cells[2, 3].Value = "Valor total";
                for (int i = 0; i < relatorioVenda.RelatorioVeiculos.Count; i++)
                {
                    veiculoksheet.Cells[i + 3, 1].Value = relatorioVenda.RelatorioVeiculos[i].Modelo;
                    veiculoksheet.Cells[i + 3, 2].Value = relatorioVenda.RelatorioVeiculos[i].QtdVendas;
                    veiculoksheet.Cells[i + 3, 3].Value = relatorioVenda.RelatorioVeiculos[i].TotalVenda;
                }

                var Fabricantesksheet = package.Workbook.Worksheets.Add("Fabricantes");
                Fabricantesksheet.Cells[1, 1, 1, 3].Merge = true;
                Fabricantesksheet.Cells[1, 1].Value = "Relatório Fabricantes";
                Fabricantesksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                Fabricantesksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                Fabricantesksheet.Cells[1, 1].Style.Font.Bold = true;
                Fabricantesksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                Fabricantesksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                
                Fabricantesksheet.Cells[2, 1].Value = "Nome";
                Fabricantesksheet.Cells[2, 2].Value = "Quantidade vendida";
                Fabricantesksheet.Cells[2, 3].Value = "Valor total";
                for (int i = 0; i < relatorioVenda.RelatorioFabricantes.Count; i++)
                {
                    Fabricantesksheet.Cells[i + 3, 1].Value = relatorioVenda.RelatorioFabricantes[i].Nome;
                    Fabricantesksheet.Cells[i + 3, 2].Value = relatorioVenda.RelatorioFabricantes[i].QtdVendas;
                    Fabricantesksheet.Cells[i + 3, 3].Value = relatorioVenda.RelatorioFabricantes[i].TotalVenda;
                }

                var concessionariasheet = package.Workbook.Worksheets.Add("Concessionária");
                concessionariasheet.Cells[1, 1, 1, 3].Merge = true;
                concessionariasheet.Cells[1, 1].Value = "Relatório Fabricantes";
                concessionariasheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                concessionariasheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                concessionariasheet.Cells[1, 1].Style.Font.Bold = true;
                concessionariasheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                concessionariasheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                
                concessionariasheet.Cells[2, 1].Value = "Nome";
                concessionariasheet.Cells[2, 2].Value = "Quantidade vendida";
                concessionariasheet.Cells[2, 3].Value = "Valor total";
                for (int i = 0; i < relatorioVenda.RelatorioConcessionarias.Count; i++)
                {
                    concessionariasheet.Cells[i + 3, 1].Value = relatorioVenda.RelatorioConcessionarias[i].Nome;
                    concessionariasheet.Cells[i + 3, 2].Value = relatorioVenda.RelatorioConcessionarias[i].QtdVendas;
                    concessionariasheet.Cells[i + 3, 3].Value = relatorioVenda.RelatorioConcessionarias[i].TotalVenda;
                }

                var fileContents = package.GetAsByteArray();
                return fileContents;
            }
        }
        public async Task<RelatorioVendaDTO> BuscarRelatorioVenda(int mes, int ano)
        {
            var relatorioVenda = new RelatorioVendaDTO();

            var vendasFiltro = await _vendaRepository.BucarRelatorioVendaPorAnoMes(mes, ano);

            var vendasPorFabricante = vendasFiltro
                .GroupBy(v => v.Veiculo.Fabricante.Nome)
                .Select(group => new RelatorioFabricantesVendaDTO
                {
                    Nome = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda)
                })
                .ToList();

            var vendasPorVeiculo = vendasFiltro
                .GroupBy(v => v.Veiculo.Modelo)
                .Select(group => new RelatorioVeiculosVendaDTO
                {
                    Modelo = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda)
                })
                .ToList();

            var vendasPorConcessionaria = vendasFiltro
                .GroupBy(v => v.Concessionaria.Nome)
                .Select(group => new RelatorioConcessionariaVendaDTO
                {
                    Nome = group.Key,
                    QtdVendas = group.Count(),
                    TotalVenda = group.Sum(v => v.PrecoVenda),
                    VeiculoMaisVendido = group
                        .GroupBy(v => v.Veiculo.Modelo)
                        .Select(veiculoGroup => new RelatorioVeiculosVendaDTO
                        {
                            Modelo = veiculoGroup.Key,
                            QtdVendas = veiculoGroup.Count(),
                            TotalVenda = veiculoGroup.Sum(v => v.PrecoVenda)
                        })
                        .OrderByDescending(v => v.QtdVendas)
                        .FirstOrDefault()
                }).ToList();

            relatorioVenda.TotalVendas = vendasFiltro.Sum(v => v.PrecoVenda);
            relatorioVenda.QtdVendas = vendasFiltro.Count();
            relatorioVenda.RelatorioVeiculos = vendasPorVeiculo;
            relatorioVenda.RelatorioFabricantes = vendasPorFabricante;
            relatorioVenda.RelatorioConcessionarias = vendasPorConcessionaria;

            return relatorioVenda;
        }
    }
        
}
