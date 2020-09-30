namespace Enigma
{
    public static class PostgresError
    {
        public static string GetErrorMessage(string sqlState)
        {
            switch (sqlState)
            {
                case "23505":
                    return "The Username must be unique, try something else.";
                default:
                    return "Something whent wrong with the database.";
            }
        }

        //public static string NoNameErrorMessage(string sqlState)
        //{
        //    switch (sqlState)
        //    {
        //        case "23502":
        //            return "You must enter a name first.";
        //        default:
        //            return "Something whent wrong with the database.";
        //    }
        //}
    }
}

