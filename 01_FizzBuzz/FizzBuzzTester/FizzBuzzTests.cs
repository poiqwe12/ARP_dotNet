using NUnit.Framework;
using System.Collections.Generic;
using FizzBuzz;

namespace FizzBuzzTester
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleFizzBuzzTest()
        {
            List<int> numbers = new List<int>() { 15 };
            List<string> expectedResults = new List<string>() { "FizzBuzz" };
            var actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }

        [Test]
        public void BuzzTest()
        {
            List<int> numbers = new List<int>() { 1, 5, 7, 10, 35 };
            List<string> expectedResults = new List<string>() { "1", "Buzz", "Buzzinga","Buzz", "Buzzinga" };
            var actualResluts = FizzBuzzer.MillNumbers(numbers);
            CollectionAssert.AreEqual(expectedResults, actualResluts);
        }

        [Test]
        public void FizzTest()
        {
            List<int> numbers = new List<int>() { 3, 6, 9, 12, 14,52 };
            List<string> expectedResults = new List<string>() { "Fizz", "Fizz", "Fizz", "Fizz", "Buzzinga","Buzz" };
            var actualResluts = FizzBuzzer.MillNumbers(numbers);
            CollectionAssert.AreEqual(expectedResults, actualResluts);
        }

        [Test]
        public void MoreRealisticTest()
        {
            List<int> numbers = new List<int>() {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            List<string> expectedResults = new List<string>() {
                "1","2","Fizz","4","Buzz","Fizz","Buzzinga","8","Fizz","Buzz",
                 "11","Fizz","Fizz","Buzzinga","FizzBuzz","16","17","Fizz","19","Buzz"};
            var actualResluts = FizzBuzzer.MillNumbers(numbers);
            CollectionAssert.AreEqual(expectedResults, actualResluts);
        }
        [Test]
        public void SimpleFizzBuzzTestmetod()
        {
            List<int> numbers = new List<int>() { 15 };
            Assert.AreEqual(true, FizzBuzzer.Fizzbuzz_(numbers, 0));
           
        }
        [Test]
        public void BuzzTestmetod()
        {
            List<int> numbers = new List<int>() { 51 };
            Assert.AreEqual(true, FizzBuzzer.Buzz(numbers, 0));

        }
    }
}