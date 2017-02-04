using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.AppService.Interface;
using TemplateDDD.AppService.ViewModels;
using TemplateDDD.Domain.Entidade;
using TemplateDDD.Domain.Interface.Service;

namespace TemplateDDD.AppService.Service
{
    public class UsuarioViewModelService : IUsuarioViewModelService
    {
        private readonly IServiceBase<Usuario> _service;
        public IMapperService<UsuarioViewModel, Usuario> _mapper;
        public UsuarioViewModelService(IServiceBase<Usuario> service , IMapperService<UsuarioViewModel, Usuario> mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        void IAppServiceBase<UsuarioViewModel>.Adicionar(ref UsuarioViewModel entidade)
        {
            var model = _mapper.MapearParaDomain(entidade);
            entidade.Id = model.IdUsuario;
            _service.Adicionar(ref model);
        }

        void IAppServiceBase<UsuarioViewModel>.AdicionarMuitos(ref IEnumerable<UsuarioViewModel> entidade)
        {
            var model = _mapper.MapearParaDomain(entidade);

            for (int i = 0; i < entidade.Count(); i++)
            {
                entidade.ElementAt(i).Id = model.ElementAt(i).IdUsuario;
            }

            _service.AdicionarMuitos(ref model);
        }

        void IAppServiceBase<UsuarioViewModel>.Atualizar(UsuarioViewModel entidade)
        {
            var model = _mapper.MapearParaDomain(entidade);
            _service.Atualizar(model);
        }

        void IAppServiceBase<UsuarioViewModel>.AtualizarMuitos(IEnumerable<UsuarioViewModel> entidade)
        {
            var model = _mapper.MapearParaDomain(entidade);
            _service.AtualizarMuitos(model);
        }

        void IAppServiceBase<UsuarioViewModel>.Remover(params object[] id)
        {
            _service.Remover(id);
        }

        void IAppServiceBase<UsuarioViewModel>.RemoverMuitos(IEnumerable<object[]> id)
        {
            _service.RemoverMuitos(id);
        }

        UsuarioViewModel IAppServiceBase<UsuarioViewModel>.SelecionarPorId(params object[] id)
        {
            return _mapper.MapearParaViewModel(_service.SelecionarPorId(id));
        }

        IEnumerable<UsuarioViewModel> IAppServiceBase<UsuarioViewModel>.SelecionarTodos()
        {
            return _mapper.MapearParaViewModel(_service.SelecionarTodos());
        }
    }
}
