﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace AssertionSample
{
    [TestFixture]
    public class AssertExceptionSample
    {
        [Test]
        public void Divide_positive()
        {
            var calculator = new Calculator();
            var actual = calculator.Divide(5, 2);
            Assert.AreEqual(2.5m, actual);
        }

        [Test]
        public void Divide_Zero()
        {
            var calculator = new Calculator();

            Action action = () =>
            {
                calculator.Divide(5, 0);
            };
            action.Should().Throw<YouShallNotPassException>();
            //how to assert expected exception?
            //never use try/catch in unit test
        }
    }

    public class Calculator
    {
        public decimal Divide(decimal first, decimal second)
        {
            if (second == 0) throw new YouShallNotPassException();

            return first / second;
        }
    }

    public class YouShallNotPassException : Exception
    {
    }
}