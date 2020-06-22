using Aether.Common.Helpers.Hashing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Domain.Common
{
    /// <summary>
    /// Base for all the domain's value objects. Provides equality checks and hash code generation
    /// </summary>
    [DebuggerStepThrough]
    public abstract class ValueObjectBase : IEquatable<ValueObjectBase>
    {

        /// <summary>
        /// Returns the value objects atomic values.
        /// </summary>
        /// <returns>The atomic values.</returns>
        protected abstract IEnumerable<object?> GetAtomicValues();

        /// <summary>
        /// Checks equality for two value objects based on their atomic values.
        /// </summary>
        /// <param name="first">The first value object.</param>
        /// <param name="second">The second value object.</param>
        /// <returns>True if both <paramref name="first"/> and <paramref name="second"/> are null or their atomic values are equal. Otherwise returns false.</returns>
        public static bool operator ==(ValueObjectBase? first, ValueObjectBase? second)
        {
            if (first is null ^ second is null) return false;
            if (first is null) return true;
            return first.Equals(second);
        }

        /// <summary>
        /// Checks inequality for two value objects based on their atomic values.
        /// </summary>
        /// <param name="first">The first value object.</param>
        /// <param name="second">The second value object.</param>
        /// <returns>True if either <paramref name="first"/> or <paramref name="second"/> is null or their atomic values are not equal. Otherwise returns false.</returns>
        public static bool operator !=(ValueObjectBase? first, ValueObjectBase? second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The specified object</param>
        /// <returns>True if </returns>
        public override bool Equals(object? obj) =>
            Equals(obj as ValueObjectBase);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// Checks the equality based on the atomic values and reference equality.
        /// </summary>
        /// <param name="other">The object to compare with</param>
        /// <returns>True if <paramref name="other"/> is reference equal to this or the atomic values are equal. Otherwise returns false</returns>
        bool IEquatable<ValueObjectBase>.Equals(ValueObjectBase? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            using var atomicValuesEnumerator = GetAtomicValues().GetEnumerator();
            using var otherAtomicValuesEnumerator = other.GetAtomicValues().GetEnumerator();

            while (atomicValuesEnumerator.MoveNext() && otherAtomicValuesEnumerator.MoveNext())
            {
                if ((atomicValuesEnumerator.Current is null ^ otherAtomicValuesEnumerator.Current is null) ||
                    (atomicValuesEnumerator.Current is { } && !atomicValuesEnumerator.Current.Equals(otherAtomicValuesEnumerator.Current)))
                {
                    return false;
                }
            }
            return !(atomicValuesEnumerator.MoveNext() || atomicValuesEnumerator.MoveNext());
        }

        /// <summary>
        /// Computes a hash code based on the atomic values of the value object.
        /// </summary>
        /// <returns>The computed hash code</returns>
        public override int GetHashCode()
        {
            var hash = new HashFunction(HashFunctionName.FNV1A);
            var hashValue = hash.Compute(GetAtomicValues());
            return (int)hashValue;
        }

    }
}
