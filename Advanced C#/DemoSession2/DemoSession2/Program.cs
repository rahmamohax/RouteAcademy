using DemoSession2.DefaultConstraint;
using System.Collections;
using System.Collections.ObjectModel;
using Point = DemoSession2.DefaultConstraint.Point;

namespace DemoSession2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Default Constraints
            //Point? point = new Point(10, 20);
            //TypeA typeA = new TypeA();
            //typeA.MyFun01<Point>(point);  // where T : struct
            //typeA.MyFun02<Point>(point);  // No Constraint 
            //                              // Invalid when Sending Point? because the 'default' of the struct is non-nullable


            //TypeB typeB = new TypeB();
            //typeB.MyFun01<Point>(point);  // where T : struct
            //typeB.MyFun02<Point>(point);  // where T : Default
            // Invalid when Sending Point? because the 'default' of the struct is non-nullable 
            #endregion

            #region ArrayList
            //ArrayList arrayList = new ArrayList(); //ArrayList has Capacity =>No. of elements if can hold
            //                                       //ArrayList has Count => No. of elements it can hold
            //                                       //_item = new object[size =0]
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 0   0

            //arrayList.Add(1); //Boxing
            ////arrayList.Add("hello"); // valid

            //arrayList.AddRange(new int[] { 2, 3, 4 });
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 4   4

            //arrayList.Add(5);
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 8   5
            //Console.WriteLine("");

            #region Insert Elemnet

            //foreach (var item in arrayList) Console.Write(item + " ");
            //Console.WriteLine("");

            //arrayList.Insert(1, 10);
            //foreach (var item in arrayList) Console.Write(item + " ");
            //Console.WriteLine("");

            #endregion

            #region Trim
            //arrayList.TrimToSize(); //trims capacity to no. of elements 
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 6   6
            //Console.WriteLine("");

            //arrayList.Add(100);
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 12   7
            //Console.WriteLine("");
            #endregion

            #region Remove
            //arrayList.Remove(10); //removes fist occurence of element

            //arrayList.RemoveAt(0); //removes element in index

            //foreach (var item in arrayList) Console.Write(item + " "); // 2 3 4 5 100
            //Console.WriteLine("");
            //Console.WriteLine($"Capacity: {arrayList.Capacity}\t Count: {arrayList.Count}"); // 8   5

            //arrayList.RemoveRange(1, 2); 
            //foreach (var item in arrayList) Console.Write(item + " "); // 2 5 100
            //Console.WriteLine("");
            #endregion

            //int? first =(int?) arrayList[0];

            //arrayList[0] = 200; //Boxing
            //foreach (var item in arrayList) Console.Write(item + " ");
            //Console.WriteLine();

            #endregion

            #region List<T>
            //List<int> list = new List<int>();
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 0    0

            //list.Add(1);
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 4    1

            //list.AddRange(new[] { 2, 3, 4, 5, 6 });
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 8    6

            //Console.WriteLine(string.Join(", ", list.ToArray()));

            //list.Insert(5, 10);
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 8    7
            //Console.WriteLine(string.Join(", ", list.ToArray())); //1, 2, 3, 4, 5, 10, 6

            //list.TrimExcess(); //if (size < Threshold) => no triming will occure
            //// _item.Lenght = 8
            //// Threshold = 8 * 0.9 = (int)7.2 = 7 
            //// size = 7
            //// (7 < 7) ? Will Trim : Will not Trim;
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 8    7

            //Console.WriteLine(list[0]);    //get
            //list[0] = 100;     //set

            //Console.WriteLine(string.Join(", ", list.ToArray())); //100, 2, 3, 4, 5, 10, 6

            ////list.Remove(100);

            ////list.RemoveAt(0);

            ////list.RemoveRange(0, 2);
            ////Console.WriteLine(string.Join(", ", list.ToArray())); //100, 2, 3, 4, 5, 10, 6
            ////Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}");// 8    3

            //bool flag = list.Contains(100);
            //Console.WriteLine(flag);

            #region Ctors
            //List<int> list = new List<int>();
            //Console.WriteLine("new List<int>()");
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}\n"); // 0    0

            //list = new List<int>() { 10, 20, 30 , 40, 50 };
            //Console.WriteLine("new List<int>() { 10, 20, 30 , 40, 50 }");
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count}\n"); // 8    5

            //list = new List<int>(10) { 10, 20, 30, 40, 50 };
            //Console.WriteLine("new List<int>(10) { 10, 20, 30 , 40, 50 }");
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count} \n"); // 10    5

            //list = new List<int>([1, 2, 3, 4, 5]);
            //Console.WriteLine("new List<int>([1, 2, 3, 4, 5])");
            //Console.WriteLine($"Capacity: {list.Capacity}\t Count: {list.Count} \n"); // 5    5
            #endregion

            #region List Methods

            //List<int> numbers = new List<int>(5) { 1, 2, 3, 4, 5 };
            //numbers.AddRange(new[] { 10, 20, 30, 40, 50 });

            //ReadOnlyCollection<int> readOnly= numbers.AsReadOnly<int>();
            //readOnly[0] = 3; // Invalid
            //Console.WriteLine(string.Join(", ", readOnly.ToArray()));

            //int index =numbers.BinarySearch(3);
            //Console.WriteLine(index); // 2

            //index = numbers.BinarySearch(100);
            //Console.WriteLine(index); // -11    [Bitwise count of list]

            //index = numbers.BinarySearch(9);
            //Console.WriteLine(index); // -6    [Bitwise of 5]

            //numbers.Clear();
            //Console.WriteLine($"Count: {numbers.Count}\tCapacity: {numbers.Capacity}"); //0     10

            /////////////////////////////////////////////////////////////////////////////////////////
            #endregion

            #endregion

            #region LinkedList
            //LinkedList<int> list = new LinkedList<int>();
            //LinkedListNode<int> node = new LinkedListNode<int> (1);

            //list.AddFirst(node);
            //list.AddLast(10);
            //list.AddLast(20);

            //list.AddAfter(node, 2);

            //Console.WriteLine(string.Join(" ", list.ToArray())); // 1 2 10 20

            //LinkedListNode<int>? first = list.First;
            //Console.WriteLine(first?.Value); 

            //LinkedListNode<int>? last = list.Last;
            //Console.WriteLine(last?.Previous?.Value); // 10

            #endregion

        }
    }
}