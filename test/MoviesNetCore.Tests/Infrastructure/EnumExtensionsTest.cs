using MoviesNetCore.Infrastructure;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesNetCore.Tests.Infrastructure
{
    public class EnumExtensionsTest
    {
        [Fact]
        public void ShouldConvertStringToEnum()
        {
            var result = "FirstValue".FromString<FakeEnum>();
            Assert.Equal(FakeEnum.FirstValue, result);
        }

        [Fact]
        public void ShouldConvertAnotherStringToEnum()
        {
            var result = "SecondValue".FromString<FakeEnum>();
            Assert.Equal(FakeEnum.SecondValue, result);
        }

        [Fact]
        public void ShouldThrowErrorWhenInvalidEnumValue()
        {
            Assert.Throws<ArgumentException>(() => "NotAValue".FromString<FakeEnum>());
        }

    }

    public enum FakeEnum
    {
        FirstValue,
        SecondValue
    }
}
