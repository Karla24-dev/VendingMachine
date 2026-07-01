// Shared/Domain/DomainException.cs
using System.Runtime.CompilerServices;

namespace VendingMachine.Shared.Domain;

public class DomainException(
    string message,
    [CallerFilePath] string callerFile = "")
    : Exception($"[{ExtractModule(callerFile)}] {message}")
{
    public string Module { get; } = ExtractModule(callerFile);

    private static string ExtractModule(string filePath)
    {
        var parts = filePath.Split(
            new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar },
            StringSplitOptions.RemoveEmptyEntries);

        var modulesIndex = Array.IndexOf(parts, "Modules");

        if (modulesIndex >= 0 && modulesIndex + 1 < parts.Length)
            return parts[modulesIndex + 1];

        return "Unknown";
    }
}
