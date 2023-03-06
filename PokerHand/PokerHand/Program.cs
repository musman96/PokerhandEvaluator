using PokerHand.Models;
using PokerHand.Services;

namespace PokerHand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Poker Hand Evaluator!");
            Console.WriteLine("Please enter your hand in the format of '2H 3D 5S 9C KD':");

            string input = Console.ReadLine();
            var cards = ParseInput(input);

            var evaluator = new PokerHandEvaluator();

            var result = evaluator.EvaluateHand(cards);

            Console.WriteLine("Your hand is a {0}", result);
            Console.ReadLine();
        }

        static List<Card> ParseInput(string input)
        {
            var cards = new List<Card>();
            var inputs = input.Split(' ');

            foreach (var card in inputs)
            {
                var rankString = card.Substring(0, card.Length - 1);
                var suitString = card.Substring(card.Length - 1);

                if (card.Length != 2)
                {
                    throw new ArgumentException("Invalid input");
                }

                var rankChar = input[0];
                var suitChar = input[1];
                Rank rank;
                if (!Enum.TryParse<Rank>(rankChar.ToString(), out rank))
                {
                    throw new ArgumentException("Invalid card rank: " + rankString);
                }

                Suit suit;
                try
                {
                    suit = (Suit)Enum.Parse(typeof(Suit), suitChar.ToString(), true);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Invalid card suit: " + suitString);
                }

                cards.Add(new Card(rank, suit));
            }

            if (cards.Count != 5)
            {
                throw new ArgumentException("Invalid number of cards: " + cards.Count);
            }

            return cards;
        }
    }
}