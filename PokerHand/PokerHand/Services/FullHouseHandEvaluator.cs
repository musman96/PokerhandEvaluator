﻿using PokerHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand.Services
{
    public class FullHouseHandEvaluator : HandEvaluatorBase
    {
        public override bool IsValidHand(List<Card> cards)
        {
            return cards.GroupBy(c => c.Rank).Count(g => g.Count() == 3) == 1 && cards.GroupBy(c => c.Rank).Count(g => g.Count() == 2) == 1;
        }

        public override int GetHandRank(List<Card> cards)
        {
            return 6;
        }
    }
}
