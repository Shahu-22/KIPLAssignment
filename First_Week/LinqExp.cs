using System;
using System.Collections.Generic;
using System.Linq;
class Employee
{
    public int EmpId{get;set;}
    public string Name{get;set;}
    public int DeptId{get;set;}
    public int Salary{get;set;}
}
class Department{
    public int DeptId{get;set;}
    public string DeptName{get;set;}
    public string Manager{get;set;}
}
class LinqExp{
    public static void Main(){
    // List<int> numbers=new List<int>{1,2,3,4,5,6,7,8,9};

    // Finding even numbers
    //  Console.WriteLine("Even Numbers : ");
    // var evens=numbers.Where(n=> n%2==0);
    // foreach(var n in evens){
    //     Console.WriteLine(n);
    // }
    // Console.WriteLine("Odd Numbers : ");
    // Finding odd numbers
    //  var odd=from i in numbers where i%2!=0 select i;
    //   foreach(var i in odd){
    //     Console.WriteLine(i);
    // } 
    
    // Greater than three
    //  Console.WriteLine("Greater than three Numbers : ");
    // var greaterNum=numbers.Where(n=>n>3);
    // foreach(var n in greaterNum){
    //     Console.WriteLine(n);
    // }
    // Square each number
    // Console.WriteLine("Squres Numbers : ");
    // var Squares=numbers.Select(n=>n*n);
    // foreach(var n in Squares){
    //  Console.WriteLine(n);
    // }

    //Order by descending
    //Console.WriteLine("Descending Numbers : ");
    // var Rev=numbers.OrderByDescending(n=>n);
    // foreach(var n in Rev){
    //     Console.WriteLine(n);
    // }/
    
    //FirstorDefault()
//    Console.WriteLine("First Even Number : ");
//    var FirstEven=numbers.FirstOrDefault(n=>n%2==0);
//   Console.WriteLine("First Even Number : "+FirstEven);

List<int> numbers=new List<int>{1,2,3,4,5,6};
    List<int> numbers2=new List<int>{4,5,6,7,8};

    //Filter operator
//     var result=numbers.Where(n =>n>3);
//     foreach(var i in result){
//         Console.WriteLine(i);
//     }
//     ArrrayList list =new ArrayList{1,"Hello",2,"World"};
//     var strings=list.OfTyoe<string>();
//     foreach(var i in strings){
//         Console.WriteLine(i);
//    }

   //Join operators
   List<Employee> employees = new List<Employee>
{
    new Employee { EmpId = 1, Name = "Alice", DeptId = 101, Salary = 60000 },
    new Employee { EmpId = 2, Name = "Bob", DeptId = 102, Salary = 45000 },
    new Employee { EmpId = 3, Name = "Charlie", DeptId = 101, Salary = 70000 },
    new Employee { EmpId = 4, Name = "David", DeptId = 103, Salary = 50000 }
};

List<Department> departments = new List<Department>
{
    new Department { DeptId = 101, DeptName = "IT", Manager = "John" },
    new Department { DeptId = 102, DeptName = "HR", Manager = "Sara" },
    new Department { DeptId = 104, DeptName = "Finance", Manager = "Mike" }
};
 // Inner join
//  var result=from e in employees join
//            d in departments on e.DeptId equals d.DeptId
//            select new{
//             e.Name,
//             d.DeptName,
//             d.Manager
//            }; 
//            foreach(var i in result){
//         Console.WriteLine(i);
//     }

  // Left outer join
//   var res=from e in employees 
//   join d in departments 
//   on e.DeptId equals d.DeptId 
//   into empDept
//   from d in empDept.DefaultIfEmpty()
//         select new{
//             e.Name,
//             DeptName=d?.DeptName ?? "No Department"
//           } ;
//           foreach(var i in res){
//             Console.WriteLine(i);
//           } 

//Group join
// var result=departments.GroupJoin(
//     employees,
//     d=>d.DeptId,
//     e=>e.DeptId,
//     (d,empGroup)=>new{
//         d.DeptName,
//         Employees = empGroup
//     });
//     foreach(var i in result){
//         Console.WriteLine(i);
//     }
  

//   //Right outer join
//   var res=from d in departments
//           join e in employees on
//           d.DeptId equals e.DeptId
//           into DeptEmp
//           from e in DeptEmp.DefaultIfEmpty()
//           select new{
//             EmployeeName=e?.Name ?? "No Employee",
//             d.DeptName
//           };
//    foreach(var i in res){
//     Console.WriteLine(i);
  // }

 //full outer join
//   var left=from e in employees
//         join d in departments
//         on e.DeptId equals d.DeptId
//         into empDept
//         from d in empDept.DefaultIfEmpty()
//         select new{
//             EmployeeName= e.Name,
//             DeptName=d?.DeptName ?? "No Department"
//         };
//     var right=from d in departments
//     join e in employees
//     on d.DeptId equals e.DeptId
//     into deptEmp
//     from e in deptEmp.DefaultIfEmpty()
//     select new{
//         EmployeeName=e?.Name ?? "No Employee ",
//         DeptName=d.DeptName
//     };
//     var fullOuterJoin=left.Union(right);
//     foreach (var i in fullOuterJoin){
//         Console.WriteLine(i);
//     }

//Cross Join
// var crossjoin=from e in employees
//               from d in departments
//               select new{
//                 e.Name,
//                 d.DeptName
//               };
//       foreach(var i in crossjoin){
//         Console.WriteLine(i);
//       }
//self Join
// var selfJoin = from e1 in employees
//                join e2 in employees
//                on e1.DeptId equals e2.DeptId
//                where e1.EmpId != e2.EmpId
//                select new
//                {
//                    Employee = e1.Name,
//                    Colleague = e2.Name,
//                    e1.DeptId
//                };

// foreach (var i in selfJoin)
// {
//     Console.WriteLine(i);
// }

//Aggregation Operations
var totalEmployees = employees.Count();
Console.WriteLine("Total Employees: " + totalEmployees);
var itEmployeesCount = employees.Count(e => e.DeptId == 101);
Console.WriteLine("Employees in IT: " + itEmployeesCount);
var totalSalary = employees.Sum(e => e.Salary);
Console.WriteLine("Total Salary: " + totalSalary);

//total salary in IT
var itTotalSalary = employees
                    .Where(e => e.DeptId == 101)
                    .Sum(e => e.Salary);

Console.WriteLine("IT Total Salary: " + itTotalSalary);

//Average
var avgSalary = employees.Average(e => e.Salary);
Console.WriteLine("Average Salary: " + avgSalary);

var avgSalaryByDept =
    from e in employees
    group e by e.DeptId into deptGroup
    select new
    {
        DeptId = deptGroup.Key,
        AverageSalary = deptGroup.Average(e => e.Salary)
    };

foreach (var item in avgSalaryByDept)
{
    Console.WriteLine(item);
}
   }       
}
