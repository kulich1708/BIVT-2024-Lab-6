using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpId;
            private int _countJump;
            private int _countJudges;

            public string Name => _name;
            public string Surname => _surname;
            public double TotalScore { get; private set; }
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] coefsCopy = new double[_coefs.Length];
                    Array.Copy(_coefs, coefsCopy, _coefs.Length);
                    return coefsCopy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int n = _marks.GetLength(0), m = _marks.GetLength(1);
                    int[,] marksCopy = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            marksCopy[i, j] = _marks[i, j];
                        }
                    }
                    return marksCopy;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _countJump = 4;
                _countJudges = 7;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[_countJump, _countJudges];
            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != _countJump || _coefs == null) return;

                Array.Copy(coefs, _coefs, coefs.Length);
            }

            public void Jump(int[] marks)
            {
                if (_jumpId >= _countJump || marks == null || marks.Length != _countJudges || _marks == null || _coefs == null) return;

                for (int i = 0; i < _countJudges; i++)
                {
                    _marks[_jumpId, i] = marks[i];
                }

                TotalScore += (marks.Sum() - marks.Min() - marks.Max()) * _coefs[_jumpId];
                _jumpId++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                var sortedArray = array.OrderByDescending(s => s.TotalScore).ToArray();
                Array.Copy(sortedArray, array, array.Length);
            }

            public void Print()
            {
                Console.WriteLine($"{_printItem(_name)} {_printItem(_surname)} {_printItem(Math.Round(TotalScore, 2).ToString())}");
            }
            private static string _printItem(string item)
            {
                return item + new string(' ', 15 - item.Length);
            }
        }
    }
}