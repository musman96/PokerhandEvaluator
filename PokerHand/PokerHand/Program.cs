using PokerHand.Models;
using PokerHand.Services;

namespace PokerHand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a deck of cards
            var deck = new List<Card>();
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (var suitName in new[] { "Hearts", "Diamonds", "Clubs", "Spades" })
                {
                    var card = new Card
                    {
                        Rank = rank,
                        Suit = new Suit(suitName)
                    };
                    deck.Add(card);
                }
            }

            // Shuffle the deck
            var random = new Random();
            deck = deck.OrderBy(c => random.Next()).ToList();

            // Draw a hand of five cards
            var hand = deck.Take(5).ToList();

            // Evaluate the hand
            var handEvaluator = new PokerHandEvaluator();
            var handRank = handEvaluator.EvaluateHand(hand);

            // Print the hand

            Console.WriteLine($"Evaluated Poker Hand: {0}",handRank);

            //keep the Console open until closed by user
            Console.ReadLine();
        }
    }
}