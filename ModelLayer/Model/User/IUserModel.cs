namespace ModelLayer.Model.User
{
    public interface IUserModel
    {
        string AccountType { get; set; }
        string Fullname { get; set; }
        string Nickname { get; set; }
        string Password { get; set; }
        string ProfilePath { get; set; }
        int UserID { get; set; }
        int EmployeeID { get; set; }
        string Username { get; set; }
    }
}