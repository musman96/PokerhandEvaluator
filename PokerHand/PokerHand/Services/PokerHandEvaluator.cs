using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class PokerHandEvaluator
    {
        private readonly List<IHandEvaluator> _handEvaluators = new List<IHandEvaluator>
        {
            new RoyalFlushHandEvaluator(),
            new StraightFlushHandEvaluator(),
            new FourOfAKindHandEvaluator(),
            new FullHouseHandEvaluator(),
            new FlushHandEvaluator(),
            new StraightHandEvaluator(),
            new ThreeOfAKindHandEvaluator(),
            new TwoPairHandEvaluator(),
            new OnePairHandEvaluator()
        };

        public int EvaluateHand(List<Card> cards)
        {
            var validHandEvaluators = _handEvaluators.Where(he => he.IsValidHand(cards)).ToList();
            if (!validHandEvaluators.Any())
            {
                // If no hand evaluator returns true, return the rank of the highest card
                return (int)cards.Max(c => c.Rank);
            }

            return validHandEvaluators.Max(he => he.GetHandRank(cards));
        }
    }
}
