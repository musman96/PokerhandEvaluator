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

        /// <summary>
        /// Evaluates the poker hand from the list of cards provided
        /// </summary>
        /// <param name="cards"></param>
        /// <returns>an integer value signifying the hand evaluated from the list of cards</returns>
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
                    name ="One Pair";
                    break;
                case 2:
                    name = "Two Pair";
                    break;
                case 3:
                    name = "Three of a kind";
                    break;
                case 4:
                    name = "Straight";
                    break;
                case 5:
                    name = "Flush";
                    break;
                case 6:
                    name = "Full House";
                    break;
                case 7:
                    name = "Four of a kind";
                    break;
                case 8:
                    name = "Straight Flush";
                    break;
                case 9:
                    name = "Royal Flush";
                    break;
                default:
                    name = "High Card";
                    break;
            }

            return name;
        }

    }
}
