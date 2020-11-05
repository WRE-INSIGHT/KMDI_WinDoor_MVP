namespace ModelLayer.Model.User
{
    public interface IUserLoginModel
    {
        string Password { get; set; }
        string Username { get; set; }
    }
}