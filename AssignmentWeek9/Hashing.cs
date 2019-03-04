using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace AssignmentWeek9
{
    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string Password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, correctHash);
        }
    }
}