using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IEmprestimoRepository emprestimoRepository, ILivroRepository livroRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _emprestimoRepository = emprestimoRepository;
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            var usuariosDTO = _mapper.Map<IList<UsuarioDTO>>(usuarios);

            // Obter os empréstimos associados a cada usuário
            foreach (var usuarioDTO in usuariosDTO)
            {
                var emprestimos = _emprestimoRepository.GetEmprestimosByUsuario(usuarioDTO.Id);
                usuarioDTO.Emprestimos = _mapper.Map<IList<EmprestimoDTO>>(emprestimos);

                // Mapear os livros para cada empréstimo
                foreach (var emprestimoDTO in usuarioDTO.Emprestimos)
                {
                    var livro = _livroRepository.GetById(emprestimoDTO.LivroId); // Ou método equivalente para obter o livro
                    emprestimoDTO.Livro = _mapper.Map<LivroDTO>(livro);
                }
            }

            return Ok(usuariosDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuarios = _mapper.Map<UsuarioDTO>(_usuarioRepository.GetById(id));
            return HttpMessageOk(usuarios);
        }
 
        [HttpPost]
        public IActionResult Create(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(model);
            _usuarioRepository.Create(usuario);

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var usuario = _mapper.Map<Usuario>(model);
            usuario.Id = id;
            _usuarioRepository.Update(usuario);

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario  == null) return NotFound();
            _usuarioRepository.Delete(id);
            return HttpMessageOk(id);
        }

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new { data });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new { message });
        }

    }
}