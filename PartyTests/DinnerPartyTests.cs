using DinnerParty;
using NUnit.Framework;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{

    public class DinnerPartyTests
    {
        /// <summary>
        /// Retrieve a party with the attendies: Alice (married, looking at Bob), Bob (unknown, looking at Carol), and Carol (not married, looking at Alice)
        /// </summary>
        /// <param name="isBobMarried">Pass in a value to assign to Bob's status</param>
        /// <returns></returns>
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

        [TestCase(false, ExpectedResult = true)]
        [TestCase(true, ExpectedResult = true)]
        public bool HowRelevantBobsIsMarriageTest(bool isBobMarried)
        {
            return GetParty(isBobMarried).IsMarriedLookingAtUnmarried();
        }

        [Test]
        public async Task AnotherTest()
        {
            await Task.Delay(100);

            var party = GetParty(false);
            Assert.IsFalse(party.People.First(x => x.Name == "Bob").IsMarried);
        }
    }
}