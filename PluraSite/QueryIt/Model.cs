using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public interface IEntity
    {
        bool IsValid();
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person, IEntity
    {
        public int Id { get; set; }

        public virtual void DoWork()
        {
            Console.WriteLine((""));
        }

        public bool IsValid()
        {
            return true;
        }
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine(("Create a meeting"));
        }
    }

}
