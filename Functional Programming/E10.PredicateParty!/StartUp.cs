﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.PredicateParty_
{
    public class StartUp
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

            guests = GetCommands(guests);

            PrintGuests(guests);
        }

        private static List<string> GetCommands(List<string> guests)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Party!")
                {
                    break;
                }

                var commands = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                var command = commands[0];
                var condition = commands[1];
                var pattern = commands[2];

                var filteredGuests = FilterGuests(guests, condition, pattern);

                guests = UpdateGuests(guests, filteredGuests, command);
            }

            return guests;
        }

        private static void PrintGuests(List<string> guests)
        {
            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
        }

        private static List<string> UpdateGuests(List<string> guests, List<string> filteredGuests, string command)
        {
            if (guests.Count == 0 || filteredGuests.Count == 0) return guests;

            switch (command)
            {
                case "Remove":
                    guests = guests
                            .Where(g => !filteredGuests.Contains(g))
                            .ToList();
                    break;
                case "Double":
                    for (int i = 0; i < guests.Count; i++)
                    {
                        for (int j = 0; j < filteredGuests.Count; j++)
                        {
                            if (filteredGuests[j] == guests[i])
                            {
                                guests.Insert(++i, filteredGuests[j]);
                                filteredGuests.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    break;
                default: break;
            }
            return guests;
        }

        private static List<string> FilterGuests(List<string> guests, string condition, string pattern)
        {
            Func<string, bool> startsWith = s => s.StartsWith(pattern);
            Func<string, bool> endsWith = s => s.EndsWith(pattern);
            Func<string, bool> hasLength = s => s.Length == int.Parse(pattern);

            var filteredGuests = new List<string>();
            switch (condition)
            {
                case "StartsWith":
                    filteredGuests = guests
                                    .Where(g => startsWith(g))
                                    .ToList();
                    break;
                case "EndsWith":
                    filteredGuests = guests
                                    .Where(g => endsWith(g))
                                    .ToList();
                    break;
                case "Length":
                    filteredGuests = guests
                                    .Where(g => hasLength(g))
                                    .ToList();
                    break;
                default: break;
            }
            return filteredGuests;
        }
    }
}
