using System.Collections.Generic;

namespace Main
{
    class PriorityQueue
    {
        /*It's my basic implementation of a Min-heap priority queue. The formulas are this:
		  Search Left child: 2n + 1;
		  Search Right child: 2n + 2;
		  Search Parent: (n-1)/2;
		  where "n" is the actual index array. A Priority Queue has two sort methods, minimum and maximum heap. A heap is a data structure that transforms from a 
          complete binary tree to an array. In a minimum heap, parents < children and in a maximum heap, parents > children*/

        private List<Node> queue = null;

        public PriorityQueue()
        {
            queue = new List<Node>();
        }

        public void pushMinHeap(Node node)
        {
            queue.Add(node);                                                    //when add a new node, it's added at the last array position, the result
            int index = queue.Count - 1;                                        // is that binary tree will be breaking heap rules and the new node will need to search it position.
            while (index > 0 && queue[index].getDistance().CompareTo(queue[(index - 1) / 2].getDistance()) == -1) //How the new node it's in the last array position, it's a child, and
            {                                                                                               //it needs to search it parent position.                                 
                Node auxNode = queue[index];
                queue[index] = queue[(index - 1) / 2];
                queue[(index - 1) / 2] = auxNode;
                index = (index - 1) / 2;
            }
        }

        public Node removeMinHeap()
        {
            Node node = queue[0];
            queue[0] = queue[queue.Count - 1];  //When remove a node, the last node is ubicated in the root and it will be breaking heap rules.
            queue.RemoveAt(queue.Count - 1);
            int index = 0;
            while (index < queue.Count - 1) //The array needs to get sorted to hold heap rules
            {
                if (2 * index + 1 < queue.Count && queue[index].getDistance().CompareTo(queue[2 * index + 1].getDistance()) == 1) //Check if left child is bigger than it queue[index]
                {                                                                                                          //(it parent)
                    Node auxNode = queue[index];
                    queue[index] = queue[2 * index + 1];
                    queue[2 * index + 1] = auxNode;
                }
                if (2 * index + 2 < queue.Count && queue[index].getDistance().CompareTo(queue[2 * index + 2].getDistance()) == 1) //Check if right child is bigger than it queue[index]
                {                                                                                                           //(it parent)
                    Node auxNode = queue[index];
                    queue[index] = queue[2 * index + 2];
                    queue[2 * index + 2] = auxNode;
                }
                index++;
            }
            return node;
        }

        public int Count()
        {
            return queue.Count;
        }
    }
}