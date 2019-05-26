using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DelegatesAndEvents
{
    public static class IReferenceDataSourceCollectionsExtensions
    {


        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IEnumerable sources, string code)
        {

            var items = new List<ReferenceDataItem>();

            foreach (var source in sources)
            {
                var refDataSource = source as IReferenceDataSource;
                if (refDataSource != null) { 

                items.AddRange(refDataSource.GetItemsByCode(code));
            }

            }

            return items;
        }

        public static IEnumerable<ReferenceDataItem> GetAllIemsByCode(this IEnumerable<ReferenceDataSource> sources, string code)
        {

            return sources.SelectMany(x => x.GetItemsByCode(code));

        }



    }
}
