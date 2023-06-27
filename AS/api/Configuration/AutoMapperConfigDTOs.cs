using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.ViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.Livros))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Livro, LivroDTO>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Autores.Select(a => a.Nome).ToList()));
            
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Emprestimos, opt => opt.MapFrom(src => src.Emprestimos));

                
            CreateMap<Emprestimo, EmprestimoDTO>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Livro, opt => opt.MapFrom(src => src.Livro));

        }
    }
}
