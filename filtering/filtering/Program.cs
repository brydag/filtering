using System;
using System.Collections.Generic;
using System.Linq;
using filtering.Models;
using FilteringMechanism;
using FilteringMechanism.FilterOperators;
using FilteringMechanism.FilterOperators.LogicalOperators;
using FilteringMechanism.FilterOperatorsExtensions;

namespace filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            IQueryable<Employee> query = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "aa XXx1 dd  c",
                    LastName = "aa yyyy1 v v",
                    Subordinates =  new List<Person>{
                        new Person
                        {
                            Name = "Some person"
                        },
                        new Person
                        {
                            Name = "Some person"
                        }
                    }
                },
                new Employee()
                {
                    FirstName = "aa xxx3 dd  c",
                    LastName = "aa yyyy1 v v",
                },
                new Employee()
                {
                    FirstName = "aa xxx2 dd  c",
                    LastName = "aa yyyy1 v v",
                    Subordinates =  new List<Person>
                    {
                        new Person
                        {
                            Name = "Some person"
                        },
                        new Person
                        {
                            Name = "Some person"
                        },
                    }
                },
            }.AsQueryable();

             var filterElement = new FilterCollection<Employee>()
             {
                 Elements = new List<IFilterElement>
                 {
                     new FilterCollection<Employee>()
                     {
                         Elements = new List<IFilterElement>
                         {
                             new FilterElement
                             {
                                 Property = "FirstName",
                                 Operator = new ToLowerDecorator(new TrimDecorator(new ContainsOperator())),
                                 Value = "xxx1"
                             },
                             new FilterElement
                             {
                                 Property = "Subordinates",
                                 Operator = new CountOperator(),
                                 Value = 2
                             },
                         },
                         Operator = new OrOperator()
                     },
                     new FilterElement
                     {
                         Property = "LastName",
                         Operator = new ContainsOperator(),
                         Value = "yyyy1"
                     },
                 },
                 Operator = new AndOperator()
             };

            var result = query.Filter(filterElement).ToList();
        }
    }
}
