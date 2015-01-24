using System;
using System.Linq;
using ColoredConsole;

namespace ExceptionHelper
{
    public static class ExceptionExtensions
    {
        public static void WriteToConsoleInColor(this Exception ex, bool includeBase = true)
        {
            var exs = includeBase ? new[] {ex, ex.GetBaseException()}.Distinct().ToArray() : new[] {ex};
            foreach (var e in exs)
            {
                ColorConsole.WriteLine(string.Format("{0}: {1}", e.GetType(), e.Message).Red());
                ColorConsole.WriteLine(e.StackTrace.Yellow());
            }
        }

        public static string ToStringIncludingStackTrace(this Exception ex, bool includeBase = true)
        {
            var exs = includeBase ? new[] { ex, ex.GetBaseException() }.Distinct().ToArray() : new[] { ex };
            return string.Join("\n", exs.Select(e => string.Format("{0}: {1}\n{2}\n", e.GetType().Name, e.Message, e.StackTrace)));
        }
    }
}
