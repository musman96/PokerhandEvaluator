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

        /// <summary>
        /// this function takes the evaluated hand value return from the EvaluateHand function
        /// The value returned from that function is used to return the string representation of the hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>returns the string representation of the hand. For Example, 5 is a Straight hand</returns>
        public string EvaluatedHandRepresentation(int hand)
        {
            string name;
            switch (hand)
            {
                case 1:
                    name ="High Card";
                    break;
                case 2:
                    name = "One Pair";
                    break;
                case 3:
                    name = "Two Pair";
                    break;
                case 4:
                    name = "Three of a Kind";
                    break;
                case 5:
                    name = "Straight";
                    break;
                case 6:
                    name = "Flush";
                    break;
                case 7:
                    name = "Full House";
                    break;
                case 8:
                    name = "Four of a kind";
                    break;
                case 9:
                    name = "Straight Flush";
                    break;
                case 10:
                    name = "Royal Flush";
                    break;
                default:
                    name = "none";
                    break;
            }

            return name;
        }

        //public static (int, string) EvaluateHand(List<Card> cards)
        //{
        //    if (cards.Count != 5)
        //    {
        //        throw new ArgumentException("Invalid number of cards");
        //    }
        //
        //    var flushEvaluator = new FlushHandEvaluator();
        //    var straightEvaluator = new StraightHandEvaluator();
        //    var pairEvaluator = new PairHandEvaluator();
        //
        //    if (flushEvaluator.HasHand(cards) && straightEvaluator.HasHand(cards) && cards.Any(c => c.Rank == Rank.Ace))
        //    {
        //        return (10, "Royal Flush");
        //    }
        //
        //    if (flushEvaluator.HasHand(cards) && straightEvaluator.HasHand(cards))
        //    {
        //        return (9, "Straight Flush");
        //    }
        //
        //    if (pairEvaluator.HasHand(cards, 4))
        //    {
        //        return (8, "Four of a Kind");
        //    }
        //
        //    if (pairEvaluator.HasHand(cards, 3) && pairEvaluator.HasHand(cards, 2))
        //    {
        //        return (7, "Full House");
        //    }
        //
        //    if (flushEvaluator.HasHand(cards))
        //    {
        //        return (6, "Flush");
        //    }
        //
        //    if (straightEvaluator.HasHand(cards))
        //    {
        //        return (5, "Straight");
        //    }
        //
        //    if (pairEvaluator.HasHand(cards, 3))
        //    {
        //        return (4, "Three of a Kind");
        //    }
        //
        //    if (pairEvaluator.HasHand(cards, 2) && pairEvaluator.CountPairs(cards) == 2)
        //    {
        //        return (3, "Two Pair");
        //    }
        //
        //    if (pairEvaluator.HasHand(cards, 2))
        //    {
        //        return (2, "Pair");
        //    }
        //
        //    return (1, "High Card");
        //}

    }
}
