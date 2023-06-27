using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;


namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
           
            CreateMap<LivroViewModel, Livro>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Autores.Select(a => new Autor { Nome = a.Nome })));   
           
            CreateMap<AutorViewModel, Autor>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.Livros));
                 
           CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.Emprestimos, opt => opt.MapFrom(src => src.Emprestimos.Select(e => e.Id)));


            CreateMap<EmprestimoViewModel, Emprestimo>();
            
                
        }
    }
}


