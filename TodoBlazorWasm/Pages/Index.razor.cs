namespace TodoBlazorWasm.Pages;

public partial class Index
{
    public List<string> Todos = new()
    {
        "Go to bed",
        "Wake up",
        "Brush teeth"
    };

    public string TodoInput { get; set; } = "";

    // blazor will prevent default by itself
    public void SubmitTodo()
    {
        if (string.IsNullOrWhiteSpace(TodoInput))
            return;
        Todos.Add(TodoInput);
        TodoInput = "";
    }
}
