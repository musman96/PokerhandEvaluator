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
    public class StraightHandTests
    {
        [TestMethod]
        public void EvaluateStraightHand_ShouldReturnTrue()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.Jack, SuiteEnum.Diamonds),
        new Card(Rank.Queen, SuiteEnum.Hearts),
        new Card(Rank.King, SuiteEnum.Spades),
        new Card(Rank.Ace, SuiteEnum.Diamonds),
    };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void EvaluateNonStraightHand_ShouldReturnFalse()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.Two, SuiteEnum.Clubs),
        new Card(Rank.Five, SuiteEnum.Hearts),
        new Card(Rank.Seven, SuiteEnum.Spades),
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.King, SuiteEnum.Diamonds),
    };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);

            // Assert
            Assert.AreEqual(4, result);
        }

    }
}
