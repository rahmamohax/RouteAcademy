using Session04.Dictionary;
using System.Collections;

namespace Session04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Hashtable
            //Hashtable phoneNote = new Hashtable()
            //{
            //    //{"Mona", 123 },
            //    //{"Mariam", 456 },
            //    //{"Amr", 789 }
            //    ["Mona"] = 123,
            //    ["Alia"] =456,
            //    ["Amr"] = 789
            //};
            ////phoneNote.Add("Mona", 123);

            ////foreach (string phone in phoneNote.Keys)
            ////    Console.WriteLine(phone);

            ////foreach (DictionaryEntry phone in phoneNote)
            ////    Console.WriteLine(phone.Key + " " + phone.Value);

            //phoneNote["Maram"] = 1020; //add 
            #endregion

            #region Dictionary
            #region Ex 1
            //Dictionary<string, int> phoneNote = new Dictionary<string, int>()
            //{
            //    {"Mona", 123 },
            //    {"Ali", 456 },
            //    {"Slama", 789 },
            //};

            //phoneNote["Mona"] = 200;
            //phoneNote.Add("Mona", 234); //Unsafe

            //if(!phoneNote.ContainsKey("Mona"))
            //    phoneNote.Add("Mona", 234);

            //phoneNote.TryAdd("Mona", 123);

            //Console.WriteLine(phoneNote["Ali"]); //Unsafe, may throw exception
            //phoneNote.TryGetValue("Maram", out int number);
            //Console.WriteLine(number); //returns 0

            //phoneNote["Omar"] = 1000;

            //foreach (KeyValuePair<string, int> item in phoneNote)
            //    Console.WriteLine($"{item.Key}: {item.Value}");

            //KeyValuePair<string, int>[] arr =
            //{
            //    new KeyValuePair<string, int>("Mona", 1111),
            //    new KeyValuePair<string, int>("Maram", 23564)
            //};

            //phoneNote = new Dictionary<string, int>(arr, new StringEqualityComparer()); //Contains Mona & Maram 
            #endregion

            #region Ex 2

            //Employee emp1 = new Employee(10, "Ali", 1000);
            //Employee emp2 = new Employee(20, "Manar", 6000);
            //Employee emp3 = new Employee(30, "Khaled", 18000);

            //Dictionary<Employee, string> employees = new( new EmployeeIDComparer())
            //{
            //    [emp1 ] = "1st",
            //    [emp2 ] = "2nd",
            //    [emp3 ] = "3rd"
            //};

            //Employee emp4 = new Employee(30, "Khaled", 18000);
            //employees.Add(emp4, "4th"); //will be added (different references)
            //                            // different hashcode

            //Console.WriteLine(emp3.GetHashCode()); // -1363605337
            //Console.WriteLine(emp4.GetHashCode()); // -1363605337 
            #endregion

            #endregion

            ///         SortedList<TKey,TValue>                                           SortedDictionary<TKey, TValue>
            ///Backed by two arrays                                                   Backed by a balanced binary search tree
            ///Supports index-based access myList.Keys[i]                            No indexer — you can only access by key
            ///Uses less memory because it’s just arrays.                            Uses more memory because of tree nodes.
            ///

        }
    }
}