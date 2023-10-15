﻿using SQLite;

namespace TaskManagerX.Infra.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "taskmanagerx.db3";

        public const SQLiteOpenFlags Flags =
                                    SQLiteOpenFlags.ReadWrite |
                                    SQLiteOpenFlags.Create |
                                    SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
