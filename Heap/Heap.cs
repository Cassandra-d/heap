using System;

namespace Heap
{
    public class Heap
    {
        private int[] storage = new int[100];
        private int cnt = 0;

        public Heap(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Insert(arr[i]);
        }

        public Heap() { }

        public int Peek()
        {
            return storage[0];
        }

        public int ExtractRoot()
        {
            if (cnt == 0)
                return 0;

            var min = storage[0];
            var lastItemIdx = cnt - 1;

            int i = 0;
            storage[i] = storage[lastItemIdx];
            storage[lastItemIdx] = 0;
            cnt -= 1;

            HeapifyDown(i);

            return min;
        }

        public int KthLargest(int k)
        {
            int res = 0;
            while (k != 0)
            {
                res = ExtractRoot();
                k -= 1;
            }
            return res;
        }

        public void Insert(int val)
        {
            if (storage.Length == cnt)
                Reallocate();

            int i = cnt;
            storage[i] = val;

            HeapifyUp(i);
            cnt += 1;
        }

        private void HeapifyUp(int i)
        {
            int parentIdx = (i - 1) / 2;
            while (storage[i] > storage[parentIdx])
            {
                Swap(i, parentIdx);
                i = parentIdx;
                parentIdx = (parentIdx - 1) / 2;
            }
        }

        private void HeapifyDown(int i)
        {
            while (i * 2 + 1 < cnt)
            {
                var twoI = i * 2;
                int largestIndexPart = storage[twoI + 2] > storage[twoI + 1] ? 2 : 1;

                if (storage[i] < storage[twoI + largestIndexPart])
                {
                    Swap(i, twoI + largestIndexPart);
                    i = twoI + largestIndexPart;
                }
                else
                    break;
            }
        }

        public void Delete(int val)
        {
            int i = 0;
            while (i < cnt && storage[i] != val)
                ++i;
            if (i >= cnt)
                return;

            int last = storage[cnt - 1];
            cnt -= 1;
            storage[i] = last;

            int parent = (i - 1) / 2;
            if (storage[i] < storage[parent] || i == 0)
                HeapifyDown(i);
            else if (storage[i] > storage[parent])
                HeapifyUp(i);
        }

        private void Reallocate()
        {
            int[] tmp = new int[storage.Length * 3];
            Array.Copy(storage, 0, tmp, 0, storage.Length);
            storage = tmp;
        }

        private void Swap(int a, int b)
        {
            var tmp = storage[a];
            storage[a] = storage[b];
            storage[b] = tmp;
        }
    }
}
