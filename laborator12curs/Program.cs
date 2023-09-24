using System;
using System.Collections.Generic;

namespace laborator12curs
{
    class Program
    {

        static void Main(string[] args)
        {
            //dictionary
            /*Creeati un dictionar care va gestiona produse, indexandu-le dupa id-ul acestora. 
            Un produs va avea un Id de tip guid, un nume, un pret, precum si o cantitate
            disponibila.
             */

            var prodDictionary = new Dictionary<int, Produs>();
            var produsList = new List<Produs>();
            produsList.Add(new Produs(1, "mere"));
            produsList.Add(new Produs(2, "pere"));
            produsList.Add(new Produs(3, "cirese"));
            produsList.Add(new Produs(4, "prune"));


            //facem adaugare in dictionar
            foreach( var produs in produsList)
            {
                //prodDictionary.Add(produs.Id, produs);

                prodDictionary[produs.Id] = produs;
            }
            if (prodDictionary.ContainsKey(10))
            {
                Console.WriteLine(prodDictionary[10]);
            }
            //parcurgerea dictionar

            foreach (KeyValuePair<int,Produs> prod in prodDictionary)
            {
                Console.WriteLine("key" + prod.Key);
                Console.WriteLine("value" + prod.Value);
                Console.WriteLine();
                    

            }
            ///////

            var myQueue = new Queue<int>();
            for (var i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            var stack = new Stack<int>();
            for (var i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(stack.Pop());
            }


            var colectieDeStudenti = new MyGenericCollection<Student>(100);
            var colectieDeIntregi = new MyGenericCollection<int>(100);

            colectieDeStudenti.Add(new Student("Costica"));
            colectieDeStudenti.Add(new Student("Ionica"));
            colectieDeStudenti.Add(new Student("Elena"));

            Console.WriteLine(colectieDeStudenti.ExtractLastElement());


            int x = 3;
            int y = 4;

            InterschimbaValori(ref x, ref y);

            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        public static void Afiseaza<T>(T obj1)
        {
            Console.WriteLine(obj1);
        }

        /* Scrieti o metoda care va interschimba doua valori generice*/
        public static void InterschimbaValori<T>(ref T obj1, ref T obj2)
        {
            T aux = obj2;
            obj2 = obj1;
            obj1 = aux;
        }
    }


    class MyGenericCollection<T>
    {
        private T[] data;
        public MyGenericCollection(int maxSize)
        {
            data = new T[maxSize];
            this.MaxSize = maxSize;
        }

        public int MaxSize { get; private set; }
        public int Count { get; private set; } = 0;

        public void Add(T elementToAdd)
        {
            if (this.Count == this.MaxSize)
            {
                Console.WriteLine("Colectia este plina");
                return;
            }
            this.data[Count] = elementToAdd;
            Count++;
        }

        public T ExtractLastElement()
        {
            if (Count == 0)
            {
                //
            }
            var result = data[Count - 1];
            Count--;
            return result;
        }

    }

    class Student
    {
        public Student(string nume)
        {
            this.Nume = nume;
        }
        public Guid guid { get; private set; } = Guid.NewGuid();
        public string Nume { get; private set; }
        public override string ToString()
        {
            return $"{Nume}, {guid}";
        }
    }

    //Dictionary!!!

    class Produs
    {
        public Produs(int id,string nume)
        {
            this.Id = id;
            this.Nume = nume;
        }
        public int Id { get; set; }
        public string Nume { get; set; }

        public int Cantitate { get; set; }
        public double Pret { get; set; }

        public override string ToString()
        {
            return "" + Id +" " + Nume;
        }
    }
}
