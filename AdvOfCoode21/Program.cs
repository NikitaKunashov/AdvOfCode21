using System;
using AdvOfCode21.Day1;

namespace AdvOfCode21 {
    class Program {
        static void Main(string[] args) {
            const string day1Path = "inputtask1.txt";
            Day1Task d1Solver = new Day1Task();
            int t1 = d1Solver.GetIncCount(day1Path);
            int t2 = d1Solver.GetInc3Moving(day1Path);
        }
    }
}