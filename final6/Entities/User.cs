using System.Text.Json.Serialization;

namespace ContactManager.Entities
{
  public class User
  {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
  }
}
