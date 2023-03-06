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
    public class TwoPairTests
    {
        [TestMethod]
        public void TwoPairHandEvaluator_ShouldReturnTrue_ForValidTwoPairHand()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Two, SuiteEnum.Hearts),
                new Card(Rank.Two, SuiteEnum.Clubs),
                new Card(Rank.King, SuiteEnum.Hearts),
                new Card(Rank.King, SuiteEnum.Clubs),
                new Card(Rank.Five, SuiteEnum.Diamonds)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreEqual(2,result);
            Assert.AreEqual("Two Pair",handRepresentation);
        }

        [TestMethod]
        public void TwoPairHandEvaluator_ShouldReturnTrue_ForTwoPairWithSameRanksInDifferentSuits()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Two, SuiteEnum.Hearts),
                new Card(Rank.Two, SuiteEnum.Clubs),
                new Card(Rank.King, SuiteEnum.Spades),
                new Card(Rank.King, SuiteEnum.Diamonds),
                new Card(Rank.Seven, SuiteEnum.Clubs)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual("Two Pair", handRepresentation);
        }

        [TestMethod]
        public void TwoPairHandEvaluator_ShouldReturnFalse_ForOnePairHand()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Two, SuiteEnum.Hearts),
                new Card(Rank.Two, SuiteEnum.Clubs),
                new Card(Rank.King, SuiteEnum.Hearts),
                new Card(Rank.Queen, SuiteEnum.Clubs),
                new Card(Rank.Five, SuiteEnum.Diamonds)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreNotEqual(2, result);
            Assert.AreNotEqual("Two Pair", handRepresentation);
        }

        [TestMethod]
        public void TwoPairHandEvaluator_ShouldReturnFalse_ForHighCardHand()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(Rank.Ace, SuiteEnum.Hearts),
                new Card(Rank.King, SuiteEnum.Clubs),
                new Card(Rank.Queen, SuiteEnum.Hearts),
                new Card(Rank.Jack, SuiteEnum.Clubs),
                new Card(Rank.Nine, SuiteEnum.Diamonds)
            };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreNotEqual(2, result);
            Assert.AreNotEqual("Two Pair", handRepresentation);
        }

    }
}
