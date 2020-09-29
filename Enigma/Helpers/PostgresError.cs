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
                    return "The Username must be unique";
                default:
                    return "Something whent wrong with the database";
            }
        }
    }
}
