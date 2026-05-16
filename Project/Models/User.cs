using System;

namespace Project
{
    public class User
    {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public string Group { get; set; }
            public int Course { get; set; }
            public DateTime RegistrationDate { get; set; }
            public bool IsAdmin { get; set; }   
    }
}
