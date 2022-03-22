using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Uso de Select en Linq");
            foreach (string item in SelectLinq())
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("Uso de Orderby en Linq");
            foreach (int item in OrderLinq1())
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("Uso de Orderby2 en Linq");
            foreach (People item in OrderLinq2())
            {
                Console.WriteLine(item.Name + " : " + item.Age);
            }


            Console.WriteLine("Uso de filtering en Linq");
            foreach (People item in FilteringLinq())
            {
                Console.WriteLine(item.Name + " : " + item.Age);
            }


            Console.WriteLine("Uso de Difference en Linq");
            foreach (string item in DifferenceLinq())
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("Uso de Intersect en Linq");
            foreach (string item in IntersectionLinq())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Uso de Union en Linq");
            foreach (string item in UnionLinq())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Ejemplo de Take Linq");
            foreach(int item in TakeLinq())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Ejemplo de Skip Linq");
            foreach (int item in SkipLinq())
            {
                Console.WriteLine(item);
            }


            var list = TakeWhileLinq();

            Console.WriteLine("Ejemplo de TakeWhile Linq");
            foreach (int item in TakeWhileLinq())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Ejemplo de SkipWhile Linq");
            foreach (int item in SkipWhileLinq())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Ejemplo de Group Linq");
            GroupingLinq();





        }

        public static IEnumerable<string> SelectLinq()
        {
            string[] Countries = { "USA", "Canada", "United Kingdom", "Mexico", "China", "Uruguay" };

            var select = new List<string>();

            var select2 = from c in Countries
                          where c.StartsWith("U")
                          select c;

            var res = Countries.Where(p => p.StartsWith("U"));


            foreach (string item in Countries)
            {
                if (item.StartsWith("U"))
                {
                    select.Add(item);
                }
            }

            return res;
        }


        public static IEnumerable<int> OrderLinq1()
        {
            int[] numeros = { 19, 5, 7, 3, 43, 34 };

            var orderedNumbers = from n in numeros
                          orderby n
                          select n;

            var orderedNumbers2 = numeros.OrderBy(n => n);

            return orderedNumbers2;
        }

        public static IEnumerable<People> OrderLinq2() {
            List<People> peoples = new List<People>
            {
                new People{Name = "TDF", Age = 31},
                new People{Name = "Ali", Age = 33},
                new People{Name = "Sara", Age = 15}
            };

            var res = from p in peoples
                      orderby p.Name
                      select p;

            var res2 = peoples.OrderBy(p => p.Name);

            return res2;
        }

        public static IEnumerable<People> FilteringLinq()
        {
            List<People> peoples = new List<People>
            {
                new People {Name = "Sara", Age = 15},
                new People {Name = "Chano", Age = 31 },
                new People {Name = "Belen", Age = 25 },
                new People {Name = "Nef", Age = 35 },
                new People {Name = "Cris", Age = 37 },
                new People {Name = "Eme", Age = 65},
                new People {Name = "Fel", Age = 67}
            };

            var res = from p in peoples
                      where p.Age == 25
                      select p;

            var res2 = peoples.Where(p => p.Age == 25);

            return res2;
        }

        public static IEnumerable<string> DifferenceLinq()
        {
            string[] Female = { "Martha", "Dora", "Jane", "Tim", "Tom", "Ben" };
            string[] Male = { "Tim", "Tom", "Ben" };

            var withOutMale = Female.Except(Male);

            return withOutMale;
        }


        public static IEnumerable<string> IntersectionLinq()
        {
            string[] Female = { "Martha", "Dora", "Jane", "Tim" };
            string[] Male = { "Tim", "Tom", "Ben" };

            var intersectionLinq = Female.Intersect(Male);

            return intersectionLinq;

        }


        public static IEnumerable<string> UnionLinq()
        {
            string[] Female = { "Martha", "Dora", "Jane", "Tim"};
            string[] Male = { "Tim", "Tom", "Ben" };

            var Union = Female.Union(Male);

            return Union;
        }

        public static IEnumerable<int> TakeLinq()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var res = numeros.Take(3);

            return res;
        }

        public static IEnumerable<int> SkipLinq()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var res = numeros.Skip(6);

            return res;
        }

        public static IEnumerable<int> TakeWhileLinq()
        {            
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res = numeros.TakeWhile(n => n <= 6);


            return res;
        }


        public static IEnumerable<int> SkipWhileLinq()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res = numeros.SkipWhile(n => n != 8);

            return res;
        }

        public static void GroupingLinq()
        {
            List<People> peoples = new List<People>
            {
                new People{Name = "Ali", Age = 33},
                new People {Name = "Sara", Age = 9},
                new People {Name = "Nef", Age = 35},
                new People {Name = "Cris", Age = 35},
                new People {Name = "Eme", Age = 66},
                new People {Name = "Chano", Age = 33}
            };

            var gruposDePersonas = peoples.GroupBy(p =>
            {
                if (p.Age <= 20)
                {
                    return "Menor que 20";
                }
                else if (p.Age >= 21 && p.Age <= 40)
                {
                    return "Entre 21 y 40";
                }
                else
                {
                    return "Mayores de 41";
                }
            });

            peoples.GroupBy(p => p.Age switch
            {
                <= 20 => "Menor de 20",
                <= 40 => "Menor de 40",
                _ => "Mayor de 41"
            })
                .Select(p => new
                {
                    Edad = p.Key, Cantidad = p.Count()
                })
                .ToList()
                .ForEach(item => Console.WriteLine($"{item.Edad} : {item.Cantidad}"));

            foreach (var grupoPersona in gruposDePersonas)
            {
                Console.WriteLine("Grupo de " + grupoPersona.Key + " : cantidad " + grupoPersona.Count());
                foreach (var persona in grupoPersona)
                {
                    Console.WriteLine(persona.Name);
                }
                Console.WriteLine();
            }
        }



    }
}
