using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma
{
    public static class PostgresError
    {
        public static string GetErrorMessage(string sqlState)
        {
            switch (sqlState)
            {
                case "23505":
                    return "Användarnamnet måste vara unikt";
                default:
                    return "Något gick fel med databasen.";
            }
        }
    }
}
