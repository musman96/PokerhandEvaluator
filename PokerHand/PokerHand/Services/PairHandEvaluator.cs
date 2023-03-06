using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PokerHand.Services
{
    public class PairHandEvaluator : HandEvaluatorBase
    {
       // public override HandEvaluation EvaluateHand(IEnumerable<Card> cards)
       // {
       //     var pairs = GetPairs(cards);
       //
       //     if (pairs.Count == 1)
       //     {
       //         var pairValue = pairs.Keys.First();
       //         var remainingCards = cards.Where(c => c.Rank != pairValue).OrderByDescending(c => c.Rank).Take(3);
       //
       //         return new HandEvaluation
       //         {
       //             HandType = HandType.Pair,
       //             HandName = $"Pair of {pairValue}s",
       //             Cards = pairs.Keys.Concat(remainingCards).ToList()
       //         };
       //     }
       //     else
       //     {
       //         return Next.EvaluateHand(cards);
       //     }
       // }

        public override int GetHandRank(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        public override string GetHandReprentation()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidHand(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private Dictionary<Rank, int> GetPairs(IEnumerable<Card> cards)
        {
            var pairs = cards.GroupBy(c => c.Rank)
                             .Where(g => g.Count() == 2)
                             .ToDictionary(g => g.Key, g => g.Count());

            return pairs;
        }
    }

}
