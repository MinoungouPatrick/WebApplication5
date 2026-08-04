using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5;

public interface ITodoService
{
    List<Todo> ObtenirToutes();
    Todo? ObtenirParId(int id);
    Todo Ajouter(Todo todo);
    bool Modifier(int id, Todo todo);
    bool Supprimer (int id);
    bool ChangerEtat(int id);
    List<Todo> ObtenirTerminees();
    List<Todo> ObtenirNomTerminees();
    
}
public class TodoService : ITodoService
{
    private readonly AppDbContext _Context;
    public TodoService(AppDbContext context)
    {
        _Context = context;
    }
    public List<Todo> ObtenirToutes()
    {
        return _Context.Todos.ToList();
        throw new NotImplementedException();
    }

    public Todo? ObtenirParId(int id)
    {
        return _Context.Todos.FirstOrDefault(t => t.Id == id);
        throw new NotImplementedException();
    }

    public Todo Ajouter(Todo todo)
    {
        _Context.Todos.Add(todo);
        _Context.SaveChanges();
        return todo;
        throw new NotImplementedException();
    }

    public bool Modifier(int id, Todo todo)
    {
        var ancienneTache = _Context.Todos.FirstOrDefault(t => t.Id == id);
        if (ancienneTache == null)
            return false;
        ancienneTache.Nom = todo.Nom;
        ancienneTache.EstTerminee = todo.EstTerminee;
        _Context.SaveChanges();
        return true;
        throw new NotImplementedException();
    }

    public bool Supprimer(int id)
    {
        var todo = _Context.Todos.FirstOrDefault(t => t.Id == id );
        if (todo == null)
            return false;
        _Context.Todos.Remove(todo);
        _Context.SaveChanges();
        return true;
        throw new NotImplementedException();
    }

    public bool ChangerEtat(int id)
    {
        var todo = _Context.Todos.FirstOrDefault(t => t.Id == id );
        if (todo == null)
            return false;
        todo.EstTerminee = !todo.EstTerminee;
        _Context.SaveChanges();
        return true;
        throw new NotImplementedException();
    }

    public List<Todo> ObtenirTerminees()
    {
        return _Context.Todos
                       .Where(t => t.EstTerminee)
                       .ToList();
        throw new NotImplementedException();
    }

    public List<Todo> ObtenirNomTerminees()
    {
        return _Context.Todos
                       .Where(t => !t.EstTerminee)
                       .ToList();
        throw new NotImplementedException();
    }
}