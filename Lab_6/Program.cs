using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_5;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Task_1();
            //program.Task_2();
            //program.Task_3();
            //program.Task_4();
            //program.Task_5();
        }
        public void Task_1()
        {
            var program = new Program();

            // Массив имен
            string[] names = new string[]
            {
            "Дарья", "Александр", "Никита", "Юрий", "Юрий", "Мария", "Виктор", "Марина", "Марина", "Максим"
            };

            // Массив фамилий
            string[] surnames = new string[]
            {
            "Тихонова", "Козлов", "Павлов", "Луговой", "Степанов", "Луговая", "Жарков", "Иванова", "Полевая", "Тихонов"
            };

            // Массив коэффициентов
            double[][] coefs = new double[][]
            {
            new double[] {2.58, 2.90, 3.04, 3.43},
            new double[] {2.95, 2.63, 3.16, 2.89},
            new double[] {2.56, 3.40, 2.91, 2.69},
            new double[] {2.86, 2.90, 3.19, 3.14},
            new double[] {2.81, 2.64, 2.76, 3.20},
            new double[] {2.74, 3.30, 2.94, 3.27},
            new double[] {2.57, 2.79, 2.71, 3.46},
            new double[] {3.09, 2.67, 2.90, 3.50},
            new double[] {2.65, 3.47, 3.11, 3.39},
            new double[] {3.14, 3.46, 2.96, 2.76}
            };

            // Массив оценок
            int[][][] marks = new int[][][]
        {
            new int[][]
            {
                new int[] { 3, 4, 1, 2, 1, 3, 1 },
                new int[] { 5, 3, 4, 3, 3, 3, 3 },
                new int[] { 2, 4, 1, 5, 6, 1, 2 },
                new int[] { 6, 4, 3, 2, 2, 1, 1 }
            },
            new int[][]
            {
                new int[] { 3, 5, 4, 4, 5, 1, 4 },
                new int[] { 1, 6, 5, 2, 1, 4, 1 },
                new int[] { 6, 2, 4, 1, 2, 6, 5 },
                new int[] { 6, 5, 2, 2, 4, 3, 4 }
            },
            new int[][]
            {
                new int[] { 1, 1, 3, 5, 5, 5, 2 },
                new int[] { 4, 1, 1, 2, 2, 2, 5 },
                new int[] { 5, 2, 3, 3, 2, 2, 3 },
                new int[] { 3, 1, 3, 4, 2, 4, 5 }
            },
            new int[][]
            {
                new int[] { 3, 3, 5, 2, 1, 2, 4 },
                new int[] { 5, 5, 4, 2, 3, 2, 2 },
                new int[] { 6, 3, 1, 2, 2, 6, 6 },
                new int[] { 5, 1, 6, 6, 3, 2, 5 }
            },
            new int[][]
            {
                new int[] { 4, 3, 5, 4, 5, 1, 1 },
                new int[] { 5, 3, 4, 2, 1, 1, 2 },
                new int[] { 2, 2, 4, 2, 6, 3, 4 },
                new int[] { 3, 2, 1, 3, 5, 1, 5 }
            },
            new int[][]
            {
                new int[] { 6, 5, 5, 4, 2, 6, 4 },
                new int[] { 5, 4, 3, 2, 4, 6, 1 },
                new int[] { 1, 1, 3, 4, 4, 1, 6 },
                new int[] { 3, 1, 5, 1, 4, 3, 1 }
            },
            new int[][]
            {
                new int[] { 4, 6, 1, 4, 5, 3, 4 },
                new int[] { 1, 2, 3, 1, 5, 4, 3 },
                new int[] { 3, 6, 2, 3, 1, 6, 3 },
                new int[] { 3, 3, 6, 6, 3, 6, 6 }
            },
            new int[][]
            {
                new int[] { 6, 5, 3, 2, 6, 5, 3 },
                new int[] { 5, 4, 4, 2, 1, 2, 4 },
                new int[] { 4, 2, 2, 5, 1, 3, 1 },
                new int[] { 6, 5, 6, 1, 6, 3, 3 }
            },
            new int[][]
            {
                new int[] { 3, 6, 3, 5, 4, 2, 3 },
                new int[] { 4, 6, 1, 4, 2, 1, 5 },
                new int[] { 1, 1, 3, 1, 3, 2, 6 },
                new int[] { 1, 4, 4, 6, 6, 2, 5 }
            },
            new int[][]
            {
                new int[] { 3, 3, 1, 4, 5, 6, 2 },
                new int[] { 6, 4, 5, 4, 2, 3, 1 },
                new int[] { 3, 3, 4, 2, 2, 3, 6 },
                new int[] { 5, 1, 5, 5, 1, 3, 4 }
            }
        };

            Purple_1.Participant[] participants = new Purple_1.Participant[10];

            for (int i = 0; i < 10; i++)
            {
                Purple_1.Participant p = new Purple_1.Participant(names[i], surnames[i]);

                p.SetCriterias(coefs[i]);
                for (int j = 0; j < 4; j++) p.Jump(marks[i][j]);
                participants[i] = p;
            }
            Purple_1.Participant.Sort(participants);

            string[] items = new string[] { "Name", "Surname", "TotalScore" };
            PrintHead(items);
            for (int i = 0; i < 10; i++) participants[i].Print();
        }
        public void Task_2()
        {
            // 1. Массив с именами
            string[] names = new string[] { "Оксана", "Полина", "Дмитрий", "Евгения", "Савелий", "Евгения", "Егор", "Степан", "Анастасия", "Светлана" };

            // 2. Массив с фамилиями
            string[] surnames = new string[] { "Сидорова", "Полевая", "Полевой", "Распутина", "Луговой", "Павлова", "Свиридов", "Свиридов", "Козлова", "Свиридова" };

            // 3. Массив с дистанциями
            int[] distances = new int[] { 135, 191, 147, 115, 112, 151, 186, 166, 112, 197 };

            // 4. Зубчатый двумерный массив (10x5)
            int[][] marks = new int[][]
            {
            new int[] { 15, 1, 3, 9, 15 },
            new int[] { 19, 14, 9, 11, 4 },
            new int[] { 20, 9, 1, 13, 6 },
            new int[] { 5, 20, 17, 9, 16 },
            new int[] { 19, 8, 1, 6, 17 },
            new int[] { 16, 12, 5, 20, 4 },
            new int[] { 5, 20, 3, 19, 18 },
            new int[] { 16, 12, 5, 4, 15 },
            new int[] { 7, 4, 19, 11, 12 },
            new int[] { 14, 3, 6, 17, 1 }
            };
            Purple_2.Participant[] participants = new Purple_2.Participant[10];

            for (int i = 0; i < 10; i++)
            {
                Purple_2.Participant p = new Purple_2.Participant(names[i], surnames[i]);
                p.Jump(distances[i], marks[i]);
                participants[i] = p;
            }

            Purple_2.Participant.Sort(participants);

            string[] items = new string[] { "Name", "Surname", "Result" };
            PrintHead(items);
            for (int i = 0; i < 10; i++) participants[i].Print();
        }
        public void Task_3()
        {
            // 1 массив с именами
            string[] names = {
            "Виктор", "Алиса", "Ярослав", "Савелий", "Алиса",
            "Алиса", "Александр", "Мария", "Полина", "Татьяна"
            };

            // 2 массив с фамилиями
            string[] surnames = {
            "Полевой", "Козлова", "Зайцев", "Кристиан", "Козлова",
            "Луговая", "Петров", "Смирнова", "Сидорова", "Сидорова"
            };

            // 3 массив оценок
            double[][] marks = {
            new double[] {5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89},
            new double[] {1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79},
            new double[] {2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56},
            new double[] {4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40},
            new double[] {3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73},
            new double[] {0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68},
            new double[] {3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51},
            new double[] {1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03},
            new double[] {0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77},
            new double[] {3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84}
            };

            Purple_3.Participant[] participants = new Purple_3.Participant[10];

            for (int i = 0; i < 10; i++)
            {
                Purple_3.Participant p = new Purple_3.Participant(names[i], surnames[i]);

                for (int j = 0; j < 7; j++) p.Evaluate(marks[i][j]);

                participants[i] = p;
            }

            Purple_3.Participant.SetPlaces(participants);
            Purple_3.Participant.Sort(participants);

            string[] items = new string[] { "Name", "Surname", "Score", "TopPlace", "TotalMark" };
            PrintHead(items);
            for (int i = 0; i < 10; i++) participants[i].Print();
        }
        public void Task_4()
        {
            string[] names1 = {
            "Полина", "Савелий", "Екатерина", "Дмитрий", "Дмитрий",
            "Савелий", "Евгения", "Екатерина", "Мария", "Степан",
            "Ольга", "Ольга", "Дарья", "Дарья", "Евгения"
        };

            // 2 массив с фамилиями
            string[] surnames1 = {
            "Луговая", "Козлов", "Жаркова", "Иванов", "Полевой",
            "Петров", "Распутина", "Луговая", "Иванова", "Павлов",
            "Павлова", "Полевая", "Павлова", "Свиридова", "Свиридова"
        };

            // 3 массив с числами
            double[] times1 = {
            422.64, 142.05, 185.23, 294.32, 79.26,
            230.63, 35.16, 376.12, 279.20, 292.38,
            467.60, 473.82, 290.14, 368.60, 212.67
        };
            Purple_4.Sportsman[] sportsmen = new Purple_4.Sportsman[15];

            for (int i = 0; i < 15; i++)
            {
                Purple_4.Sportsman p = new Purple_4.Sportsman(names1[i], surnames1[i]);
                p.Run(times1[i]);
                sportsmen[i] = p;
            }
            Purple_4.Group group1 = new Purple_4.Group("Группа 1");
            group1.Add(sportsmen);

            // 1 массив с именами
            string[] names2 = {
            "Анастасия", "Александр", "Степан", "Игорь", "Евгения",
            "Мария", "Лев", "Савелий", "Егор", "Оксана",
            "Светлана", "Полина", "Екатерина", "Юлия", "Евгения"
        };

            // 2 массив с фамилиями
            string[] surnames2 = {
            "Жаркова", "Павлов", "Свиридов", "Сидоров", "Сидорова",
            "Сидорова", "Петров", "Козлов", "Свиридов", "Жаркова",
            "Петрова", "Петрова", "Павлова", "Полевая", "Павлова"
        };

            // 3 массив с числами
            double[] times2 = {
            112.49, 472.11, 213.92, 102.13, 263.21,
            350.75, 248.68, 325.28, 300.00, 252.16,
            402.20, 397.33, 384.94, 8.09, 480.52
        };
            
            sportsmen = new Purple_4.Sportsman[15];

            for (int i = 0; i < 15; i++)
            {
                Purple_4.Sportsman p = new Purple_4.Sportsman(names2[i], surnames2[i]);
                p.Run(times2[i]);
                sportsmen[i] = p;
            }
            Purple_4.Group group2 = new Purple_4.Group("Группа 2");
            group2.Add(sportsmen);

            Purple_4.Group result = Purple_4.Group.Merge(group1, group2);
            result.Print();
        }
        public void Task_5()
        {
            string[] animals = { "Макака", "Тануки", "Тануки", "Кошка", "Сима_энага", "Макака", "Панда", "Сима_энага", "Серау", "Панда", "Сима_энага", "Кошка", "Панда", "Кошка", "Панда", "Серау", "Панда", "Сима_энага", "Панда", "Кошка" };
            string[] qualities = { "", "Проницательность", "Скромность", "Внимательность", "Дружелюбность", "Внимательность", "Проницательность", "Проницательность", "Внимательность", "", "Дружелюбность", "Внимательность", "", "Уважительность", "Целеустремленность", "Дружелюбность", "", "Скромность", "Проницательность", "Внимательность" };
            string[] concept = { "Манга", "Манга", "Кимоно", "Суши", "Кимоно", "Самурай", "Манга", "Суши", "Сакура", "Кимоно", "Сакура", "Кимоно", "Сакура", "Фудзияма", "Аниме", "", "Манга", "Фудзияма", "Самурай", "Сакура" };

            Purple_5.Research research = new Purple_5.Research("Research");
            for (int i = 0; i < 20; i++)
            {
                string[] answers = new string[] { animals[i], qualities[i], concept[i] };

                research.Add(answers);
            }
            TestCountVotes(research.Responses, 0, 2);
            research.Print();

        }
        public void TestCountVotes(Response[] responses, int responsesNumber, int questionNumber)
        {
            int result = responses[responsesNumber].CountVotes(responses, questionNumber);
            Console.WriteLine(result);
        }
        public void PrintHead(string[] items)
        {
            foreach (string item in items)
            {
                Console.Write(PrintItem(item));
            }
            Console.WriteLine();
        }
        public string PrintItem(string item)
        {
            return item + new string(' ', 15 - item.Length);
        }
    }
}