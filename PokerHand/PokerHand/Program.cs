using PokerHand.Models;
using PokerHand.Services;

namespace PokerHand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Poker Hand Evaluator!");
            Console.WriteLine(@"The tool uses the following symbols to represent a suit for the cards:
'C' or 'c' for Clubs
'D' or 'd' for Diamonds
'H' or 'h' for Hearts
'S' or 's' for Spades");
            Console.WriteLine(@"These are the symbols for the following cards:
'T' for Ten,
'J' for Jack,
'Q' for Queen,
'K' for King,
'A' for Ace");
            Console.WriteLine("Please enter your hand in the format of '2H 3D 5S 9C KD':");

            string input = Console.ReadLine();
            var cards = ParseInput(input);

            var evaluator = new PokerHandEvaluator();

            var result = evaluator.EvaluateHand(cards);
            var handRepresentation = evaluator.EvaluatedHandRepresentation(result);
            Console.WriteLine("Your hand is a {0}", result);
            Console.WriteLine("String representation of the hand is a {0}", handRepresentation);
            Console.ReadLine();
        }

        /// <summary>
        /// This function takes the string input provided, splits the string into an array of the cards
        /// It then loops through each card to determined the rank and suit
        /// Uses enum to match the two characters to determine the rank and suit
        /// </summary>
        /// <param name="input"></param>
        /// <returns>a list of cards in a format like this: Two Hearts</returns>
        /// <exception cref="ArgumentException"></exception>
        static List<Card> ParseInput(string input)
        {
            var cards = new List<Card>();
            var inputs = input.Split(' ');

            //loop through the array of inputs and determine the exact card using the rank and suit
            //add the card to a list
            foreach (var card in inputs)
            {
                var rankString = card.Substring(0, card.Length - 1);
                var suitString = card.Substring(card.Length - 1);
                
                //check if the card is valid. a valid card will have 2 characters(rank and suit)
                if (card.Length != 2)
                {
                    throw new ArgumentException("Invalid input");
                }

                var rankChar = card[0];//first character of the card
                var suitChar = card[1];//second character of the card

                // Determine the rank of the card based on its first character.
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

                // Determine the suit of the card based on its second character.
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

            /*If the list of cards does not contain exactly 5 elements, throw an ArgumentException.
             This can of course be changed to evaluate the number of cards. for now as default, we are evaluating against 5 cards*/
            if (cards.Count != 5)
            {
                throw new ArgumentException("Invalid number of cards: " + cards.Count);
            }

            return cards;
        }
    }
}