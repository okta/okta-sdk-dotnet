// <copyright file="StringEnum.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an enumeration where the members are strings.
    /// </summary>
    public abstract class StringEnum : IComparable
    {
        private readonly string _value;

        // Remove the ability to call the parameterless constructor.
        private StringEnum()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringEnum"/> class given a string.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        protected StringEnum(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value of this enumeration member.
        /// </summary>
        /// <value>The enumeration value.</value>
        public string Value => _value;

        /// <inheritdoc/>
        public override string ToString() => Value;

        /// <summary>
        /// Gets the <see cref="string"/> value of a <see cref="StringEnum"/> member.
        /// </summary>
        /// <param name="enum">The enumeration member.</param>
        /// <returns>The string value.</returns>
        public static implicit operator string(StringEnum @enum) => @enum.Value;

        /// <summary>
        /// Compares two <see cref="StringEnum"/> instances for value equality, ignoring case.
        /// </summary>
        /// <param name="x">The left operand.</param>
        /// <param name="y">The right operand.</param>
        /// <returns><see langword="true"/> if the instances have equal values; <see langword="false"/> otherwise.</returns>
        public static bool operator ==(StringEnum x, StringEnum y)
        {
            if ((object)x == null && (object)y == null)
            {
                return true;
            }

            if ((object)x == null || (object)y == null)
            {
                return false;
            }

            return x.Value.Equals(y.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares two <see cref="StringEnumeration"/> instances for value inequality, ignoring case.
        /// </summary>
        /// <param name="x">The left operand.</param>
        /// <param name="y">The right operand.</param>
        /// <returns><see langword="true"/> if the instances do not have equal values; <see langword="true"/> otherwise.</returns>
        public static bool operator !=(StringEnum x, StringEnum y) => !(x == y);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var otherEnum = obj as StringEnum;

            if (otherEnum == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = _value.Equals(otherEnum.Value, StringComparison.OrdinalIgnoreCase);

            return typeMatches && valueMatches;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        /// <param name="other">The object to compare to.</param>
        public int CompareTo(object other)
            => string.Compare(Value, ((StringEnum)other).Value, StringComparison.OrdinalIgnoreCase);
    }
}
