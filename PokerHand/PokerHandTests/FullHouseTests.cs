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
    public class FullHouseTests
    {
        [TestMethod]
        public void FullHouseHandEvaluator_PositiveTest()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.Ten, SuiteEnum.Diamonds),
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.Ten, SuiteEnum.Hearts),
        new Card(Rank.Seven, SuiteEnum.Diamonds),
        new Card(Rank.Seven, SuiteEnum.Spades)
    };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            // Assert
            Assert.AreEqual(6,result);
        }

        [TestMethod]
        public void FullHouseHandEvaluator_NegativeTest()
        {
            // Arrange
            var cards = new List<Card>
    {
        new Card(Rank.Ten, SuiteEnum.Diamonds),
        new Card(Rank.Ten, SuiteEnum.Clubs),
        new Card(Rank.Nine, SuiteEnum.Hearts),
        new Card(Rank.Seven, SuiteEnum.Diamonds),
        new Card(Rank.Seven, SuiteEnum.Spades)
    };
            var evaluator = new PokerHandEvaluator();

            // Act
            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);

            // Assert
            Assert.AreNotEqual(5, result);
        }


    }
}
