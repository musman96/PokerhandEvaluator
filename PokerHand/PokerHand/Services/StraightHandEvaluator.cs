using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class StraightHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            var orderedCards = cards.OrderBy(c => c.Rank).ToList();

            // Ace can be low or high, so check both cases
            var aceLowStraight = orderedCards.Select((c, i) => c.Rank == Rank.Ace && i == 0 ? Rank.Two : c.Rank).Distinct().ToList();
            var aceHighStraight = orderedCards.Select((c, i) => c.Rank == Rank.Ace && i == 4 ? Rank.Ace : c.Rank).Distinct().ToList();

            return aceLowStraight.Count == 5 || aceHighStraight.Count == 5;
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 4;
        }
    }
}
