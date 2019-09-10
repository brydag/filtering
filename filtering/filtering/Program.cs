using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace filtering
{
    class Program
    {
        class TissueSample
        {
            public TissueType TissueType { get; set; }
            public ICollection<TissueType> TissueTypes { get; set; }
            public int Count { get; set; }
        }

        class TissueType
        {
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IQueryable<TissueType> query = Enumerable.Empty<TissueType>().AsQueryable();

           // sample => (sample.TissueType.Name.Contains("xxx1") || sample.TissueType.Name.Contains("xxx2"))
             //         && sample.FixativeUsed.Name.Contains("yyyy1")

             var filterElement = new FilterCollection<TissueType>()
             {
                 Elements = new List<IFilterElement>
                 {
                     new FilterCollection<TissueType>()
                     {
                         Elements = new List<IFilterElement>
                         {
                             new FilterElement
                             {
                                 Property = "TissueType.Name",
                                 Operator = FilteringOperator.Contains,
                                 Value = "xxx1"
                             },
                             new FilterElement
                             {
                                 Property = "TissueType.Name",
                                 Operator = FilteringOperator.Contains,
                                 Value = "xxx2"
                             },
                         },
                         Operator = FilterCollectionOperator.Or
                     },
                     new FilterElement
                     {
                         Property = "FixativeUsed.Name",
                         Operator = FilteringOperator.Contains,
                         Value = "yyyy1"
                     },
                 },
                 Operator = FilterCollectionOperator.And
             };


            //var tissueSamples = query.Where(condition).ToList();
            var tissueSamples = query.Filter(filterElement).ToList();
            var aaa = 1;
        }
    }
}
