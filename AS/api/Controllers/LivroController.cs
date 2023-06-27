using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var livros = _livroRepository.GetAll();
            var livrosDTO = _mapper.Map<IList<LivroDTO>>(livros);
            return HttpMessageOk(livrosDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro == null)
                return NotFound();

            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return HttpMessageOk(livroDTO);
        }
 
        [HttpPost]
        public IActionResult Create(LivroViewModel model)
        {
            if (!ModelState.IsValid)
                return HttpMessageError("Dados incorretos");

            var livro = _mapper.Map<Livro>(model);
            _livroRepository.Create(livro);

            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return HttpMessageOk(livroDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LivroViewModel model)
        {
            if (!ModelState.IsValid)
                return HttpMessageError("Dados incorretos");

            var livro = _livroRepository.GetById(id);
            if (livro == null)
                return NotFound();

            _mapper.Map(model, livro);
            _livroRepository.Update(livro);

            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return HttpMessageOk(livroDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro == null) return NotFound();

                
            _livroRepository.Delete(id);
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
