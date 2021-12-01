using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace AdvOfCode21.Day1 {
    public class Day1Task {
        private int[] InputToArray(string[] items) {
            return items.ToList().Select(int.Parse).ToArray();
        }

        public int GetIncCount(string path) {
            string[] str = File.ReadAllLines(path);
            int[] arr = InputToArray(str);
            return GetIncrementCountByArray(arr);
        }

        private static int GetIncrementCountByArray(int[] arr) {
            var res = arr.Aggregate<int, (int Count, int? Prev)>((0, null), (acc, current) =>
                (acc.Prev.HasValue && acc.Prev < current ? ++acc.Count : acc.Count, current));
            return res.Item1;
        }

        public int GetInc3Moving(string path) {
            string[] str = File.ReadAllLines(path);
            int[] arr = InputToArray(str);
            var sums = arr.Aggregate<int,
                (List<int> sums, int? i1, int? i2)>((new List<int>(), null, null), (c, current) => {
                switch (c.i1,c.i2) {
                    case ({ } el1, { } el2):
                        c.sums.Add(el1+el2 + current);
                        break;
                    case (null, { } el2):
                        c.i1 = el2;
                        c.i2 = current;
                        break;
                    case (null,null):
                        c.i2 = current;
                        break;
                }
                return c;
            });
            return GetIncrementCountByArray(sums.sums.ToArray());
        }
    }
}