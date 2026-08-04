namespace WebApplication5.Models;

public class Todo
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public bool EstTerminee { get; set; }
}  