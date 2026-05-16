using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Helpers
{
    internal static class TextFileStorage
    {
        private const char FieldSeparator = '|';
        private static readonly Encoding Utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        public static string DataDirectory =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        public static string GetFilePath(string fileName) =>
            Path.Combine(DataDirectory, fileName);

        public static void EnsureDataDirectory()
        {
            if (!Directory.Exists(DataDirectory))
                Directory.CreateDirectory(DataDirectory);
        }

        public static void EnsureFileExists(string filePath)
        {
            EnsureDataDirectory();
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, string.Empty, Utf8);
        }

        public static List<string[]> ReadRecords(string filePath)
        {
            EnsureFileExists(filePath);
            var records = new List<string[]>();

            foreach (var line in File.ReadAllLines(filePath, Utf8))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                records.Add(ParseLine(line));
            }

            return records;
        }

        public static void WriteRecords(string filePath, IEnumerable<string[]> records)
        {
            EnsureDataDirectory();
            var lines = records.Select(fields => string.Join(FieldSeparator.ToString(), fields.Select(EscapeField)));
            File.WriteAllLines(filePath, lines, Utf8);
        }

        public static List<string> ReadLines(string filePath)
        {
            EnsureFileExists(filePath);
            var lines = new List<string>();

            foreach (var line in File.ReadAllLines(filePath, Utf8))
            {
                var trimmed = (line ?? string.Empty).Trim();
                if (!string.IsNullOrEmpty(trimmed))
                    lines.Add(trimmed);
            }

            return lines;
        }

        public static void WriteLines(string filePath, IEnumerable<string> lines)
        {
            EnsureDataDirectory();
            var normalized = lines
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Trim())
                .ToList();

            File.WriteAllLines(filePath, normalized, Utf8);
        }

        private static string[] ParseLine(string line)
        {
            var fields = new List<string>();
            var current = new StringBuilder();
            var escaped = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (escaped)
                {
                    current.Append(c);
                    escaped = false;
                    continue;
                }

                if (c == '\\')
                {
                    escaped = true;
                    continue;
                }

                if (c == FieldSeparator)
                {
                    fields.Add(UnescapeField(current.ToString()));
                    current.Clear();
                    continue;
                }

                current.Append(c);
            }

            fields.Add(UnescapeField(current.ToString()));
            return fields.ToArray();
        }

        private static string EscapeField(string value)
        {
            if (value == null)
                return string.Empty;

            return value
                .Replace("\\", "\\\\")
                .Replace(FieldSeparator.ToString(), "\\" + FieldSeparator);
        }

        private static string UnescapeField(string value) =>
            (value ?? string.Empty)
                .Replace("\\" + FieldSeparator, FieldSeparator.ToString())
                .Replace("\\\\", "\\");
    }
}
