using PokerHand.Models;
using PokerHand.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandTests
{
    [TestClass]
    public class EvaluateRoyalFlushTest
    {
        [TestMethod]
        public void TestEvaluateRoyalFlush()
        {
            // Arrange
            var evaluator = new PokerHandEvaluator();
            var cards = new List<Card>
            {
                new Card(Rank.Ace, SuiteEnum.Spades),
                new Card(Rank.King, SuiteEnum.Spades),
                new Card(Rank.Queen, SuiteEnum.Spades),
                new Card(Rank.Jack, SuiteEnum.Spades),
                new Card(Rank.Ten, SuiteEnum.Spades)
            };

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);
            // Assert
            Assert.AreEqual(9, result);
            Assert.AreEqual("Royal Flush", handRepresentation);
        }

        [TestMethod]
        public void TestEvaluateNonRoyalFlush()
        {
            // Arrange
            var evaluator = new PokerHandEvaluator();
            var cards = new List<Card>
            {
                new Card(Rank.Ace, SuiteEnum.Spades),
                new Card(Rank.King, SuiteEnum.Spades),
                new Card(Rank.Queen, SuiteEnum.Spades),
                new Card(Rank.Jack, SuiteEnum.Spades),
                new Card(Rank.Nine, SuiteEnum.Diamonds) // Not a ten, so not a royal flush
            };

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreNotEqual(9, result);
            Assert.AreNotEqual("Royal Flush", handRepresentation);
        }


    }

}
