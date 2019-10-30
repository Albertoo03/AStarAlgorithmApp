using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using AStarAlgorithmApp.Model;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using AStarAlgorithmApp.View;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AStarAlgorithmApp.ViewModel
{

    public class MainViewModel : ViewModelBase
    {


        #region Private variables

        private bool IsProgramRunning = false;
        private bool IsStartingPointSet = false;
        private bool IsEndPointSet = false;
        private bool IsStartingPointButtonSet = false;
        private bool IsEndPointButtonSet = false;
        private bool IsSetObstacleButtonSet = false;


        private AStarAlgorithmModel aStarModel = new AStarAlgorithmModel();     // creating an instance of the model class

        private int _sizeOfGridView = 20;
        private float _viewScale;
        private string _costOfTrack;
        private string _algorithmDuration;
        private float _sizeOfWindow = 500;


        private RelayCommand _startAlgorithmCommand;
        private RelayCommand _stopAlgorithmCommand;
        private RelayCommand _setStartingPointCommand;
        private RelayCommand _setEndPointCommand;
        private RelayCommand _setObstaclesCommand;
        private RelayCommand _setParametersCommand;
        private RelayCommand _leftMouseDoubleClickCommand;
        private RelayCommand _rightMouseDoubleClickCommand;
        private RelayCommand _clearMapCommand;
        private RelayCommand _acceptChangesCommand;

        #endregion

        #region Properties

        public Node StartNode
        {
            get
            {
                return aStarModel.StartNode;
            }
            set
            {
                aStarModel.StartNode = value;
                RaisePropertyChanged(() => StartNode);
            }
        }

        public Node EndNode
        {
            get
            {
                return aStarModel.EndNode;
            }
            set
            {
                aStarModel.EndNode = value;
                RaisePropertyChanged(() => EndNode);
}
        }

        public List<Node> ObstacleNodeList
        {
            get
            {
                if(aStarModel.ObstacleNodeList == null)
                {
                    aStarModel.ObstacleNodeList = new List<Node>();
                }
                return aStarModel.ObstacleNodeList;
            }
            set
            {
                aStarModel.ObstacleNodeList = value;
                RaisePropertyChanged(() => ObstacleNodeList);
            }
        }

        public Grid AStarGrid
        {
            get
            {
                if (aStarModel.AStarGrid == null)
                {
                    aStarModel.AStarGrid = new Grid();
                }
                return aStarModel.AStarGrid;
            }
            set
            {
                aStarModel.AStarGrid = value;
                RaisePropertyChanged(() => AStarGrid);
            }
        }

        public int SizeOfGrid
        {
            get
            {
                return aStarModel.SizeOfGrid;
            }
            set
            {
                aStarModel.SizeOfGrid = value;

                if (SizeOfGrid < NumOfCellsToDisplay)
                {
                    NumOfCellsToDisplay = SizeOfGrid;
                }
                _viewScale = _sizeOfWindow / (float)NumOfCellsToDisplay;
                RaisePropertyChanged(() => SizeOfGrid);
            }
        }

        public int NumOfCellsToDisplay
        {
            get
            {
                return _sizeOfGridView;
            }
            set
            {
                _sizeOfGridView = value;
                WidthOfCellInView = _sizeOfWindow / (float)NumOfCellsToDisplay;
                _viewScale = _sizeOfWindow / (float)NumOfCellsToDisplay;
                RaisePropertyChanged(() => NumOfCellsToDisplay);
            }
        }

        public float WidthOfCellInView
        {
            get
            {
                return aStarModel.CellWidthView;
            }
            set
            {
                aStarModel.CellWidthView = value;
                RaisePropertyChanged(() => WidthOfCellInView);
            }
        }

        public string CostOfTrack
        {
            get
            {
                return _costOfTrack;
            }
            set
            {
                _costOfTrack = value;
                RaisePropertyChanged(() => CostOfTrack);
            }
        }
        public string AlgorithmDuration
        {
            get
            {
                return _algorithmDuration;
            }
            set
            {
                _algorithmDuration = value;
                RaisePropertyChanged(() => AlgorithmDuration);
            }
        }

        public string StateOfDiode
        {
            get
            {
                return aStarModel.StateOfDiode;
            }
            set
            {
                aStarModel.StateOfDiode = value;
                RaisePropertyChanged(() => StateOfDiode);
            }
        }

        #endregion



        #region Command support
        public ICommand StartAlgorithmCommand
        {
            get
            {
                if (_startAlgorithmCommand == null)
                {
                    _startAlgorithmCommand = new RelayCommand(() => StartAlgorithm());
                }
                return _startAlgorithmCommand;
            }
        }

        public ICommand StopAlgorithmCommand
        {
            get
            {
                if (_stopAlgorithmCommand == null)
                {
                    _stopAlgorithmCommand = new RelayCommand(() => StopAlgorithm());
                }
                return _stopAlgorithmCommand;
            }
        }

        public ICommand SetParametersCommand
        {
            get
            {
                if (_setParametersCommand == null)
                {
                    _setParametersCommand = new RelayCommand(() => SetParameters());
                }
                return _setParametersCommand;
            }
        }
        public ICommand SetStartingPointCommand
        {
            get
            {
                if (_setStartingPointCommand == null)
                {
                    _setStartingPointCommand = new RelayCommand(() => SetStartingPoint());
                }
                return _setStartingPointCommand;
            }
        }
        public ICommand SetEndPointCommand
        {
            get
            {
                if (_setEndPointCommand == null)
                {
                    _setEndPointCommand = new RelayCommand(() => SetEndPoint());
                }
                return _setEndPointCommand;
            }
        }

        public ICommand SetObstaclesCommand
        {
            get
            {
                if (_setObstaclesCommand == null)
                {
                    _setObstaclesCommand = new RelayCommand(() => SetObstacles());
                }
                return _setObstaclesCommand;
            }
        }
        public ICommand LeftMouseDoubleClickCommand
        {
            get
            {
                if (_leftMouseDoubleClickCommand == null)
                {
                    _leftMouseDoubleClickCommand = new RelayCommand(() => LeftMouseDoubleClick());
                }
                return _leftMouseDoubleClickCommand;
            }
        }
        public ICommand RightMouseDoubleClickCommand
        {
            get
            {
                if (_rightMouseDoubleClickCommand == null)
                {
                    _rightMouseDoubleClickCommand = new RelayCommand(() => RightMouseDoubleClick());
                }
                return _rightMouseDoubleClickCommand;
            }
        }

        public ICommand ClearGridCommand
        {
            get
            {
                if (_clearMapCommand == null)
                {
                    _clearMapCommand = new RelayCommand(() => ClearGridAndCreateNew());
                }
                return _clearMapCommand;
            }
        }

        public ICommand AcceptChangesCommand
        {
            get
            {
                if (_acceptChangesCommand == null)
                {
                    _acceptChangesCommand = new RelayCommand(() => AcceptChanges());
                }
                return _acceptChangesCommand;
            }
        }

        #endregion



        #region Command functions

        /// <summary>
        /// Start algorithms and draws path 
        /// </summary>
        private void StartAlgorithm()
        {

            if (IsStartingPointSet && IsEndPointSet)
            {
                var element = LogicalTreeHelper.FindLogicalNode(AStarGrid, "Path");
                while (element != null)
                {
                    element = LogicalTreeHelper.FindLogicalNode(AStarGrid, "Path");         // znajdz wezly sciezki
                    AStarGrid.Children.Remove((UIElement)element);                              // usun sciezke z siatki
                }

                List<Node> finalPath = AStarAlgorithm.GeneratePath(StartNode, EndNode, ObstacleNodeList, SizeOfGrid, ref _costOfTrack, ref _algorithmDuration);
                RaisePropertyChanged(() => CostOfTrack);
                RaisePropertyChanged(() => AlgorithmDuration);

                Point point = new Point();
                Point previousPoint = new Point();

                foreach (var node in finalPath)
                {

                    DrawPath(ref previousPoint, ref point, node);

                }

                StateOfDiode = "Green";
                IsProgramRunning = true;
                IsStartingPointButtonSet = false;
                IsEndPointButtonSet = false;
                IsSetObstacleButtonSet = false;
            }
            else
            {
                MessageBox.Show("Set algorithm parameters first");
            }



        }


        private void StopAlgorithm()
        {
            if (IsProgramRunning == true)
            {
                StateOfDiode = "Red";
                IsProgramRunning = false;
            }
            else
            {
                MessageBox.Show("Program is already stopped");
            }

        }


        private void SetParameters()
        {
            if (IsProgramRunning == false)
            {
                this.SetAlgorithmParameters();
            }
            else
            {
                MessageBox.Show("Program is already started! Stop the program and try again.");
            }

        }


        private void SetStartingPoint()
        {
            if (IsProgramRunning == false)
            {
                IsStartingPointButtonSet = true;
                IsEndPointButtonSet = false;
                IsSetObstacleButtonSet = false;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop the program and try again.");
            }
        }


        private void SetEndPoint()
        {
            if (IsProgramRunning == false)
            {
                IsStartingPointButtonSet = false;
                IsEndPointButtonSet = true;
                IsSetObstacleButtonSet = false;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop the program and try again.");
            }
        }


        private void SetObstacles()
        {
            if (IsProgramRunning == false)
            {
                IsStartingPointButtonSet = false;
                IsEndPointButtonSet = false;
                IsSetObstacleButtonSet = true;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop the program and try again.");
            }
        }


        private void ClearGridAndCreateNew()
        {
            if (this.IsProgramRunning == false)         // jesli program nie jest uruchomiony
            {
                AStarGrid.Children.Clear();             // czysc siatke
                ObstacleNodeList.Clear();                   // wyczysc liste przeszkod
                CreateGrid(SizeOfGrid);      // stworz nowa siatke o takich samych wymiarach

                StartNode = null;
                EndNode = null;
                IsStartingPointSet = false;         // ustaw flage na false (flaga informujaca czy punkt startowy zostal juz ustawiony)
                IsEndPointSet = false;           // ustaw flage na false (flaga informujaca czy punkt koncowy zostal juz ustawiony)

            }
            else
            {
                MessageBox.Show("Program is already started! Stop the program and try again.");
            }
        }

        private void AcceptChanges()
        {
            Debug.WriteLine($"Grid width: {SizeOfGrid}");
            Debug.WriteLine($"Cell width: {WidthOfCellInView}");
            _viewScale = (float)SizeOfGrid / (float)NumOfCellsToDisplay;
            ClearGridAndCreateNew();
        }

        #endregion



        #region Mouse handling

        /// <summary>
        /// Left mouse button handling
        /// </summary>
        private void LeftMouseDoubleClick()
        {

            Point clickedPoint = Mouse.GetPosition(AStarGrid);

            Node clickedCell = QualifyMouseCoordAsCell(clickedPoint);

            if (IsStartingPointButtonSet == true)
            {

                if (IsStartingPointSet == true)
                {
                    // remove current starting point
                    var pointToRemove = LogicalTreeHelper.FindLogicalNode(AStarGrid, "Start");
                    AStarGrid.Children.Remove((UIElement)pointToRemove);
                }

                StartNode = clickedCell;

                DrawRectangle(clickedCell, Brushes.Red, "Start");

                IsStartingPointSet = true;

            }
            if (IsEndPointButtonSet == true)
            {
                if (IsEndPointSet == true)
                {
                    //// usun aktualny
                    var pointToRemove = LogicalTreeHelper.FindLogicalNode(AStarGrid, "End");
                    AStarGrid.Children.Remove((UIElement)pointToRemove);
                }

                EndNode = clickedCell;

                DrawRectangle(clickedCell, Brushes.Blue, "End");

                IsEndPointSet = true;
            }
            else if (IsSetObstacleButtonSet == true)      // jesli wcsiniety przycisk ustawiania przeszkod
            {
                Node obstacle = clickedCell;

                ObstacleNodeList.Add(obstacle);

                Rectangle rectangle = new Rectangle();       // stworz instancje klasy Rectangle (prostokat), inicjalizacja
                rectangle.Fill = Brushes.Gray;               // wypelnij kolorem ( na szaro)

                Grid.SetRow(rectangle, clickedCell.Y);                 // ustaw pozycje na siatce (rzad)
                Grid.SetColumn(rectangle, clickedCell.X);              // ustaw pozycje na siatce (kolumna)

                AStarGrid.Children.Add(rectangle);

            }

        }


        /// <summary>
        /// Right mouse button handling
        /// </summary>
        private void RightMouseDoubleClick()
        {
            Point clickedPoint = Mouse.GetPosition(AStarGrid);
            var elem = Mouse.DirectlyOver;
            Node clickedNode = QualifyMouseCoordAsCell(clickedPoint);

            double col = clickedNode.X;      // pobierz kolumne wskazanego elementu
            double row = clickedNode.Y;         // pobierz wiersz wskazanego elementu

            if (IsStartingPointButtonSet == true)    // jesli wcisniety przycisk ustawiania punktu startowego
            {

                try
                {
                    var nodeToRemove = LogicalTreeHelper.FindLogicalNode(AStarGrid, "Start");     // znajdz wezel o nazwie Start - punkt startowy
                    int c = Grid.GetColumn((UIElement)nodeToRemove);                              // pobierz kolumne znalezionego elementu
                    int r = Grid.GetRow((UIElement)nodeToRemove);                                 // pobierz wiersz znalezionego elementu
                    if (c == col && r == row)                                               // jesli wspolrzedne wcisnietej myszka komorki zgadzaja sie z tymi pobranymi
                    {
                        AStarGrid.Children.Remove((UIElement)nodeToRemove);     // usun element z siatki
                        //StartNode = null;                   // usun punkt startowy
                        IsStartingPointSet = false;         // ustaw flage na false (flaga informujaca czy punkt startowy zostal juz ustawiony)
                    }
                    else    // jesli nie wskazano na punkt startowy
                    {
                        MessageBox.Show("You have to point at starting point");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to set the starting point at first");
                }
            }
            else if (IsEndPointButtonSet == true)     // jesli wcisniety przycisk ustawiania punktu koncowego
            {
                try
                {
                    var nodeToRemove = LogicalTreeHelper.FindLogicalNode(AStarGrid, "End");   // znajdz wezel koncowy
                    int c = Grid.GetColumn((UIElement)nodeToRemove);                          // pobierz odpowiadajaca mu kolumne
                    int r = Grid.GetRow((UIElement)nodeToRemove);                             // pobierz wiersz
                    if (c == col && r == row)                                           // jesli wspolrzedne wcisnietej myszka komorki zgadzaja sie z tymi pobranymi
                    {
                        AStarGrid.Children.Remove((UIElement)nodeToRemove);     // usun element z siatki
                        //EndNode = null;                     // usun punkt koncowy
                        IsEndPointSet = false;           // ustaw flage na false (flaga informujaca czy punkt koncowy zostal juz ustawiony)
                    }
                    else    // jesli nie wskazano na punkt koncowy
                    {
                        MessageBox.Show("You have to point at end point");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to set the end point at first");
                }

            }
            else if (IsSetObstacleButtonSet == true)      // jesli wcisnieto przycisk ustawiania przeszkod
            {

                Node nodeToRemove = ObstacleNodeList.Find(l => l.X == col && l.Y == row);   // jesli w tym wezle jest juz przeszkoda to go znajdz
                ObstacleNodeList.Remove(nodeToRemove);                                          // usun wezel z przeszkoda z listy przeszkod
                if (nodeToRemove != null)                                                    // jesli znaleziono wezel na liscie przeszkod 
                {
                    AStarGrid.Children.Remove((UIElement)elem);                                    // usun element z siatki (wizualnie)
                }

            }
        }

        #endregion



        #region Function definitions

        /// <summary>
        /// Evokes a pop up window to set algorithm parameters
        /// </summary>
        public void SetAlgorithmParameters()
        {
            ParametersWindow parametersWindow = new ParametersWindow();

            parametersWindow.Owner = System.Windows.Application.Current.MainWindow;
            parametersWindow.ShowDialog();


        }


        /// <summary>
        /// Creates a grid
        /// </summary>
        /// <param name="sizeOfGrid"></param>
        public void CreateGrid(int sizeOfGrid)
        {
            AStarGrid = new Grid();
            AStarGrid.Width = sizeOfGrid * WidthOfCellInView;
            AStarGrid.Height = sizeOfGrid * WidthOfCellInView;
            AStarGrid.ShowGridLines = true;


            for (int i = 0; i < sizeOfGrid; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                AStarGrid.RowDefinitions.Add(rowDef);
            }


            for (int i = 0; i < sizeOfGrid; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                AStarGrid.ColumnDefinitions.Add(colDef);
            }


        }


        /// <summary>
        /// Function qualifies specified point as a cell which size is known
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Position of cell</returns>
        public Node QualifyMouseCoordAsCell(Point point)
        {
            Node cellPos = new Node();

            cellPos.X = (int)Math.Floor(point.X / WidthOfCellInView);
            cellPos.Y = (int)Math.Floor(point.Y / WidthOfCellInView);

            return cellPos;
        }
        

        /// <summary>
        /// Draws a line with arrow
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public Shape DrawLinkArrow(Point p1, Point p2)
        {

            GeometryGroup lineGroup = new GeometryGroup();
            double theta = Math.Atan2((p2.Y - p1.Y), (p2.X - p1.X)) * 180 / Math.PI;

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            Point p = new Point(p1.X + ((p2.X - p1.X) / 1), p1.Y + ((p2.Y - p1.Y) / 1));
            pathFigure.StartPoint = p;

            Point lpoint = new Point(p.X + 1, p.Y + 2);
            Point rpoint = new Point(p.X - 1, p.Y + 2);
            LineSegment seg1 = new LineSegment();
            seg1.Point = lpoint;
            pathFigure.Segments.Add(seg1);

            LineSegment seg2 = new LineSegment();
            seg2.Point = rpoint;
            pathFigure.Segments.Add(seg2);
            LineSegment seg3 = new LineSegment();
            seg3.Point = p;
            pathFigure.Segments.Add(seg3);


            pathGeometry.Figures.Add(pathFigure);
            RotateTransform transform = new RotateTransform();
            transform.Angle = theta + 90;
            transform.CenterX = p.X;
            transform.CenterY = p.Y;
            pathGeometry.Transform = transform;
            lineGroup.Children.Add(pathGeometry);

            LineGeometry connectorGeometry = new LineGeometry();
            connectorGeometry.StartPoint = p1;
            connectorGeometry.EndPoint = p2;
            lineGroup.Children.Add(connectorGeometry);
            Path path = new Path();
            path.Data = lineGroup;
            path.StrokeThickness = 1;
            path.Stroke = path.Fill = Brushes.Green;


            return path;
        }


        /// <summary>
        /// Draws a path
        /// </summary>
        /// <param name="previousPoint"></param>
        /// <param name="point"></param>
        /// <param name="node"></param>
        private void DrawPath(ref Point previousPoint, ref Point point, Node node)
        {
            Shape path = new Path();
            

            point.X = node.X;
            point.Y = node.Y;

            Point scaledPoint = new Point
            {
                X = WidthOfCellInView * point.X + 0.5f * WidthOfCellInView,
                Y = WidthOfCellInView * point.Y + 0.5f * WidthOfCellInView
            };

            if (node.Parent != null)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = WidthOfCellInView / 2,
                    Height = WidthOfCellInView / 2,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Visibility = Visibility.Visible,
                    Fill = Brushes.Orange,
                    Name = "Path",
                    RenderTransform = new TranslateTransform(node.X * WidthOfCellInView  + WidthOfCellInView / 4, node.Y * WidthOfCellInView + WidthOfCellInView / 4)
                };

                path = DrawLinkArrow(previousPoint, scaledPoint);
                Grid.SetRowSpan(path, SizeOfGrid);
                Grid.SetColumnSpan(path, SizeOfGrid);
                path.Name = "Path";

                AStarGrid.Children.Add(ellipse);
                AStarGrid.Children.Add(path);



            }

            previousPoint = scaledPoint;
        }


        /// <summary>
        /// Draws a rectangle
        /// </summary>
        /// <param name="clickedCell"></param>
        /// <param name="brush"></param>
        /// <param name="destinationName"></param>
        private void DrawRectangle(Node clickedCell, Brush brush, string destinationName)
        {
            Rectangle rectangle = new Rectangle();      
            rectangle.Fill = brush;              
            rectangle.Name = destinationName;                   

            Grid.SetRow(rectangle, clickedCell.Y);                
            Grid.SetColumn(rectangle, clickedCell.X);             
            AStarGrid.Children.Add(rectangle);          
        }


        #endregion


        #region Constructor
        public MainViewModel()
        {
            this.StateOfDiode = "Red";

        }

        #endregion


    }


    #region A* Algorithm
    public static class AStarAlgorithm
    {

        private static readonly double _costOfNonDiagonalMove = 1;
        private static readonly double _costOfDiagonalMove = _costOfNonDiagonalMove * Math.Sqrt(2);


        /// <summary>
        /// A* algorithm main method
        /// </summary>
        /// <param name="startingNode">Starting point</param>    
        /// <param name="endNode">End point</param>
        /// <param name="obstacleList">List of obstacles</param>
        /// <param name="aStarGrid">Grid at which points will be placed</param>
        /// <returns>Path</returns>
        public static List<Node> GeneratePath(Node startingNode, Node endNode, List<Node> obstacleList, int sizeOfGrid, ref string costOfTrack, ref string algorithmDuration)
        {


            List< Node> finalPath = new List<Node>();

            try
            {
                Stopwatch stopWatch = new Stopwatch();      
                stopWatch.Start();                              


                Node current = null;

                var openList = new List<Node>();        
                var closedList = new List<Node>();      
                double g = 0;

                openList.Add(startingNode);                // add starting node to open list

                while (openList.Count > 0)                  // until there is any node on list of open nodes
                {

                    var lowest = openList.Min(l => l.F);                // find node with lowest value of F 
                    current = openList.First(l => l.F == lowest);       // mark this node as current

                    closedList.Add(current);        // add current node to list of closed nodes

                    openList.Remove(current);       // remove current node from list of open nodes

                    if (closedList.FirstOrDefault(l => l.X == endNode.X && l.Y == endNode.Y) != null)       // if end node is located on list of closed nodes then break
                        break;


                    var adjacentSquares = GetWalkableAdjacentSquaresDiagonal(current.X, current.Y, openList, obstacleList, sizeOfGrid);     // get neighbours nodes


                    foreach (var adjacentSquare in adjacentSquares)     // check all neighbours
                    {
                        if (adjacentSquare.IsOnDiagonalFromCurrent == true)      // if is on diagonal
                        {
                            g = current.G + _costOfDiagonalMove;                
                        }
                        else
                        {
                            g = current.G + _costOfNonDiagonalMove;              
                        }



                        if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) != null)     // if the neighbor is already on the closed node list, skip the current iteration
                            continue;

                        if (openList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)       // if the neighbor is not yet on the open list, add it to it
                        {
                            adjacentSquare.G = g;                                                                                           
                            adjacentSquare.H = ComputeHScoreDiagonal(adjacentSquare.X, adjacentSquare.Y, endNode.X, endNode.Y);                 
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;                                                            
                            adjacentSquare.Parent = current;                                                                                    

                            openList.Insert(0, adjacentSquare);                                                                                 // add neighbour to the open list
                        }
                        else    // if neighbour is already on the open list
                        {
                            if (g + adjacentSquare.H < adjacentSquare.F)        // check if the cost of reaching this node via the current node is less than the previous one assigned
                            {
                                adjacentSquare.G = g;                                       
                                adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;     
                                adjacentSquare.Parent = current;                            
                            }
                        }
                    }
                }


                

                
                if (current.X == endNode.X && current.Y == endNode.Y)        // check if found node is the end node
                {
                    MessageBox.Show("Path found!");
                    finalPath = GenerateFinalPath(current);

                    if (current != null)
                    {

                        current.G = Math.Round(current.G, 4);     
                        costOfTrack = current.G.ToString();      
                    }
                }
                else
                {
                    MessageBox.Show("Cant find path to destination");
                }

                stopWatch.Stop();                                                           
                algorithmDuration = stopWatch.ElapsedMilliseconds.ToString() + " ms";       

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return finalPath;
        }


        /// <summary>
        /// Generate the final path when A* has found the goal node
        /// </summary>
        /// <param name="finalNode"></param>
        /// <returns>Returns final path</returns>
        private static List<Node> GenerateFinalPath(Node finalNode)
        {
            List<Node> finalPath = new List<Node>();

            //Generate the path
            Node currentNode = finalNode;

            //Loop from the end of the path until we reach the start node
            while (currentNode != null)
            {
                finalPath.Add(currentNode);

                //Get the next node
                currentNode = currentNode.Parent;
            }

            //If we have found a path 
            if (finalPath.Count > 1)
            {
                //Reverse the list so the finalNode is the last one in the list
                finalPath.Reverse();

            }


            return finalPath;
        }


        /// <summary>
        /// Get list of walkable neighbour nodes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="openList"></param>
        /// <param name="obstacleList"></param>
        /// <param name="sizeOfGrid"></param>
        /// <returns>List of walkable neighbours</returns>
        public static List<Node> GetWalkableAdjacentSquaresDiagonal(int x, int y, List<Node> openList, List<Node> obstacleList, int sizeOfGrid)
        {
            List<Node> list = new List<Node>();                             

            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null)           // check if the neighbor on the left is on the obstacle list
            {                                                                       // if not:
                Node node = openList.Find(l => l.X == x - 1 && l.Y == y);       // look for the node indicated in the list of open nodes
                if (x > 0)
                {

                    if (node == null) list.Add(new Node() { X = x - 1, Y = y });    // if it does not exist, add a new location to the list
                    else                                                                // if exist  
                    {
                        node.IsOnDiagonalFromCurrent = false;                           // update the status of the flag indicating whether the neighbor is on a diagonal from the current node
                        list.Add(node);                                                 // add to list
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null)               // check if the neighbor on the right is on the obstacle list
            {                                                                           
                Node node = openList.Find(l => l.X == x + 1 && l.Y == y);           
                if (x < sizeOfGrid - 1)
                {
                    if (node == null) list.Add(new Node() { X = x + 1, Y = y });    
                    else                                                                
                    {
                        node.IsOnDiagonalFromCurrent = false;                           
                        list.Add(node);                                                 
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)               // check if the neighbor below is on the obstacle list
            {                                                                           
                Node node = openList.Find(l => l.X == x && l.Y == y + 1);          
                if (y < sizeOfGrid - 1)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y + 1 });   
                    else                                                                   
                    {
                        node.IsOnDiagonalFromCurrent = false;                           
                        list.Add(node);                                               
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)               // check if the neighbor above is on the obstacle list
            {                                                                           
                Node node = openList.Find(l => l.X == x && l.Y == y - 1);           
                if (y > 0)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y - 1 });    
                    else                                                                
                    {
                        node.IsOnDiagonalFromCurrent = false;                          
                        list.Add(node);                                                
                    }
                }

            }


            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y - 1) == null)               // check if the neighbor on the top left (diagonally) is on the obstacle list
            {                                                                               
                if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)   
                {
                    Node node = openList.Find(l => l.X == x - 1 && l.Y == y - 1);           
                    if (x > 0 && y > 0)
                    {

                        if (node == null) list.Add(new Node() { X = x - 1, Y = y - 1, IsOnDiagonalFromCurrent = true });    
                        else                                                                
                        {
                            node.IsOnDiagonalFromCurrent = true;                            
                            list.Add(node);                                                 
                        }
                    }
                }
            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y - 1) == null)               // check if the neighbor on the top right (diagonally) is on the obstacle list
            {                                                                               
                if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)   
                {
                    Node node = openList.Find(l => l.X == x + 1 && l.Y == y - 1);           
                    if (x < sizeOfGrid - 1 && y > 0)
                    {
                        if (node == null) list.Add(new Node() { X = x + 1, Y = y - 1, IsOnDiagonalFromCurrent = true });   
                        else                                                               
                        {
                            node.IsOnDiagonalFromCurrent = true;                          
                            list.Add(node);                                                 
                        }
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y + 1) == null)               // check if the neighbor on the bottom left (diagonally) is on the obstacle list
            {                                                                              
                if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)   
                {
                    Node node = openList.Find(l => l.X == x - 1 && l.Y == y + 1);       
                    if (x > 0 && y < sizeOfGrid - 1)
                    {
                        if (node == null) list.Add(new Node() { X = x - 1, Y = y + 1, IsOnDiagonalFromCurrent = true });  
                        else                                                            
                        {
                            node.IsOnDiagonalFromCurrent = true;                            
                            list.Add(node);                                             
                        }
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y + 1) == null)               // check if the neighbor on the bottom right (diagonally) is on the obstacle list
            {                                                                            
                if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)    
                {
                    Node node = openList.Find(l => l.X == x + 1 && l.Y == y + 1);           
                    if (x < sizeOfGrid - 1 && y < sizeOfGrid - 1)
                    {
                        if (node == null) list.Add(new Node() { X = x + 1, Y = y + 1, IsOnDiagonalFromCurrent = true });    
                        else                                                                
                        {
                            node.IsOnDiagonalFromCurrent = true;                            
                            list.Add(node);                                                 
                        }
                    }
                }

            }

            return list;        // return list of neighbours
        }



        /// <summary>
        /// Calculates the value of the H function by the Manhattan method (direct distance between points)
        /// </summary>
        /// <param name="x">X coordinate of current cell</param>
        /// <param name="y">Y coordinate of current cell</param>
        /// <param name="targetX">X coordinate of end point</param>
        /// <param name="targetY">Y coordinate of end point</param>
        /// <returns>Direct distance between cells</returns>
        static double ComputeHScoreDiagonal(int x, int y, int targetX, int targetY)
        {
            int dx = Math.Abs(targetX - x);
            int dy = Math.Abs(targetY - y);
            return _costOfNonDiagonalMove * (dx + dy) + (_costOfDiagonalMove - 2 * _costOfNonDiagonalMove) * Math.Min(dx, dy);
        }

    }

    #endregion

}