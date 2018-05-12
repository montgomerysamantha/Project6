using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Graph data structure, which holds Nodes (that have data)
/// and the edges between the Nodes if they exist.
/// 
/// The connectedness of the graph is represented using
/// a adjacency list, which is the Dictionary where the
/// keys are the Nodes and the value is a list of (KVP) all of 
/// the Nodes that that specific node is connected to. 
/// 
/// Note: the edges can also be weighted if needed. For this
/// project, all of the edge weights are just 1 for simplicity.
/// </summary>
namespace Project6
{
    public class Graph<TNode>
    {
        /*adjacency list where the keys are the nodes of the graph and the value
         * is a list of nodes that are adjacent to that node(the key)
         */
        private Dictionary<TNode, List<KeyValuePair<TNode, double>>> _adjList; 
        private List<TNode> _nodes; //all of the nodes (vertices) in the graph

        public Graph()
        {
            _adjList = new Dictionary<TNode, List<KeyValuePair<TNode, double>>>();
            _nodes = new List<TNode>();
        }

        public List<TNode> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        /// <summary>
        /// Adds a node to the graph
        /// </summary>
        /// <param name="node">The node to add</param>
        public void AddNode(TNode node)
        {
            //If node has not already been added, add it to the list of nodes
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
                //Create a new entry for it in the adjacency list with an empty list as its value
                List<KeyValuePair<TNode, double>> list = new List<KeyValuePair<TNode, double>>();
                _adjList.Add(node, list);
            }

        }

        /// <summary>
        /// Adds a (directed, weighted) edge to the graph bewtween
        /// two nodes passed in as parameters (start and stop)
        /// </summary>
        /// <param name="start">The source node of the edge</param>
        /// <param name="stop">The destination node of the edge</param>
        /// <param name="value">The weight of the edge</param>
        public void AddEdge(TNode start, TNode stop, double value)
        {
            //If either node has not already been added, call AddNode with them
            if (!_nodes.Contains(start)) //check for the start node
            {
                AddNode(start);
            }
            if (!_nodes.Contains(stop)) //check for the stop node
            {
                AddNode(stop);
            }
            //Add that edge to the adjacency list
            KeyValuePair<TNode, double> key = new KeyValuePair<TNode, double>(stop, value);
            _adjList[start].Add(key);
        }

        /// <summary>
        /// Finds the biggest edge either to or from a node
        /// </summary>
        /// <param name="n">A node in the graph</param>
        /// <param name="outgoing">True if we want an outgoing edge from n, and false
        /// if we want an edge incoming to n (with n as the destination)</param>
        /// <returns>A KeyValuePair representing the edge 
        /// (key: the other node on the edge, value: the weight of the edge)</returns>
        public KeyValuePair<TNode, double> MaxEdge(TNode n, bool outgoing)
        {
            //If outgoing is true, return the KeyValuePair (v,weight)
            //where n->v is the biggest outgoing edge from n, and weight is its edge weight
            KeyValuePair<TNode, double> key = new KeyValuePair<TNode, double>(default(TNode), double.MinValue);
            if (outgoing)
            {
                foreach (KeyValuePair<TNode, double> pair in _adjList[n])
                {
                    if (pair.Value >= key.Value)
                    {
                        key = pair;
                    }
                }
            }
            else
            {
                //If outgoing is false, return the KeyValuePair (v,weight)
                //where v->n is the biggest edge INCOMING to n, and weight is its edge weight
                //(This is harder to do -- you will need to search all through your adjacency list 
                //to find edges incoming to n. You will also need to create a new KeyValuePair, as one
                //will not be already stored in the list.)
                foreach (KeyValuePair<TNode, List<KeyValuePair<TNode, double>>> entry in _adjList)
                {
                    TNode node = entry.Key;
                    List<KeyValuePair<TNode, double>> list = entry.Value;
                    foreach (KeyValuePair<TNode, double> pair in list)
                    {
                        if (pair.Key.ToString() == n.ToString())
                        {
                            if (pair.Value >= key.Value)
                            {
                                key = new KeyValuePair<TNode, double>(node, pair.Value);
                            }
                        }
                    }
                }

            }
            return key;
        }

        /// <summary>
        /// A path (represented as a list) is made using Breadth First Search
        /// connecting the two nodes supplied by the parameters (start and stop).
        /// </summary>
        /// <param name="start">the starting node</param>
        /// <param name="stop">the ending node</param>
        /// <returns></returns>
        public List<TNode> BFS(TNode start, TNode stop)
        {
            Queue<TNode> q = new Queue<TNode>();
            Dictionary<TNode, TNode> prev = new Dictionary<TNode, TNode>();
            List<TNode> visit = new List<TNode>(); //the nodes we've visited
            q.Enqueue(start); //enqueue first node
            visit.Add(start); //visit first node

            while (q.Count > 0)
            {
                TNode n = q.Dequeue();
                List<KeyValuePair<TNode, double>> list = _adjList[n];

                foreach (KeyValuePair<TNode, double> k in list)
                {
                    if (!visit.Contains(k.Key))
                    {
                        visit.Add(k.Key);
                        q.Enqueue(k.Key);
                        prev.Add(k.Key, n);
                    }
                }
            }

            List<TNode> path = new List<TNode>();
            TNode node = stop;
            path.Add(stop); //add initial stop node
            while (!node.Equals(start))
            {   
                path.Add(prev[node]);
                node = prev[node];
            }

            path.Reverse();

            return path;
        }
    }
}
