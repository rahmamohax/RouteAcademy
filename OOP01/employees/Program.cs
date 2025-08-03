using employees;

public enum Gender
{
    F, M
}

public enum SecurityPrivileges
{
    Guest, Developer, Secretary, DBA, SecurityOfficer
}
class Program
{
    
    static void Main()  
    {
       Employees[] EmpArr = new Employees[3];

        EmpArr[0] = new Employees(1, "Ali Hassan", Gender.M, 8000.5m, new HiringDate(12, 3, 2020), SecurityPrivileges.DBA);
        EmpArr[1] = new Employees(2, "Sara Ali", Gender.F, 4000.25m, new HiringDate(8, 7, 2023), SecurityPrivileges.Guest);
        EmpArr[2] = new Employees(3, "Ahmed Gamal", Gender.M, 12000.75m, new HiringDate(15, 1, 2019), SecurityPrivileges.SecurityOfficer);

        foreach (var emp in EmpArr)
        {
            Console.WriteLine(emp);
            Console.WriteLine("-----------");
        }
    }
}