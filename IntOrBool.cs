
using System.Diagnostics;

/// <summary>
/// A closed union type representing either an <see cref="int"/> or a <see cref="bool"/> value.
/// </summary>
public union IntOrBool(int i, bool b)
{

    /// <summary>
    /// Converts the current value to a <see cref="bool"/>.
    /// </summary>
    /// <returns>
    /// The value as-is if it is a <see cref="bool"/>;
    /// <c>true</c> if it is a non-zero <see cref="int"/>, <c>false</c> otherwise.
    /// </returns>
    public readonly bool AsBool() => this switch
    {
        int i => i != 0,
        bool b => b,
        null => throw new UnreachableException()
    };

    /// <summary>
    /// Converts the current value to an <see cref="int"/>.
    /// </summary>
    /// <returns>
    /// The value as-is if it is an <see cref="int"/>;
    /// <c>1</c> if it is a <see cref="bool"/> equal to <c>true</c>, <c>0</c> otherwise.
    /// </returns>
    public readonly int AsInt() => this switch
    {
        int i => i,
        bool b => b ? 1 : 0,
        null => throw new UnreachableException()
    };

    /// <summary>
    /// Returns a string representation of the current value, prefixed with its type name.
    /// </summary>
    /// <returns>A formatted string identifying the type and value.</returns>
    public override string ToString()
    {
        return this switch
        {
            int i => $"Integer: {i}",
            bool b => $"bool: {b}",
            null => throw new UnreachableException()
        };
    }

}