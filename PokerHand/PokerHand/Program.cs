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
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);
            Console.WriteLine("Your hand is a {0}", result);
            Console.WriteLine("String representation of the hand is {0}", handRepresentation);
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

                var rankChar = card[0];
                var suitChar = card[1];
                Rank rank;
                switch (rankChar)
                {
                    case '2':
                        rank = Rank.Two;
                        break;
                    case '3':
                        rank = Rank.Three;
                        break;
                    case '4':
                        rank = Rank.Four;
                        break;
                    case '5':
                        rank = Rank.Five;
                        break;
                    case '6':
                        rank = Rank.Six;
                        break;
                    case '7':
                        rank = Rank.Seven;
                        break;
                    case '8':
                        rank = Rank.Eight;
                        break;
                    case '9':
                        rank = Rank.Nine;
                        break;
                    case 'T':
                        rank = Rank.Ten;
                        break;
                    case 'J':
                        rank = Rank.Jack;
                        break;
                    case 'Q':
                        rank = Rank.Queen;
                        break;
                    case 'K':
                        rank = Rank.King;
                        break;
                    case 'A':
                        rank = Rank.Ace;
                        break;
                    default:
                        throw new ArgumentException("Invalid card rank.");
                }

                SuiteEnum suit;
                switch (suitChar)
                {
                    case 'C':
                    case 'c':
                        suit = SuiteEnum.Clubs;
                        break;
                    case 'D':
                    case 'd':
                        suit = SuiteEnum.Diamonds;
                        break;
                    case 'H':
                    case 'h':
                        suit = SuiteEnum.Hearts;
                        break;
                    case 'S':
                    case 's':
                        suit = SuiteEnum.Spades;
                        break;
                    default:
                        throw new ArgumentException("Invalid suit");
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