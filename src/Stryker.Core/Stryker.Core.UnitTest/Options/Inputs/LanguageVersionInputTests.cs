using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Shouldly;
using Stryker.Core.Exceptions;
using Stryker.Core.Options.Inputs;
using Xunit;

namespace Stryker.Core.UnitTest.Options.Inputs
{
    public class LanguageVersionInputTests
    {
        [Fact]
        public void ShouldHaveDefault()
        {
            var target = new LanguageVersionInput { SuppliedInput = null };

            var result = target.Validate();

            result.ShouldBe(LanguageVersion.Default);
        }
        
        [Fact]
        public void ShouldReturnLanguageVersion()
        {
            var target = new LanguageVersionInput { SuppliedInput = "CSharp9" };

            var result = target.Validate();

            result.ShouldBe(LanguageVersion.CSharp9);
        }

        [Fact]
        public void ShouldValidateLanguageVersion()
        {
            var target = new LanguageVersionInput { SuppliedInput = "gibberish" };

            var ex = Should.Throw<InputException>(() => target.Validate());

            ex.Message.ShouldBe($"The given c# language version (gibberish) is invalid. Valid options are: [{string.Join(", ", ((IEnumerable<LanguageVersion>)Enum.GetValues(typeof(LanguageVersion))).Where(l => l != LanguageVersion.CSharp1))}]");
        }
    }
}
