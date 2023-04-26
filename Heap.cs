using System;

namespace HeapData
{
    public class Heap<T>
    {
        
        private List<int> data;

        public Heap( )
        {
            data = new List<int>( );
        }

        public int RootNode( )
        {
            return data[0];
        }

        public int LastNode( )
        {
            return data[data.Count - 1];
        }

        public int LeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        public int RightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        public int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public void Insert(int value)
        {
            data.Add(value);
            int newNodeIndex = data.Count - 1;

            while(newNodeIndex > 0 && data[newNodeIndex] >
                   data[ParentIndex(newNodeIndex)])
            {
                int parentIndex = ParentIndex(newNodeIndex);
                int temp = data[parentIndex];
                data[parentIndex] = data[newNodeIndex];
                data[newNodeIndex] = temp;
                newNodeIndex = parentIndex;
            }
        }

        public void Delete( )
        {
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            int trickleNodeIndex = 0;

            while(HasGreaterChild(trickleNodeIndex))
            {
                int largerChildIndex = CalculateLargerChildIndex(trickleNodeIndex);
                int temp = data[trickleNodeIndex];
                data[trickleNodeIndex] = data[largerChildIndex];
                data[largerChildIndex] = temp;

                trickleNodeIndex = largerChildIndex;
            }
        }

        private bool HasGreaterChild(int index)
        {
            bool hasLeftChild = LeftChildIndex(index) < data.Count;
            bool hasRightChild = RightChildIndex(index) < data.Count;

            if(hasLeftChild && hasRightChild)
            {
                return data[LeftChildIndex(index)] > data[index] || data[RightChildIndex(index)] > data[index];
            }
            else if(hasLeftChild)
            {
                return data[LeftChildIndex(index)] > data[index];
            }
            else
            {
                return false;
            }
        }

        private int CalculateLargerChildIndex(int index)
        {
            int leftChildIndex = LeftChildIndex(index);
            int rightChildIndex = RightChildIndex(index);

            if(rightChildIndex < data.Count && data[rightChildIndex] > data[leftChildIndex])
            {
                return rightChildIndex;
            }
            else
            {
                return leftChildIndex;
            }
        }

    }
}