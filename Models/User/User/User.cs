public static class User
{
    public static string Username { get; set; }
    public static string MaterialStatus { get; set; }
    public static string Address { get; set; }
    public static string BirthDate { get; set; }
    public static string Email { get; set; }
    public static string Pesel { get; set; }
    public static string Phone { get; set; }
    public static string LastName { get; set; }
    public static string FirstName { get; set; }
    public static int UserID { get; set; }

    public static void Clear()
    {
        Username = null;
        MaterialStatus = null;
        Address = null;
        BirthDate = null;
        Email = null;
        Pesel = null;
        Phone = null;
        LastName = null;
        FirstName = null;
        UserID = 0;
    }
}
