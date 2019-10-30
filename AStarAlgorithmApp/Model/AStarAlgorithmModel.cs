using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AStarAlgorithmApp.Model
{

    /// <summary>
    /// Node representing cell of grid
    /// </summary>
    public class Node
    {
        public int X { get; set; }                                      // X coordinate
        public int Y { get; set; }                                      // Y coordinate
        public double F { get; set; }                                   // value of function F (sum of values of functions G and H)
        public double G { get; set; }                                   // value of G function (cost of the total distance from the starting point to the current one)
        public double H { get; set; }                                   // value of the heuristic H function (estimated cost of reaching the end point from the current point)
        public Node Parent;                                         // parent of the node (previous node)

        public bool IsOnDiagonalFromCurrent { get; set; } = false;      // variable determining whether the next neighbors downloaded is located diagonally from the current node
    }

    public class AStarAlgorithmModel : ViewModelBase
    {
 
        public Grid AStarGrid { get; set; }
        public int SizeOfCell { get; set; } = 25;

        public int SizeOfGrid { get; set; } = 20;

        public float CellWidthView { get; set; } = 25;

        public string StateOfDiode { get; set; }

        public Node StartNode { get; set; }                   
        public Node EndNode { get; set; }                 

        public List<Node> ObstacleNodeList { get; set; }


    }
}
