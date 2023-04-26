using System;
namespace HeapData
{
	public class HeapTry
	{
        static void Main(string[] args)
        {

            Heap<int> myHeap = new Heap<int>( );

            myHeap.Insert(5);
            myHeap.Insert(10);
            myHeap.Insert(3);
            myHeap.Insert(8);
            myHeap.Insert(7);
            myHeap.Insert(2);
            myHeap.Insert(6);
            myHeap.Insert(1);
            myHeap.Insert(9);
            myHeap.Insert(4);

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(myHeap.RootNode( ));
                myHeap.Delete( );
            }

        }
    }
}

