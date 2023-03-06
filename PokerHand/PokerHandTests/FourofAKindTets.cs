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
    public class FourofAKindTets
    {
        [TestClass]
        public class FourOfAKindHandEvaluatorTests
        {
            [TestMethod]
            public void FourOfAKindHandEvaluator_ReturnsTrue_ForFourOfAKind()
            {
                // Arrange
                var cards = new List<Card>
        {
            new Card(Rank.Two, SuiteEnum.Hearts),
            new Card(Rank.Two, SuiteEnum.Clubs),
            new Card(Rank.Two, SuiteEnum.Spades),
            new Card(Rank.Two, SuiteEnum.Diamonds),
            new Card(Rank.King, SuiteEnum.Hearts)
        };
                var evaluator = new PokerHandEvaluator();

                // Act
                var result = evaluator.EvaluateHand(cards);

                // Assert
                Assert.AreEqual(7,result);
            }

            [TestMethod]
            public void FourOfAKindHandEvaluator_ReturnsFalse_ForThreeOfAKind()
            {
                // Arrange
                var cards = new List<Card>
        {
            new Card(Rank.Two, SuiteEnum.Hearts),
            new Card(Rank.Two, SuiteEnum.Clubs),
            new Card(Rank.Two, SuiteEnum.Spades),
            new Card(Rank.Three, SuiteEnum.Diamonds),
            new Card(Rank.King, SuiteEnum.Hearts)
        };
                var evaluator = new PokerHandEvaluator();

                // Act
                var result = evaluator.EvaluateHand(cards);

                // Assert
                Assert.AreNotEqual(7, result);
            }
        }

    }
}
