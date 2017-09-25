using System;
using System.Collections.Generic;

namespace Main
{
    class Graph
    {
        private List<Node> nodes = null;
        private List<Edge> edges = null;
        private List<Node> parentsPath = null;  //This both list<Node> (parentsPath and childrenPath) saves all parents and children nodes with shortest path
        private List<Node> childrenPath = null;
        private bool isDirected = false;

        public Graph(bool isDirected)
        {
            nodes = new List<Node>();
            edges = new List<Edge>();
            parentsPath = new List<Node>();
            childrenPath = new List<Node>();
            this.isDirected = isDirected;
        }

        public void addNode(String info)
        {
            Node newNode = new Node(info);
            bool found = false;
            foreach (Node node in this.nodes)
            {
                if (node.Equals(newNode))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                nodes.Add(newNode);
            }
        }

        public void addEdge(Node initialNode, Node finalNode, int weight, int cont)
        {
            Edge newEdge = new Edge(initialNode, finalNode, weight);
            bool found = false;
            foreach (Edge edge in edges)
            {
                if (edge.Equals(newEdge))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                if (isDirected)
                {
                    initialNode.getIncidentEdges().Add(newEdge);
                }
                else
                {
                    if (cont == 0)
                    {
                        initialNode.getIncidentEdges().Add(newEdge);
                        addEdge(finalNode, initialNode, weight, 1);
                    }
                    else
                    {
                        initialNode.getIncidentEdges().Add(newEdge);
                    }
                }  
            }
            edges.Add(newEdge);
        }

        public Node getNode(String info)
        {
            foreach (Node node in nodes)
            {
                if (node.getInfo().Equals(info))
                {
                    return node;
                }
            }
            return null;
        }

        public void dijkstraAlgorithm(Node initialNode)
        {
            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.pushMinHeap(initialNode);
            parentsPath.Clear();
            childrenPath.Clear();
            foreach (Node node in nodes)
            {
                node.startDijkstra(nodes.Count);
            }
            initialNode.setDistance(0);
            while (priorityQueue.Count() != 0)
            {
                Node actualNode = priorityQueue.removeMinHeap();
                if (actualNode.getIsVisited())
                {
                    continue;
                }
                actualNode.setIsVisited(true);
                foreach (Edge edge in actualNode.getIncidentEdges())
                {
                    Node adjacentNode = edge.getFinalNode();
                    if (!adjacentNode.getIsVisited())
                    {
                        int weight = edge.getWeight();
                        calculateDistance(actualNode, adjacentNode, weight, priorityQueue, parentsPath, childrenPath);
                    }
                }
            }
        }

        private void calculateDistance(Node actualNode, Node adjacentNode, int weight, PriorityQueue priorityQueue, List<Node> pPath, List<Node> cPath)
        {
            if (actualNode.getDistance() + weight < adjacentNode.getDistance())
            {
                adjacentNode.setDistance(actualNode.getDistance() + weight);
                pPath.Add(actualNode);
                cPath.Add(adjacentNode);
                priorityQueue.pushMinHeap(adjacentNode);
            }
        }

        public void printPath(Node finalNode)                        //This both list<Node> have all nodes with shortest path. In a index of parentsPath it child is ubicated
        {                                                            //in the same index in childrenPath
            int indexC = childrenPath.Count - 1;
            Node auxNode = childrenPath[indexC];
            while (indexC > 0 && !auxNode.Equals(finalNode))  //Search finalNode position in childrenPath
            {
                indexC--;
                auxNode = childrenPath[indexC];
            }
            if (auxNode.Equals(finalNode))
            {
                String path = auxNode.getInfo();
                while (indexC > 0)                                
                {
                    path = path + " " + parentsPath[indexC].getInfo();  //Concatenate it parent
                    Node parentNode = parentsPath[indexC];
                    while (indexC > 0 && !auxNode.Equals(parentNode))  //Now, search the parent of parent, in this case the previous parent in now a child
                    {
                        indexC--;
                        auxNode = childrenPath[indexC];
                    }
                    parentNode = null;
                }
                auxNode = null;
                path = reverseString(path);            
                Console.WriteLine("Path from node {0} to node {1} is: \n" + path, parentsPath[0].getInfo(), finalNode.getInfo());
            }
            else
            {
                Console.WriteLine("Final node isn't in the graph or it's a remote node");
            }
        }

        private String reverseString(String str)
        {
            String[] splitedPath = str.Split();
            str = "";
            for (int i = splitedPath.Length - 1; i >= 0; i--)
            {
                if (i == splitedPath.Length - 1)
                {
                    if (!splitedPath[i].Equals(parentsPath[0].getInfo()))  //Case when concatenating path and the loop in printPath() doesn't enter to concatenate initialNode
                    {
                        str = parentsPath[0].getInfo() + " -> " + splitedPath[i];
                    }
                    else
                    {
                        str = splitedPath[i];
                    }
                    
                }
                else
                {
                    str = str + " -> " + splitedPath[i];
                }
            }
            return str;
        }

        public void distanceFrom()
        {
            Console.WriteLine("\nDistances from node {0}:\n", parentsPath[0].getInfo());
            foreach (Node node in nodes)
            {
                Console.WriteLine("Node {0} to node {1} is {2}", parentsPath[0].getInfo(), node.getInfo(), node.getDistance());
            }
            Console.WriteLine();
        }
    }
}