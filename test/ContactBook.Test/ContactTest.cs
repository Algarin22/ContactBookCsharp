using System;
using Xunit;
using ContactBook;

namespace ContactBook.Tests
{
    public class ContactTests
    {
        // ---------------------------
        // Constructor Tests
        // ---------------------------

        [Fact]
        public void DefaultConstructor_ShouldInitializeEmptyStrings()
        {
            var contact = new Contact();

            Assert.Equal("", contact.GetFName());
            Assert.Equal("", contact.GetLName());
            Assert.Equal("", contact.GetPhone());
            Assert.Equal("", contact.GetEmail());
        }

        [Fact]
        public void ParameterizedConstructor_ShouldSetValuesCorrectly()
        {
            var contact = new Contact("John", "Doe", "123", "john@email.com");

            Assert.Equal("John", contact.GetFName());
            Assert.Equal("Doe", contact.GetLName());
            Assert.Equal("123", contact.GetPhone());
            Assert.Equal("john@email.com", contact.GetEmail());
        }

        // ---------------------------
        // Getter / Setter Tests
        // ---------------------------

        [Fact]
        public void Setters_ShouldUpdateValues()
        {
            var contact = new Contact();

            contact.SetFName("Jane");
            contact.SetLName("Smith");
            contact.SetPhone("456");
            contact.SetEmail("jane@email.com");

            Assert.Equal("Jane", contact.GetFName());
            Assert.Equal("Smith", contact.GetLName());
            Assert.Equal("456", contact.GetPhone());
            Assert.Equal("jane@email.com", contact.GetEmail());
        }

        [Fact]
        public void Setters_ShouldAllowEmptyStrings()
        {
            var contact = new Contact("A", "B", "C", "D");

            contact.SetFName("");
            contact.SetLName("");
            contact.SetPhone("");
            contact.SetEmail("");

            Assert.Equal("", contact.GetFName());
            Assert.Equal("", contact.GetLName());
            Assert.Equal("", contact.GetPhone());
            Assert.Equal("", contact.GetEmail());
        }

        // ---------------------------
        // ToString Tests
        // ---------------------------

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            var contact = new Contact("John", "Doe", "123", "john@email.com");

            var result = contact.ToString();

            Assert.Equal("Contact[fname=John, lname=Doe, phone=123, email=john@email.com]", result);
        }

        // ---------------------------
        // Equality Tests
        // ---------------------------

        [Fact]
        public void Equals_SameValues_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("John", "Doe", "123", "email");

            Assert.True(c1.Equals(c2));
        }

        [Fact]
        public void Equals_DifferentValues_ShouldReturnFalse()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("Jane", "Doe", "123", "email");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Equals_Null_ShouldReturnFalse()
        {
            var c1 = new Contact("John", "Doe", "123", "email");

            Assert.False(c1.Equals(null));
        }

        [Fact]
        public void Equals_SameReference_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "email");

            Assert.True(c1.Equals(c1));
        }

        [Fact]
        public void ObjectEquals_ShouldWorkCorrectly()
        {
            object c1 = new Contact("John", "Doe", "123", "email");
            object c2 = new Contact("John", "Doe", "123", "email");

            Assert.True(c1.Equals(c2));
        }

        // ---------------------------
        // Operator Tests
        // ---------------------------

        [Fact]
        public void EqualityOperator_ShouldReturnTrue_ForSameValues()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("John", "Doe", "123", "email");

            Assert.True(c1 == c2);
        }

        [Fact]
        public void InequalityOperator_ShouldReturnTrue_ForDifferentValues()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("Jane", "Doe", "123", "email");

            Assert.True(c1 != c2);
        }

        [Fact]
        public void EqualityOperator_BothNull_ShouldReturnTrue()
        {
            Contact? c1 = null;
            Contact? c2 = null;

            Assert.True(c1 == c2);
        }

        [Fact]
        public void EqualityOperator_OneNull_ShouldReturnFalse()
        {
            Contact? c1 = new Contact();
            Contact? c2 = null;

            Assert.False(c1 == c2);
        }

        // ---------------------------
        // GetHashCode Tests
        // ---------------------------

        [Fact]
        public void GetHashCode_SameValues_ShouldBeEqual()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("John", "Doe", "123", "email");

            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ShouldBeDifferent()
        {
            var c1 = new Contact("John", "Doe", "123", "email");
            var c2 = new Contact("Jane", "Doe", "123", "email");

            Assert.NotEqual(c1.GetHashCode(), c2.GetHashCode());
        }

        // ---------------------------
        // Edge Cases
        // ---------------------------

        [Fact]
        public void Equals_ShouldBeCaseSensitive()
        {
            var c1 = new Contact("john", "doe", "123", "email");
            var c2 = new Contact("John", "Doe", "123", "email");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Contact_WithNullFields_ShouldNotThrow()
        {
            var c1 = new Contact(null!, null!, null!, null!);
            var c2 = new Contact(null!, null!, null!, null!);

            Assert.True(c1.Equals(c2));
        }
    }
}