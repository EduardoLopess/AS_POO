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
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        public AutorController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var autores = _autorRepository.GetAll();
            var autorDTOs = _mapper.Map<IList<AutorDTO>>(autores);

            return HttpMessageOk(autorDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var autor = _autorRepository.GetById(id);
            if (autor == null) return NotFound();

            var autorDTO = _mapper.Map<AutorDTO>(autor);
            return HttpMessageOk(autorDTO);
        }

        [HttpPost]
        public IActionResult Create(AutorViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var autor = _mapper.Map<Autor>(model);
            _autorRepository.Create(autor);

            var autorDTO = _mapper.Map<AutorDTO>(autor);
            return HttpMessageOk(autorDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AutorViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var autor = _mapper.Map<Autor>(model);
            autor.Id = id;
            _autorRepository.Update(autor);

            var autorDTO = _mapper.Map<AutorDTO>(autor);
            return HttpMessageOk(autorDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var autor = _autorRepository.GetById(id);
            if (autor == null) return NotFound();

            _autorRepository.Delete(id);
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
