using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public interface IHandEvaluator
    {
        bool IsValidHand(List<Card> cards);
        int GetHandRank(List<Card> cards);
    }
}
