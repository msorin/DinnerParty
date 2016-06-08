using DinnerParty;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DinnerPartyTests
    {

        public Party GetParty(bool isBobMarried)
        {
            var Alice = new Person
            {
                Name = "Alice",
                IsMarried = true
            };

            var Carol = new Person
            {
                Name = "Carol",
                IsMarried = false
            };

            var Bob = new Person
            {
                Name = "Bob",
                IsMarried = isBobMarried
            };

            var party = new Party
            {
                People = new List<Person> { Alice, Bob, Carol }
            };

            Alice.LookingAt = Bob;
            Bob.LookingAt = Carol;
            Carol.LookingAt = Alice;

            return party;
        }

        [TestMethod]
        public void TestHowIrrelevantBobIsToTheQuestion()
        {
            var statuses = new List<bool> { true, false };
            statuses.ForEach(s =>
            {
                Assert.IsTrue(GetParty(s).IsMarriedLookingAtUnmarried());
            });
        }
    }
}
