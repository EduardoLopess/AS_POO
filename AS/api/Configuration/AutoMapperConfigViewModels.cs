using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<LivroViewModel, Livro>();
            
            CreateMap<AutorViewModel, Autor>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.Livros));
                
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<EmprestimoViewModel, Emprestimo>();
        }
    }
}