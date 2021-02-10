using AutoMapper;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos
{
    public class CategoriaAplicacaoObterServico : ICategoriaAplicacaoObterServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaAplicacaoObterServico(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepositorio.ObterPorId(id));
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepositorio.ObterTodos());
        }

        public void Dispose()
        {
            _categoriaRepositorio?.Dispose();
        }
    }
}