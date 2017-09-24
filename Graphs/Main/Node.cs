using System;
using System.Collections.Generic;

namespace Main
{
    class Node
    {
        //distance, isVisited and shortestPath variables are only for Dijkstra Algorithm use

        private String info;
        private List<Edge> incidentEdges = null;
        private int distance;
        private bool isVisited;
        private List<Node> shortestPath;

        public Node(String info)
        {
            this.info = info;
            incidentEdges = new List<Edge>();
        }

        public List<Edge> getIncidentEdges()
        {
            return incidentEdges;
        }

        public  int getDistance()
        {
            return distance;
        }

        public void setDistance(int distance)
        {
            this.distance = distance;
        }

        public String getInfo()
        {
            return info;
        }

        public void setIsVisited(bool isVisited)
        {
            this.isVisited = isVisited;
        }

        public bool getIsVisited()
        {
            return isVisited;
        }

        public bool Equals(Node node) //"Overwrite" Equals() function
        {
            if (info.Equals(node.getInfo()))
            {
                return true;
            }
            return false;
        }

        public void setShortestPath(List<Node> shortestPath)
        {
            this.shortestPath = shortestPath;
        }

        public List<Node> getShortestPath()
        {
            return shortestPath;
        }

        public void startDijkstra(int vertexNumber)
        {
            distance = int.MaxValue;
            isVisited = false;
            shortestPath = new List<Node>();
        }
    }
}