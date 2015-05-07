using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSplit
{
    static 
    class Program
    {
        static 
        void 
        Main(
                string[] args)
        {
            var items =                 
                Enumerable.Range(0, 49)
                .ToList();

            items
            .Chunk(10)
            .Select(
                subSet =>
                {
                    var list = subSet.ToList();

                    Console.WriteLine("Subs et from {0} with length = {1}", list[0], list.Count);

                    return 1;
                })
            .Sum();
        
        }

        static
        IEnumerable<
            IEnumerable<T>>
        Chunk<T>(
            this                
            IEnumerable<T>                      items,
            int                                 chunkSize)
        {
            var enumerator = items.GetEnumerator();

            while(enumerator.MoveNext())
                yield return enumerator.Chunk(chunkSize);
        }

        static
        IEnumerable<T>
        Chunk<T>(
            this
            IEnumerator<T>                      items,
            int                                 chunkSize)
        {
            do
            {
                yield return items.Current;
            } 
            while (--chunkSize > 0 && items.MoveNext());
        }
    }

}
