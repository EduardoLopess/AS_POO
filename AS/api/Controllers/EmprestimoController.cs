using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IMapper _mapper;

    public EmprestimoController(IEmprestimoRepository emprestimoRepository, IMapper mapper)
    {
        _emprestimoRepository = emprestimoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var emprestimos = _mapper.Map<IList<EmprestimoDTO>>(_emprestimoRepository.GetAll());
        return HttpMessageOk(emprestimos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var emprestimos = _mapper.Map<AutorDTO>(_emprestimoRepository.GetById(id));
        return HttpMessageOk(emprestimos);
    }

    [HttpPost]
    public IActionResult Create(EmprestimoViewModel model)
    {
        if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

        var emprestimo = _mapper.Map<Emprestimo>(model);
        _emprestimoRepository.Create(emprestimo);

        return HttpMessageOk(_mapper.Map<EmprestimoDTO>(emprestimo));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, AutorViewModel model)
    {
        if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
        var emprestimo = _mapper.Map<Emprestimo>(model);
        emprestimo.Id = id;
        _emprestimoRepository.Update(emprestimo);

        return HttpMessageOk(_mapper.Map<EmprestimoDTO>(emprestimo));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var emprestimo = _emprestimoRepository.GetById(id);
        if (emprestimo == null) return NotFound();
        _emprestimoRepository.Delete(id);
        return HttpMessageOk(id);
    }

    [HttpGet("user/{userId}/emprestimos")]
    public IActionResult GetAllByUserId(int userId)
    {
        var emprestimos = _mapper.Map<IList<EmprestimoDTO>>(_emprestimoRepository.GetAllByUserId(userId));
        return HttpMessageOk(emprestimos);
    }

    [HttpPost("user/{userId}/livro/{livroId}/emprestar")]
    public IActionResult BorrowBook(int userId, int livroId)
    {
        if (!_emprestimoRepository.CanUserBorrowBook(userId, livroId))
            return HttpMessageError("Usuário não pode pegar emprestado este livro");

        var emprestimo = new Emprestimo
        {
            UsuarioId = userId,
            LivroId = livroId,
            DataEmprestimo = DateTime.Now
        };

        _emprestimoRepository.Create(emprestimo);
        return HttpMessageOk(_mapper.Map<EmprestimoDTO>(emprestimo));
    }

    [HttpDelete("emprestimo/{emprestimoId}/user/{userId}/devolver")]
    public IActionResult ReturnBook(int emprestimoId, int userId)
    {
        if (!_emprestimoRepository.CanUserReturnBook(emprestimoId, userId))
            return HttpMessageError("Usuário não pode devolver este livro");

        _emprestimoRepository.Delete(emprestimoId);
        return HttpMessageOk();
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
