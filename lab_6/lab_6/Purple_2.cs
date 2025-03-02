using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace lab_6
{
    public class Purple_2
    {
        public class Participant
        {
            private string _name;
            private string _surname;
            private double _distance;
            private int[] _marks;
            private double _result;
            private int _countJudges;

            public string Name => _name;
            public string Surname => _surname;
            public double Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[] makrsCopy = new int[_marks.Length];
                    Array.Copy(_marks, makrsCopy, _marks.Length);
                    return makrsCopy;
                }
            }
            public double Result => _result;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _countJudges = 5;
                _marks = new int[_countJudges];
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || distance == null || marks.Length != 5 || _marks == null) return;
                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);

                int distancePoints = 60 + (distance - 120) * 2;
                distancePoints = distancePoints < 0 ? 0 : distancePoints;
                _result = distancePoints + marks.Sum() - marks.Min() - marks.Max();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                var sortedArray = array.OrderByDescending(x => x._result).ToArray();
                Array.Copy(sortedArray, array, array.Length);
            }

            public static void PrintHead()
            {
                Console.WriteLine(_printItem("Name") + _printItem("Surname") + _printItem("Result"));
            }
            public void Print()
            {
                Console.WriteLine($"{_printItem(_name)} {_printItem(_surname)} {_printItem(_result.ToString())}");
            }
            private static string _printItem(string item)
            {
                return item + new string(' ', 15 - item.Length);
            }
        }
    }
}