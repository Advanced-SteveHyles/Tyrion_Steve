using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        private static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

            using (IRepository<Employee> employeeRespository = new SqlRespository<Employee>(new EmployeeDb()))
            {
                AddEmployees(employeeRespository);

                AddManagers(employeeRespository); //Irespository of Employee cannot be converted to IRepository of manager

                CountEmployees(employeeRespository);
                QueryEmployee(employeeRespository);

                IEnumerable<Employee> temp = employeeRespository.FindAll();  //IEnumerable is Covariant as its parameter is marked as out.
                //IEnumerable<Person> temp1 = employeeRespository.FindAll();  //Covariant 
                
                DumpPeople(employeeRespository); //-> Everyone treated as Employee
                DumpPeopleCovariant(employeeRespository); // ->Everyone can be treated as persons
                
            }
        }

        //This works whilst interface is invariant
        //private static void AddManagers(IRepository<Employee> employeeRespository)
        //{
        //    employeeRespository.Add(new Manager{Name ="Dave"});
        //    employeeRespository.Commit();
        //}

        //private static void AddManagers(IRepository<Manager> employeeRespository)  //Not ContraVariant  will not work when interface converted to Contrvariant
        //{
        //    employeeRespository.Add(new Manager { Name = "Dave" });
        //    employeeRespository.Commit();
        //}

       private static void AddManagers(IWriteOnlyRepository<Manager> employeeRespository)  //Not ContraVariant  will not work when interface converted to Contrvariant
        {
            employeeRespository.Add(new Manager { Name = "Dave" });
            employeeRespository.Commit();
        }

        private static void DumpPeople(IRepository<Employee> employeeRespository)
        {
            var employees = employeeRespository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void DumpPeople(IRepository<Person> employeeRespository) //Not covariant, will never be called.
        {
            var employees = employeeRespository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void DumpPeopleCovariant(IReadOnlyRespository< Person> employeeRespository)    //Not covariant
        {
            var employees = employeeRespository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void QueryEmployee(IRepository<Employee> employeeRespository)
        {
            var employee = employeeRespository.FindById(1);
            Console.WriteLine(employee.Name);
        }

        private static void CountEmployees(IRepository<Employee> employeeRespository)
        {
            Console.WriteLine(employeeRespository.FindAll().Count());
        }

        private static void AddEmployees(IRepository<Employee> employeeRespository)
        {
            employeeRespository.Add (new  Employee {Name="Steve"});
            employeeRespository.Add(new Employee { Name = "Barry" });
            employeeRespository.Commit();
        }
    }

}
