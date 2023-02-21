using SmolovJrBench.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SmolovJrBench.Helpers
{
    public static class BenchDataHelper
    {
        public static List<(int, int)> NrOfSetsAndReps { get; } = new() 
        {
            ( 6 , 6 ),
            ( 7 , 5 ),
            ( 8 , 4 ),
            ( 10 , 3 )
        }; 
        public static List<BenchData> WeightCalculation(double maxBenchWeight, double increment)
        {
            List<BenchData> allSessions = new();
            double procent = 0.7;
            double procentOfMax = 0;

            for (int i = 0; i < 4; i++)
            {
                procentOfMax = Math.Round((maxBenchWeight * procent) * 2) / 2;
                BenchData benchData = new()
                {
                    NrOfReps = NrOfSetsAndReps[i].Item2,
                    WorkingWeight = RoundToNearestTwoPointFive(procentOfMax),
                    NrOfSets = NrOfSetsAndReps[i].Item1
                };

                allSessions.Add(benchData);

                procent += 0.05;
            }
            AddIncrementToSessions(increment, allSessions);
            return allSessions;
        }

        public static void AddIncrementToSessions(double increment, List<BenchData> allSessions)
        {
            if (allSessions == null || allSessions.Count < 0)
            {
                return;   
            }

            int startIndex = allSessions.Count - 4;
            int endIndex = allSessions.Count;

            for (int i = startIndex; i < endIndex; i++)
            {
                double workingWeight = RoundToNearestTwoPointFive(allSessions[i].WorkingWeight + increment);
                BenchData benchData = new()
                {
                    NrOfReps = allSessions[i].NrOfReps,
                    WorkingWeight = workingWeight,
                    NrOfSets = allSessions[i].NrOfSets
                };
                allSessions.Add(benchData);
            }
            if (allSessions.Count < 12)
            {
                AddIncrementToSessions(increment, allSessions);
            }
        }

        public static double RoundToNearestTwoPointFive(double number)
        {
            return Math.Round(number / 2.5) * 2.5;
        }
    }
}
