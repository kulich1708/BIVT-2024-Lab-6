using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }
            public void Run(double time)
            {
                _time = time;
            }

            
            public void Print()
            {
                Console.WriteLine($"{_printItem(Name)} {_printItem(Surname)} {_printItem(Time.ToString())}");
            }
            private static string _printItem(string item)
            {
                return item + new string(' ', 15 - item.Length);
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group.Name;

                if (group.Sportsmen == null) _sportsmen = null;
                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);

            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;

                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                
                int oldLen = _sportsmen.Length;
                int len = oldLen + sportsmen.Length;
                Array.Resize(ref _sportsmen, len);
                for (int i = oldLen; i < len; i++)
                {
                    _sportsmen[i] = sportsmen[i-oldLen];
                }
            }
            public void Add(Group group)
            {
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                if (_sportsmen == null) return;

                _sportsmen = _sportsmen.OrderBy(x => x.Time).ToArray();
            }
            public static Group Merge(Group group1, Group group2)
            {
                Group group = new Group("Финалисты");
                group1.Sort();
                group2.Sort();
                if (group1.Sportsmen == null && group2.Sportsmen != null) group.Add(group2);
                else if (group2.Sportsmen == null && group2.Sportsmen != null) group.Add(group1);
                else
                {
                    int l = 0, n1 = group1.Sportsmen.Length, n2 = group2.Sportsmen.Length;
                    int i = 0, j = 0, k = 0;
                    while (i < n1 && j < n2)
                    {
                        if (group1.Sportsmen[i].Time < group2.Sportsmen[j].Time)
                        {
                            group.Add(group1.Sportsmen[i]);
                            i++;
                        }
                        else
                        {
                            group.Add(group2.Sportsmen[j]);
                            j++;
                        }
                    }
                    while (i < n1)
                    {
                        group.Add(group1.Sportsmen[i]);
                        i++;
                    }
                    while (j < n2)
                    {

                        group.Add(group2.Sportsmen[j]);
                        j++;
                    }
                }
                return group;
            }
            private static void _printHead()
            {
                Console.WriteLine(_printItem("Name") + _printItem("Surname") + _printItem("Time"));
            }
            public void Print()
            {
                Console.Write(new string(' ', 15));
                Console.WriteLine(_printItem(Name));
                _printHead();
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i].Print();
                }
            }
            private static string _printItem(string item)
            {
                return item + new string(' ', 15 - item.Length);
            }
        }
    }
}
