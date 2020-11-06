using System.Diagnostics;

namespace Heap
{
    public class Tests
    {
        private static int[] Array1 = new[] { 7, 6, 5, 4, 3, 2, 1 };

        public void Test1()
        {
            var h = new Heap(Array1);
            Debug.Assert(7 == h.Peek());
        }

        public void Test2()
        {
            var h = new Heap(Array1);
            var res = h.KthLargest(4);
            Debug.Assert(4 == res);
        }

        public void Test3()
        {
            var h = new Heap(Array1);
            h.ExtractRoot();
            h.ExtractRoot();
            h.ExtractRoot();
            h.ExtractRoot();
            Debug.Assert(3 == h.Peek());
        }
    }
}
