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
    public class OnePairTests
    {
        [TestMethod]
        public void EvaluateHand_OnePair_ReturnsOnePair()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Two, SuiteEnum.Hearts),
                new Card(Rank.Two, SuiteEnum.Diamonds),
                new Card(Rank.Five, SuiteEnum.Spades),
                new Card(Rank.Eight, SuiteEnum.Clubs),
                new Card(Rank.Nine, SuiteEnum.Hearts)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreEqual("One Pair", handRepresentation);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvaluateHand_NotOnePair_ReturnsNotOnePair()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Two, SuiteEnum.Hearts),
                new Card(Rank.Three, SuiteEnum.Diamonds),
                new Card(Rank.Five, SuiteEnum.Spades),
                new Card(Rank.Eight, SuiteEnum.Clubs),
                new Card(Rank.Nine, SuiteEnum.Hearts)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreNotEqual("One Pair", handRepresentation);
            Assert.AreNotEqual(1, result);
        }

    }
}
