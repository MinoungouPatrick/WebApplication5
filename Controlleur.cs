using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService  _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<Todo>> ObtenirToutes()
    {
        return Ok(_todoService.ObtenirToutes());
    }
    [HttpGet("{id:int}")]
    public ActionResult<Todo> ObtenirParId(int id)
    {
            var todo = _todoService.ObtenirParId(id);
            if (todo == null)
                return NotFound("Cette tache n'existe pas.");
            return Ok( todo);
    }

    [HttpPost]
    public ActionResult<Todo> Ajouter(Todo todo)
    {
        var resultat = _todoService.Ajouter(todo);
        return CreatedAtAction(nameof(ObtenirParId), new { id = resultat.Id }, resultat);
    }
    [HttpPut("{id:int}")]
    public IActionResult Modifier(int id, Todo todo)
    {
        bool modifier = _todoService.Modifier(id, todo);
        if (!modifier)
            return NotFound("Cette tache n'existe pas.");
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Supprimer(int id)
    {
        bool supprimer = _todoService.Supprimer(id);
        if (!supprimer)
            return NotFound("Cette tache n'existe pas.");
        return NoContent();
    }

    [HttpPatch("{id:int}/etat")]
    public IActionResult ChangerEtat(int id)
    {
        bool modifier = _todoService.ChangerEtat(id);
        if (!modifier)
            return NotFound("Cette tache n'existe pas.");
        return NoContent();
    }

    [HttpGet("terminees")]
    public ActionResult<List<Todo>> ObtenirTermees()
    {
        return Ok(_todoService.ObtenirTerminees());
    }

    [HttpGet("non-terminees")]
    public ActionResult<List<Todo>> ObtenirNonTerminees()
    {
        return Ok(_todoService.ObtenirNomTerminees());
    }
}