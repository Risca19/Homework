using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgChart
{
    class Employee
    {
        public string Name { get; set; }
        private Employee _supervisor;
        public Employee Supervisor
        {
            get
            {
                set {// public void SetSupervisor(Employee value)
                    _supervisor?.Minions?.Remove(this);
                    _supervisor = value;
                    ValueType.Minions.Add(this);
                }
            }
            public IList<Employee> Minions { get; set; }

            public Employee()
        {
                Minions = new List<Employee>();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var bill = new Employee("Bill");

                var sam = new Employee("Sam");
                var jane = new Employee("Jane");
                var fred = new Employee("Fred");
                var alice = new Employee("Alice");

                var employees = new List<Employee> {
                    bill,
                    sam,
                    jane,
                    fred,
                    alice,
                };

                sam.Supervisor = bill;
                jane.Supervisor = bill;
                fred.Supervisor = bill;
                alice.Supervisor = fred;

                foreach (var emp in employees) {

                    Console.WriteLine("{0} has {1} minions.\n{0} reports to {2}",
                        emp.Name, emp.ReportCount,
                        emp.Supervisor == null ? "nobody" : emp.Supervisor.Name);
                }

            }
        }
    }
