using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lab_6
{
    public class Purple_2
    {
        public class Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
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
            public int Result { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }
            
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || _marks == null) return;
                _distance = distance;
                Array.Copy(marks, _marks, _marks.Length);

                int distancePoints = 60 + (distance - 120) * 2;
                distancePoints = distancePoints < 0 ? 0 : distancePoints;
                Result = distancePoints + marks.Sum() - marks.Min() - marks.Max();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                var sortedArray = array.OrderByDescending(x => x.Result).ToArray();
                Array.Copy(sortedArray, array, array.Length);
            }

            public void Print()
            {
                Console.WriteLine($"{_printItem(_name)} {_printItem(_surname)} {_printItem(Result.ToString())}");
            }
            private static string _printItem(string item)
            {
                return item + new string(' ', 15 - item.Length);
            }
        }
    }
}