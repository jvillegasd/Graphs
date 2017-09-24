namespace Main
{
    class Edge
    {
    	private Node initialNode = null;
    	private Node finalNode = null;
    	private int weight = 0;

    	public Edge(Node initialNode, Node finalNode, int weight)
        {
    		this.initialNode = initialNode;
    		this.finalNode = finalNode;
    		this.weight = weight;
    	}

    	public Node getInitialNode(){
    		return this.initialNode;
    	}

    	public Node getFinalNode(){
    		return this.finalNode;
    	}

    	public int getWeight(){
    		return this.weight;
    	}
        
        public bool Equals(Edge edge) //"Overwrite" Equals() function
        {
            if (this.initialNode.getInfo().Equals(edge.getInitialNode().getInfo()) && this.finalNode.getInfo().Equals(edge.getFinalNode().getInfo()))
            {
                return true;
            }
            return false;
        }
    }
}
