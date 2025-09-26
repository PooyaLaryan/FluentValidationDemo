namespace FluentValidationDemo.Dtos
{
    public class User
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    }
}
