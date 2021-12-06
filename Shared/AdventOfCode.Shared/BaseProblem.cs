using System;
using System.IO;

namespace AdventOfCode.Shared
{
    public abstract class BaseProblem
    {
        protected virtual string ClassPrefix { get; } = "Problem";
        protected virtual string InputFileDirPath { get; } = "Inputs";
        protected virtual string InputFileExtension { get; } = ".txt";
        public virtual uint CalculateIndex()
        {
            var typeName = GetType().Name;

            return uint.TryParse(typeName.Substring(typeName.IndexOf(ClassPrefix) + ClassPrefix.Length).TrimStart('_'), out var index)
                ? index
                : default;
        }
        public virtual string InputFilePath
        {
            get
            {
                var index = CalculateIndex().ToString("D2");

                return Path.Combine(InputFileDirPath, $"{index}.{InputFileExtension.TrimStart('.')}");
            }
        }
    }
}
