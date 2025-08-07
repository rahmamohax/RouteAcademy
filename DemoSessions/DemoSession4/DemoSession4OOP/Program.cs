using DemoSession4OOP.Binding;
using DemoSession4OOP.NeedOfCastingOperator;
using DemoSession4OOP.OperatorOverloading;

namespace DemoSession4OOP
{
    class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public void MyFun01()
        {
            Console.WriteLine("I'm -Base- Employee");
        }
        public virtual void MyFun02() {
            Console.WriteLine($"Employee : Id = {Id} , Name = {Name} , Age = {Age}");
        }
    }
    class FullTimeEmployee:Employee
    {
        public decimal Salary { get; set; }


        public new void MyFun01()
        {
            Console.WriteLine("I'm Child -Full Time Employee");
        }
        public  override void MyFun02()
        {
            Console.WriteLine($"Employee : Id = {Id} , Name = {Name} , Age = {Age} , Salary = {Salary}");
        }
    }
    class PartTimeEmployee : Employee
    {
        public int CountOfHours { get; set; }
        public decimal HourRate { get; set; }


        public new void MyFun01()
        {
            Console.WriteLine("I'm Child -Part Time Employee");
        }
        public override void MyFun02()
        {
            Console.WriteLine($"Employee : Id = {Id} , Name = {Name} , Age = {Age} , CountOfHours = {CountOfHours} , HourRate = {HourRate}");
        }
    }
    internal class Program
    {

        #region Binding
        //SOLID
        //L : Liskov Substitution : Reference From Parent Points To Object From Child
        //O : Open (For Extention) Closed (For Modification) Principle 
        ///public static void ProcessEmployee(FullTimeEmployee employee)
        ///{
        ///    if (employee is not null) { 
        ///             employee.MyFun01();
        ///             employee.MyFun02();     
        ///    }
        ///}

        ///public static void ProcessEmployee(PartTimeEmployee employee)
        ///{
        ///    if (employee is not null)
        ///    {
        ///        employee.MyFun01();
        ///        employee.MyFun02();
        ///    }
        ///}


        //public static void ProcessEmployee(Employee employee)
        //{
        //    if (employee is not null)
        //    {

        //        employee.MyFun01();
        //        employee.MyFun02();
        //    }
        //} 
        #endregion
        static void Main(string[] args)
        {

            #region Operators Overloading
            //Complex c1 =new Complex() { Real=2 , Imag =5};
            //Complex c2 =new Complex() { Real=2 , Imag =2};
            ////Complex c3 = default;
            ////c3 = c1 + c2;

            ////c2 += c1;
            ////Console.WriteLine(c1);
            ////Console.WriteLine(c2);
            ////Console.WriteLine("--------------");
            ////Console.WriteLine(c3);
            ////c3++;
            ////Console.WriteLine("------After ++ --------");

            ////Console.WriteLine(c3);


            //if(c1>c2)
            //    Console.WriteLine("C1 Is Greater Than C2");
            //else if(c1< c2)
            //    Console.WriteLine("C1 Is Less Than C2");
            //else
            //    Console.WriteLine("C1 == C2"); 
            #endregion

            #region Casting Operator Overloading
            //Complex c01 = new Complex() { Real = 1, Imag = 2 };
            //object o1 = 5;
            //int x =(int) o1;

            //int y = (int)c01;//1
            //Console.WriteLine(y);

            //string z= (string)c01;
            //Console.WriteLine(z);
            #endregion

            #region Need Of Casting Operator Overloading
            //User user = new User()
            //{
            //    Id = 1,
            //    FullName="Nada Soliman",
            //    Email="nada24Route@gmail.com",
            //    Password="123"
            //};

            ////Manual Mapping : Convert User To UserViewModel
            ////Fill UserViewModel Properties From User Object

            ////UserViewModel model = new UserViewModel()
            ////{
            ////    FName = user?.FullName.Split(' ')[0],
            ////    LName = user?.FullName.Split(' ')[1],
            ////    Email = user?.Email ?? string.Empty,
            ////    Password = user?.Password ?? string.Empty
            ////};


            ////Console.WriteLine(model);
            //Console.WriteLine("---------------------------");
            //UserViewModel userViewModel =(UserViewModel)user;
            //Console.WriteLine(userViewModel); 
            #endregion

            #region Binding
            #region Not Binding

            //Not Binding 
            //TypeA typeA = new TypeA();
            //typeA.A = 1;
            //typeA.MyFun01();
            //typeA.MyFun02();
            //Reference From TypeA Points To Object From The Same Type : TypeA
            //TypeB typeB = new TypeB(); 

            //TypeA newRef =new TypeA();

            //TypeB childRef = (TypeB)newRef;


            //object obj = 5;
            //int x = (int)obj;

            #endregion



            //When Binding Happens ?
            //Reference From Parent  Points To Obejct From Type Child
            //TypeA baseRef= new TypeB();
            //baseRef.A = 1;
            ////baseRef.B = 1;//InValid
            //baseRef.MyFun01();//Static Binding - new 
            ////I'm  Parent (Base) : TypeA =>Coming From Parent
            ////Compiler Will Bind Function Call Based On The Reference Type: At Compilation Time



            //baseRef.MyFun02();//Dynamic Binding - override 
            ////A : 1 , B : 0      =>Coming From Child
            ////Clr Will Bind Function Call  Based On Object Type


            #endregion

            #region Binding Example

            //FullTimeEmployee fullTimeEmp = new FullTimeEmployee()
            //{
            //    Id = 1,
            //    Name = "Maram",
            //    Age = 20,
            //    Salary = 10
            //};

            //ProcessEmployee(fullTimeEmp);

            //Console.WriteLine("---------------------------------");
            //PartTimeEmployee partTimeEmp=new PartTimeEmployee()
            //{
            //    Id = 2,
            //    Name = "Rana",
            //    Age = 20,
            //    CountOfHours=20,
            //    HourRate =10
            //};
            //ProcessEmployee(partTimeEmp);

            #endregion


            //TypeA typeA = new TypeC(1, 2, 3);
            ////typeA.A = 1; *Valid*
            ////typeA.B = 1;   //Not Valid In Compile Time
            ////typeA.C = 1;   //Not Valid In Compile Time
            //typeA.MyFun01();   //Parent MyFun01
            //typeA.MyFun02();   //Child TypeC MyFun02


            TypeA typeA = new TypeD(1, 2, 3, 4);//InDirect Parent
            TypeB typeB = new TypeD(1, 2, 3, 4);//InDirect Parent
            TypeC typeC = new TypeD(1, 2, 3, 4);//  Direct Parent


            typeA.MyFun02();    //Dynamic Binded Method : CLR Will Bind Function Call Based On Object Type
            typeB.MyFun02();    //Dynamic Binded Method : CLR Will Bind Function Call Based On Object Type
            typeC.MyFun02();    //Dynamic Binded Method : CLR Will Bind Function Call Based On Object Type



        }
    }
}
