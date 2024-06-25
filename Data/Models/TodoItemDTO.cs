namespace AuthorizationClaims.Models;

public class TodoItemDTO
{
    public long Id { get; set; }

    // user ID from AspNetUser table.
    public string? OwnerID { get; set; }

    public string? Name { get; set; }

    public bool IsComplete { get; set; }
}
