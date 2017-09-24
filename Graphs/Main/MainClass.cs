using System;

namespace Main
{
    class MainClass
    {
        static void Main(string[] args)
        {

            Console.Read();
        }

        public void firstExample()
        {
            Graph graph = new Graph(false);
            graph.addNode("1");
            graph.addNode("2");
            graph.addNode("3");
            graph.addNode("4");
            graph.addNode("5");
            graph.addNode("6");
            graph.addNode("7");
            graph.addNode("8");
            graph.addNode("9");
            graph.addNode("10");
            graph.addNode("11");
            Node node1 = graph.getNode("1");
            Node node2 = graph.getNode("2");
            Node node3 = graph.getNode("3");
            Node node4 = graph.getNode("4");
            Node node5 = graph.getNode("5");
            Node node6 = graph.getNode("6");
            Node node7 = graph.getNode("7");
            Node node8 = graph.getNode("8");
            Node node9 = graph.getNode("9");
            Node node10 = graph.getNode("10");
            Node node11 = graph.getNode("11");
            graph.addEdge(node1, node4, 13, 0);
            graph.addEdge(node2, node1, 1, 0);
            graph.addEdge(node1, node7, 2, 0);
            graph.addEdge(node3, node1, 25, 0);
            graph.addEdge(node3, node2, 2, 0);
            graph.addEdge(node3, node5, 30, 0);
            graph.addEdge(node7, node4, 12, 0);
            graph.addEdge(node7, node6, 17, 0);
            graph.addEdge(node7, node10, 8, 0);
            graph.addEdge(node10, node9, 8, 0);
            graph.addEdge(node5, node2, 5, 0);
            graph.addEdge(node5, node8, 14, 0);
            graph.addEdge(node9, node5, 15, 0);
            graph.addEdge(node8, node11, 6, 0);
            graph.addEdge(node6, node3, 11, 0);
            graph.addEdge(node6, node9, 9, 0);
            graph.addEdge(node8, node9, 3, 0);
            graph.addEdge(node11, node10, 7, 0);
            graph.addEdge(node5, node6, 4, 0);
            graph.dijkstraAlgorithm(node1);
            graph.printPath(node11);
            graph.distanceFrom();
        }

        public void secondExample()
        {
            Graph graph = new Graph(false);
            graph.addNode("0");
            graph.addNode("1");
            graph.addNode("2");
            graph.addNode("3");
            graph.addNode("4");
            Node node0 = graph.getNode("0");
            Node node1 = graph.getNode("1");
            Node node2 = graph.getNode("2");
            Node node3 = graph.getNode("3");
            Node node4 = graph.getNode("4");
            graph.addEdge(node0, node2, 3, 0);
            graph.addEdge(node2, node3, 7, 0);
            graph.addEdge(node4, node2, 6, 0);
            graph.addEdge(node3, node4, 8, 0);
            graph.addEdge(node1, node4, 5, 0);
            graph.addEdge(node1, node0, 2, 0);
            graph.addEdge(node2, node1, 4, 0);
            graph.addEdge(node3, node1, 1, 0);
            graph.dijkstraAlgorithm(node0);
            graph.printPath(node0);
        }
    }
}