using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project.Helpers
{
    public static class GenreHelper
    {
        private const string GenresFile = "genres.txt";

        private static readonly string[] DefaultGenres =
        {
            "Роман",
            "Детектив",
            "Фантастика",
            "Поэзия",
            "Приключения",
            "Сказка",
            "Триллер",
            "Ужасы",
            "Драма",
            "Боевик"
        };

        private static string GenresPath => TextFileStorage.GetFilePath(GenresFile);

        public static void InitializeGenres()
        {
            TextFileStorage.EnsureFileExists(GenresPath);

            if (!File.Exists(GenresPath) || string.IsNullOrWhiteSpace(File.ReadAllText(GenresPath)))
                TextFileStorage.WriteLines(GenresPath, DefaultGenres);
        }

        public static List<string> GetGenres()
        {
            InitializeGenres();

            return TextFileStorage.ReadLines(GenresPath)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(g => g, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
        }

        public static bool AddGenre(string genre)
        {
            genre = (genre ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(genre))
                return false;

            var genres = GetGenres();
            if (genres.Any(g => string.Equals(g, genre, StringComparison.OrdinalIgnoreCase)))
                return false;

            genres.Add(genre);
            TextFileStorage.WriteLines(GenresPath, genres);
            return true;
        }

        public static bool GenreExists(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return false;

            return GetGenres().Any(g => string.Equals(g, genre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
