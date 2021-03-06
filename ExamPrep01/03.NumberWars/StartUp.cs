﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    public class StartUp
    {
        private const int MaxCounter = 1000000;
        public static void Main()
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCards = new Queue<string>(Console.ReadLine().Split());

            var turnsCounter = 0;
            bool gameOver = false;

            while (turnsCounter < MaxCounter && firstAllCards.Count > 0 && secondAllCards.Count > 0 && !gameOver)
            {
                turnsCounter++;
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();

                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string> { firstCard, secondCard };
                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandCard = firstAllCards.Dequeue();
                                var secondHandCard = secondAllCards.Dequeue();
                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);
                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsHand, firstAllCards);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsHand, secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = "";
            if (firstAllCards.Count == secondAllCards.Count)
            {
                result = "Draw";
            }
            else if (firstAllCards.Count > secondAllCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnsCounter} turns");
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
