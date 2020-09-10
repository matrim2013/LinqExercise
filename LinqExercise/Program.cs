using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */



            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var avg = numbers.Average();
            
            Console.WriteLine($"The sum is {sum} with a mean of {avg}");
            Console.WriteLine($"----------");

            //Order numbers in ascending order and decsending order. Print each to console.

            var asc = numbers.OrderBy(x => x);
            Console.WriteLine($"Ascending:");
            asc.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"----------");
            var decs = numbers.OrderByDescending(x => x);
            Console.WriteLine($"Decsending:");
            decs.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"----------");

            //Print to the console only the numbers greater than 6
            
            var bigs = numbers.Where(x => x > 6);
            Console.WriteLine($"Bigs:");         
            bigs.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"----------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            Console.WriteLine($"Four Middle Numbers:");
            var median = asc.Where(x => x > 3 && x < 8);
            median.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"----------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            
            Console.WriteLine($"Age Change:");
            numbers[4] = 30;
            decs.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"----------");

            // List of employees ***Do not remove this***

            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR S.
            //Order this in acesnding order by FirstName.
            
            Console.WriteLine($"First Name C/S:");
            var specificNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person =>person.FirstName);
            specificNames.ToList().ForEach(person => Console.WriteLine($"{person.FirstName}"));
            Console.WriteLine($"----------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            
            Console.WriteLine($"Oldies:");
            var oldies = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            oldies.ToList().ForEach(person => Console.WriteLine($"{person.FullName} - {person.Age}"));
            Console.WriteLine($"----------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var totalExp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"We have {totalExp.Sum(x=>x.YearsOfExperience)} years of total experience " +
                $"with an average of {totalExp.Average(x=>x.YearsOfExperience)} years per employeee");
            Console.WriteLine($"----------");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Abraham", "Simpkins", 30, 2)).ToList();
            employees.ToList().ForEach(person => Console.WriteLine($"{person.FullName} - Age: {person.Age} - " +
                $"YOE: {person.YearsOfExperience}"));
            Console.WriteLine($"----------");


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
