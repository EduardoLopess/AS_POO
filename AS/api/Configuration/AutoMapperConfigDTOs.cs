using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(src => src.Livros));

            CreateMap<Livro, LivroDTO>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Autores));

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Emprestimos, opt => opt.MapFrom(src => src.Emprestimos));

            CreateMap<Emprestimo, EmprestimoDTO>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Livro, opt => opt.MapFrom(src => src.Livro));
        }
    }
}
