using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public abstract class HandEvaluatorBase : IHandEvaluator
    {
        public abstract bool IsValidHand(List<Card> cards);
        public abstract int GetHandRank(List<Card> cards);
        public abstract string GetHandReprentation();
    }
}
