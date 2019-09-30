using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FilteringMechanism;
using FilteringMechanism.FilterOperators;
using FilteringMechanism.FilterOperatorsExtensions;

namespace filtering
{
    class Program
    {
        //class TissueSample
        //{
        //    public TissueType TissueType { get; set; }
        //    public FixativeUsed FixativeUsed { get; set; }
        //    public ICollection<TissueType> TissueTypes { get; set; }
        //    public int Count { get; set; }
        //}

        //class TissueType
        //{
        //    public string Name { get; set; }
        //}

        //class FixativeUsed
        //{
        //    public string Name { get; set; }
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            IQueryable<Employee> query = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "aa XXx1 dd  c",
                    LastName = "aa yyyy1 v v",
                    Subordinates =  new Collection<Person>{new Person(),new Person()}
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
                    Subordinates =  new Collection<Person>
                    {
                        new Person
                        {
                            Name = "Some person"
                        },
                        new Person()
                    }
                },
            }.AsQueryable();

           // sample => (sample.TissueType.Name.Contains("xxx1") || sample.TissueType.Name.Contains("xxx2"))
             //         && sample.FixativeUsed.Name.Contains("yyyy1")

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
                             //new FilterElement
                             //{
                             //    Property = "Subordinates",
                             //    Operator = new CountOperator(),
                             //    Value = 2
                             //},
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


            //var tissueSamples = query.Where(condition).ToList();
            var result = query.Filter(filterElement).ToList();
            var aaa = 1;
        }
    }
}
