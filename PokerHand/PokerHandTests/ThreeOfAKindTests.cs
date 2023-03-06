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
    public class ThreeOfAKindTests
    {
        // Positive test: Three of a kind hand
        [TestMethod]
        public void EvaluateHand_ThreeOfAKind_ReturnsThreeOfAKindHand()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.Ace, SuiteEnum.Clubs),
        new Card(Rank.Ace, SuiteEnum.Diamonds),
        new Card(Rank.Ace, SuiteEnum.Hearts),
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.Seven, SuiteEnum.Spades)
    };

            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreEqual("Three of a kind", handRepresentation);
            Assert.AreEqual(3, result);
        }

        // Negative test: Not a three of a kind hand
        [TestMethod]
        public void EvaluateHand_NotThreeOfAKind_ReturnsNoHand()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.King, SuiteEnum.Clubs),
        new Card(Rank.Queen, SuiteEnum.Diamonds),
        new Card(Rank.Jack, SuiteEnum.Hearts),
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.Seven, SuiteEnum.Spades)
    };

            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert;
            Assert.AreNotEqual("Three of a kind", handRepresentation);
            Assert.AreNotEqual(3, result);
        }

    }
}
