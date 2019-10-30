using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;

namespace AStarAlgorithmApp.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public bool IsProgramRunning { get; set;} = false;              // zmienna informujaca czy program zostal uruchomiony
        public bool IsStartPointPressed { get; set; } = false;          // zmienna informujaca czy wcisnieto przycisk ustawiania punktu startowego
        public bool IsEndPointPressed { get; set; } = false;            // zmienna informujaca czy wcisnieto przycisk ustawiania punktu koncowego
        public bool IsSetObstaclePressed { get; set; } = false;         // zmienna informujaca czy wcisnieto przycisk ustawiania przeszkod

        private bool IsStartPointAlreadySet = false;                    // zmienna informujaca czy punkt startowy zostal juz ustawiony
        private bool IsEndPointAlreadySet = false;                      // zmienna informujaca czy punkt koncowy zostal juz ustawiony
        private bool IsStopButtonAlreadyClicked = false;               // zmienna informujaca czy przycisk stopu zostal wcisniety

        //public Node StartNode { get; set; }                     // punkt startowy
        //public Node EndNode { get; set; }                       // punkt koncowy

        //public List<Node> ObstacleList = new List<Node>();      // lista przeszkod

        public static float zoom = 1.0f;

        public MainWindow()
        {
            InitializeComponent();
            //AStarAlgorithmClass aStarInstance = new AStarAlgorithmClass();                          // stworz instancje do klasy algorytmu A*, inicjalizacja
            //this.DataContext = aStarInstance;
            
            //aStarInstance.SetAlgorithmParameters();
            
            //aStarInstance.AStarAlgorithm(aStarInstance.StartNode, aStarInstance.EndNode, aStarInstance.ObstacleList);      // wystartuj algorytm A*
            
        }


        // ponizsza funkcja tez pobiera element wskazany przez myszke, zastapiona przez inna lepsza wersje
        //UIElement GetGridElement(Grid g, int row, int column)
        //{
        //    for (int i = 0; i < g.Children.Count; i++)
        //    {
        //        UIElement e = g.Children[i];
        //        if (Grid.GetRow(e) == row && Grid.GetColumn(e) == column)
        //            return e;
        //    }
        //    return null;
        //}


        #region Obsluga myszki
        /// <summary>
        /// Reaction  on pressing the left mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // if (e.ClickCount == 2) 
            // {
            //var point = Mouse.GetPosition(GridContent);       // pobierz wspolrzedne punktu wskazywanego przez myszke

            //int row = 0;
            //int col = 0;
            //double accumulatedHeight = 0.0;
            //double accumulatedWidth = 0.0;


            //foreach (var rowDefinition in aStarGrid.RowDefinitions)     // sprawdzenie na ktory rzad wskazuje myszka
            //{
            //    accumulatedHeight += rowDefinition.ActualHeight;
            //    if (accumulatedHeight >= point.Y)
            //        break;
            //    row++;
            //}


            //foreach (var columnDefinition in aStarGrid.ColumnDefinitions)       // sprawdzenie na ktora kolumne wskazuje myszka
            //{
            //    accumulatedWidth += columnDefinition.ActualWidth;
            //    if (accumulatedWidth >= point.X)
            //        break;
            //    col++;
            //}

            //if (IsStartPointPressed == true)        // jesli wcisniety przycisk ustawiania punktu startowego
            //{
            //    if(IsStartPointAlreadySet == true)  // jesli punkt startowy zostal juz ustawiony
            //    {
            //        var objekt = LogicalTreeHelper.FindLogicalNode(aStarGrid, "Start");     // znajdz obiekt o nazwie Start ( wezel startowy)
            //        aStarGrid.Children.Remove((UIElement)objekt);                           // usun ten element z siatki
            //    }


            //    Rectangle rectangle = new Rectangle();      // stworz instancje do klasy Rectangle (prostokat), inicjalizacja
            //    rectangle.Fill = Brushes.Red;               // wypelnij kolorem (czerwonym)   
            //    rectangle.Name = "Start";                   // nadaj mu nazwe Start


            //    Grid.SetRow(rectangle, row);                // ustaw pozycje na siatce (rzad)
            //    Grid.SetColumn(rectangle, col);             // ustaw pozycje na siatce (kolumna)
            //    aStarGrid.Children.Add(rectangle);          // dodaj nowy element do kolekcji

            //    //StartNode = new Node { X = col, Y = row };     // ustaw wspolrzedne punktu koncowego
            //    IsStartPointAlreadySet = true;                         // ustaw flage na true (flaga informujaca czy punkt startowy jest ustawiony)

            //}
            //else if (IsEndPointPressed == true)     // jesli wcisniety przycisk ustawiania punktu koncowego
            //{
            //    if(IsEndPointAlreadySet == true)    // jesli punkt koncowy zostal juz ustawiony
            //    {
            //        var objekt = LogicalTreeHelper.FindLogicalNode(aStarGrid, "End");       // znajdz obiekt o nazwie End ( wezel koncowy)
            //        aStarGrid.Children.Remove((UIElement)objekt);                           // usun ten element z siatki
            //    }


            //    Rectangle rectangle = new Rectangle();     // stworz instancje klasy Rectangle (prostokat), inicjalizacja
            //    rectangle.Fill = Brushes.Blue;             // wypelnij kolorem (niebieskim) 
            //    rectangle.Name = "End";                    // nadaj mu nazwe End

            //    Grid.SetRow(rectangle, row);               // ustaw pozycje na siatce (rzad)
            //    Grid.SetColumn(rectangle, col);            // ustaw pozycje na siatce (kolumna)
            //    aStarGrid.Children.Add(rectangle);         // dodaj nowy element do kolekcji


            //    //EndNode = new Node { X = col, Y = row };    // ustaw wspolrzedne punktu koncowego
            //    IsEndPointAlreadySet = true;                        // ustaw flage na true (flaga informujaca czy punkt koncowy jest ustawiony)

            //}
            //else if (IsSetObstaclePressed == true)      // jesli wcsiniety przycisk ustawiania przeszkod
            //{
            //    Rectangle pole = new Rectangle();       // stworz instancje klasy Rectangle (prostokat), inicjalizacja
            //    pole.Fill = Brushes.Gray;               // wypelnij kolorem ( na szaro)

            //    Grid.SetRow(pole, row);                 // ustaw pozycje na siatce (rzad)
            //    Grid.SetColumn(pole, col);              // ustaw pozycje na siatce (kolumna)
            //    aStarGrid.Children.Add(pole);           // dodaj nowy element do kolekcji

            //    Node obstacle = new Node { X = col, Y = row };      // dodaj nowa przeszkode o wspolrzednych wskazanych przez myszke
            //    //ObstacleList.Add(obstacle);                                 // dodaj nowa przeszkode do listy przeszkod
            //}
            //MessageBox.Show($"Clicked on row: {row}, col: {col} ");
            //CostOfPoint.Text = col.ToString() + " " + row.ToString();
            //    }
        }


        
        /// <summary>
        /// Reaction on pressing the right mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

/*            var element = (UIElement)e.OriginalSource;      // ustaw referencje do wskazanego elementu

            int col = Grid.GetColumn(element);      // pobierz kolumne wskazanego elementu
            int row = Grid.GetRow(element);         // pobierz wiersz wskazanego elementu
            MessageBox.Show($"Clicked on col: {col}, row: {row}");
*/
            //if (IsStartPointPressed == true)    // jesli wcisniety przycisk ustawiania punktu startowego
            //{

            //    try
            //    {
            //        var objekt = LogicalTreeHelper.FindLogicalNode(aStarGrid, "Start");     // znajdz wezel o nazwie Start - punkt startowy
            //        int c = Grid.GetColumn((UIElement)objekt);                              // pobierz kolumne znalezionego elementu
            //        int r = Grid.GetRow((UIElement)objekt);                                 // pobierz wiersz znalezionego elementu
            //        if (c == col && r == row)                                               // jesli wspolrzedne wcisnietej myszka komorki zgadzaja sie z tymi pobranymi
            //        {
            //            aStarGrid.Children.Remove(element);     // usun element z siatki
            //            //StartNode = null;                   // usun punkt startowy
            //            IsStartPointAlreadySet = false;         // ustaw flage na false (flaga informujaca czy punkt startowy zostal juz ustawiony)
            //        }
            //        else    // jesli nie wskazano na punkt startowy
            //        {
            //            MessageBox.Show("You have to point at starting point");
            //        }
            //    }
            //    catch(Exception)
            //    {
            //        MessageBox.Show("You have to set the starting point at first");
            //    }        
            //}
            //else if (IsEndPointPressed == true)     // jesli wcisniety przycisk ustawiania punktu koncowego
            //{
            //    try
            //    {
            //        var objekt = LogicalTreeHelper.FindLogicalNode(aStarGrid, "End");   // znajdz wezel koncowy
            //        int c = Grid.GetColumn((UIElement)objekt);                          // pobierz odpowiadajaca mu kolumne
            //        int r = Grid.GetRow((UIElement)objekt);                             // pobierz wiersz
            //        if (c == col && r == row)                                           // jesli wspolrzedne wcisnietej myszka komorki zgadzaja sie z tymi pobranymi
            //        {
            //            aStarGrid.Children.Remove(element);     // usun element z siatki
            //            //EndNode = null;                     // usun punkt koncowy
            //            IsEndPointAlreadySet = false;           // ustaw flage na false (flaga informujaca czy punkt koncowy zostal juz ustawiony)
            //        }
            //        else    // jesli nie wskazano na punkt koncowy
            //        {
            //            MessageBox.Show("You have to point at end point");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("You have to set the end point at first");
            //    }
                
            //}
            //else if (IsSetObstaclePressed == true)      // jesli wcisnieto przycisk ustawiania przeszkod
            //{
                
            //    //Node nodeToRemove = ObstacleList.Find(l => l.X == col && l.Y == row);   // jesli w tym wezle jest juz przeszkoda to go znajdz
            //    //ObstacleList.Remove(nodeToRemove);                                          // usun wezel z przeszkoda z listy przeszkod
            //    //if(nodeToRemove != null)                                                    // jesli znaleziono wezel na liscie przeszkod 
            //    {
            //        aStarGrid.Children.Remove(element);                                         // usun element z siatki (wizualnie)
            //    }

            //}

        }


        private void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ////aStarGrid.LayoutTransform = new ScaleTransform(e.Delta, e.Delta);
            
            ////            MessageBox.Show(e.Delta.ToString());
            
            if (e.Delta > 0)
                zoom -= 0.1f;
            ////    MessageBox.Show("Oddal");
            else if (e.Delta < 0)
                zoom += 0.1f;
            ////    MessageBox.Show("Przybliz");
            if (zoom > 3.0f) zoom = 3.0f;
            if (zoom < 0.5f) zoom = 0.5f;

            //aStarGrid.LayoutTransform = new ScaleTransform(zoom, zoom);
        }

        #endregion



        #region Obsluga przyciskow

        /// <summary>
        /// Start the algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //if(IsStopButtonAlreadyClicked == true)
            //{
            //    var element = LogicalTreeHelper.FindLogicalNode(aStarGrid, "Path");
            //    while(element != null)
            //    {
            //        element = LogicalTreeHelper.FindLogicalNode(aStarGrid, "Path");         // znajdz wezly sciezki
            //        aStarGrid.Children.Remove((UIElement)element);                              // usun sciezke z siatki
            //    }
                
                
            //    IsStopButtonAlreadyClicked = false;
            //}


            ////if (StartNode == null || EndNode == null)       // jesli pozycja startowa lub pozycja koncowa nie zostaly jeszcze ustawione
            //{
            //    MessageBox.Show("Set algorithm parameters first");
            //}
            ////else
            //{
            //    this.IsProgramRunning = true;                                       // ustaw flage informujaca ze program jest uruchomiony
            //    IsStartPointPressed = false;                                        // czy przycisk od ustawiania punktu startowego wcisniety
            //    IsEndPointPressed = false;                                          // czy przycisk od ustawiania punktu koncowego wcisniety
            //    IsSetObstaclePressed = false;                                       // czy przycisk od ustawiania przeszkod wcisniety
            //    ProgramStateDiode.Fill = new SolidColorBrush(Colors.Green);         // zmien kolor diody sygnalizujacej stan programu (na zielony)


                
            //    //AStarAlgorithmClass aStarInstance = new AStarAlgorithmClass();                          // stworz instancje do klasy algorytmu A*, inicjalizacja
                
            //    //aStarInstance.AStarAlgorithm(StartNode, EndNode, ObstacleList, aStarGrid);      // wystartuj algorytm A*
            //    //this.DataContext = aStarInstance;
                
            //    //Results.Text = "Path cost: " + aStarInstance.CostOfTrack + $"\nElapsed: {elapsedTime} ms";        // wyswietl koszt drogi i czas
            //}

        }



        /// <summary>
        /// Stop the algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            this.IsProgramRunning = false;                                  // ustaw flage na false (flaga informujaca o tym czy program jest uruchomiony)
            IsStopButtonAlreadyClicked = true;                              // czy przycisk stopu zostal wcisniety
            //ProgramStateDiode.Fill = new SolidColorBrush(Colors.Red);       // zmien kolor diody sygnalizujacej stan programu na czerwony
            
        }



        /// <summary>
        /// Set the starting point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartingPoint_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.IsProgramRunning == false)         // jesli program nie jest uruchomiony ustaw flage ustawiania punktu startowego
            {
                IsStartPointPressed = true;             
                IsEndPointPressed = false;
                IsSetObstaclePressed = false;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop program and try again.");
            }
        }



        /// <summary>
        /// Set the end point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndPoint_Click(object sender, RoutedEventArgs e)
        {
            

            if (this.IsProgramRunning == false)         // jesli program nie jest uruchomiony ustaw flage ustawiania punktu koncowego
            {
                IsStartPointPressed = false;
                IsEndPointPressed = true;
                IsSetObstaclePressed = false;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop program and try again.");
            }
        }



        /// <summary>
        /// Set obstacles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetObstacle_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.IsProgramRunning == false)         // jesli program nie jest uruchomiony ustaw flage ustawiania przeszkod
            {
                IsStartPointPressed = false;
                IsEndPointPressed = false;
                IsSetObstaclePressed = true;
            }
            else
            {
                MessageBox.Show("Program is already started! Stop program and try again.");
            }
        }



        /// <summary>
        /// Clear grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //if (this.IsProgramRunning == false)         // jesli program nie jest uruchomiony
            //{
            //    aStarGrid.Children.Clear();             // czysc siatke
            //    //ObstacleList.Clear();                   // wyczysc liste przeszkod
            //    //EndNode = null;                     // usun pozycje koncowa
            //    //StartNode = null;                   // usun pozycje startowa
            //    IsStartPointAlreadySet = false;         // ustaw flage na false (flaga informujaca czy punkt startowy zostal juz ustawiony)
            //    IsEndPointAlreadySet = false;           // ustaw flage na false (flaga informujaca czy punkt koncowy zostal juz ustawiony)
            //}
            //else
            //{
            //    MessageBox.Show("Program is already started! Stop program and try again.");
            //}
        }

        #endregion

    }


    /*
    /// <summary>
    /// Node representing cells of grid
    /// </summary>
    public class Node
    {
        public int X { get; set; }                                      // wspolrzedna X
        public int Y { get; set; }                                      // wspolrzedna Y
        public double F { get; set; }                                   // wartosc funkcji F (suma wartosci funkcji G oraz H)
        public double G { get; set; }                                   // wartosc funkcji G (koszt calkowitej drogi od punktu poczatkowego do aktualnego)
        public double H { get; set; }                                   // wartosc heurystycznej funkcji H (przewidywany koszt dotarcia do punktu koncowego od punktu aktualnego)
        public Node Parent;                                         // zmienna klasy Node bedaca rodzicem danego wezla

        public bool IsOnDiagonalFromCurrent { get; set; } = false;      // zmienna okreslajaca czy kolejny pobrany sasiadujacy wezel znajduje sie po przekatnej od aktualnego wezla
    }


    #region Algorytm A*

    /// <summary>
    /// A* algorithm class
    /// </summary>
    public class AStarAlgorithmClass: INotifyPropertyChanged
    {
        public string CostOfTrack { get; private set; }
        public string AlgorithmDuration { get; private set; }

        private static readonly double CostOfNonDiagonalMove = 1;
        private static readonly double CostOfDiagonalMove = CostOfNonDiagonalMove * Math.Sqrt(2);

        public Grid AStarGrid { get; set; }

        public int SizeOfCell { get; set; } = 25;
        public static int NumberOfColumns { get; set; } = 50;
        public static int NumberOfRows { get; set; } = 50;

        public int SizeOfViewGrid { get; set; } = 20;

        public int SizeOfGrid { get; set; } = 20;

        public int XCoordOfViewGridMiddle { get; set; }
        public int YCoordOfViewGridMiddle { get; set; }

        public static float Zoom { get; set; } = 1.0f;

        public float ScrollXValue { get; set; }
        public float ScrollYValue { get; set; }
        public Node StartNode { get; set; }                     // punkt startowy
        public Node EndNode { get; set; }                       // punkt koncowy

        public List<Node> ObstacleList = new List<Node>();      // lista przeszkod

        public event PropertyChangedEventHandler PropertyChanged;

        public Point StartingPoint { get; set; }
        public Point EndPoint { get; set; }

        public void SetAlgorithmParameters()
        {

            AStarGrid = new Grid();
            AStarGrid.Width = NumberOfColumns * SizeOfCell;
            AStarGrid.Height = NumberOfRows * SizeOfCell;
            AStarGrid.ShowGridLines = true;

            //numberOfColumns = (int) AStarGrid.Width / SizeOfCell;
            //numberOfRows = (int)AStarGrid.Height / SizeOfCell;

            
            for(int i=0; i < NumberOfRows; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                AStarGrid.RowDefinitions.Add(rowDef);
            }

            
            for(int i=0; i < NumberOfColumns; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                AStarGrid.ColumnDefinitions.Add(colDef);
            }

            for(int row = 0; row < NumberOfRows; row++)
            {
                for(int col = 0; col < NumberOfColumns; col++)
                {
                    Rectangle pole = new Rectangle();       // stworz instancje klasy Rectangle (prostokat), inicjalizacja
                    pole.Fill = Brushes.White;               // wypelnij kolorem ( na szaro)

                    Grid.SetRow(pole, row);                 // ustaw pozycje na siatce (rzad)
                    Grid.SetColumn(pole, col);              // ustaw pozycje na siatce (kolumna)
                    AStarGrid.Children.Add(pole);           // dodaj nowy element do kolekcji
                }
            }

            StartingPoint = new Point { X = 10, Y = 10, };
            EndPoint = new Point { X = 600 , Y = 450 };

            StartNode = QualifyCoordAsCell(StartingPoint);
            EndNode = QualifyCoordAsCell(EndPoint);
        }

        /// <summary>
        /// Function converts coordinates of clicked point to values understandable to A* algorithm which operates on grid created in this class
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point ChangeViewPointToGridPoint(Point point)
        {
            point.X = (SizeOfGrid / SizeOfViewGrid) * (XCoordOfViewGridMiddle + (point.X - XCoordOfViewGridMiddle) * Zoom) + ScrollXValue * SizeOfCell * (NumberOfColumns / 2);
            point.Y = (SizeOfGrid / SizeOfViewGrid) * (YCoordOfViewGridMiddle + (point.Y - YCoordOfViewGridMiddle) * Zoom) + ScrollYValue * SizeOfCell * (NumberOfRows / 2);

            return point;
        }

        /// <summary>
        /// Function qualifies specified point as a cell which size is known
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Node QualifyCoordAsCell(Point point)
        {
            Node cellFromCoord = null;

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // if is set gui use
            point = ChangeViewPointToGridPoint(point);

            foreach (var rowDefinition in AStarGrid.RowDefinitions)     // sprawdzenie na ktory rzad wskazuje myszka
            {
                accumulatedHeight += SizeOfCell;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }


            foreach (var columnDefinition in AStarGrid.ColumnDefinitions)       // sprawdzenie na ktora kolumne wskazuje myszka
            {
                accumulatedWidth += SizeOfCell;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            cellFromCoord = new Node { X = col, Y = row };

            return cellFromCoord; 
            //AStarGrid.Height / SizeOfCell;
        }

        /// <summary>
        /// A* algorithm main method
        /// </summary>
        /// <param name="startLocation">Starting point</param>    
        /// <param name="endLocation">End point</param>
        /// <param name="obstacleList">List of obstacles</param>
        /// <param name="aStarGrid">Grid at which points will be placed</param>
        public void AStarAlgorithm(Node startLocation, Node endLocation, List<Node> obstacleList)
        {
            
            try
            {
                Stopwatch stopWatch = new Stopwatch();          // stworz instacje do stopera
                stopWatch.Start();                              // startuj stoper


                Node current = null;                    

                var openList = new List<Node>();        // tworzy liste wezlow otwartych
                var closedList = new List<Node>();      // tworzy liste wezlow zamknietych
                double g = 0;

                openList.Add(startLocation);                // dodaj punkt startowy do listy wezlow otwartych

                while (openList.Count > 0)                  // dopoki jest cos na liscie wezlow otwartych
                {

                    var lowest = openList.Min(l => l.F);                // znajdz wezel z najmniejsza wartoscia funkcji F
                    current = openList.First(l => l.F == lowest);       // oznacz wezel z najmniejszym F jako aktualny

                    closedList.Add(current);        // dodaj aktualny wezel do listy wezlow zamknietych

                    openList.Remove(current);       // usun aktualny wezel z listy wezlow otwartych

                    if (closedList.FirstOrDefault(l => l.X == endLocation.X && l.Y == endLocation.Y) != null)       // jesli punkt koncowy znajduje sie na liscie wezlow zamknietych to zakoncz algorytm
                        break;

                    //var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, openList, obstacleList);     // pobierz liste sasiadow ktorych mozna odwiedzic
                    var adjacentSquares = GetWalkableAdjacentSquaresDiagonal(current.X, current.Y, openList, obstacleList);     // pobierz liste sasiadow ktorych mozna odwiedzic

                    
                    foreach (var adjacentSquare in adjacentSquares)     // dla kazdego z sasiadow
                    {
                        if(adjacentSquare.IsOnDiagonalFromCurrent == true)      // sprawdz czy jest na diagonali
                        {
                            g = current.G + CostOfDiagonalMove;                 // powieksz koszt calkowitej drogi o koszt drogi od aktualnego wezla do kolejnego po diagonali
                        }
                        else
                        {
                            g = current.G + CostOfNonDiagonalMove;              // powieksz koszt calkowitej drogi o koszt drogi od aktualnego wezla do kolejnego po prostej
                        }
                        


                        if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) != null)     // jesli sasiad znajduje sie juz na liscie wezlow zamknietych to pomin biezaca iteracje
                            continue;

                        if (openList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)       // jesli sasiad nie znajduje sie jeszcze na liscie otwartej to go do niej dodaj
                        {
                            adjacentSquare.G = g;                                                                                               // przypisz mu nowa wartosc G 
                            //adjacentSquare.H = ComputeHScore(1, adjacentSquare.X, adjacentSquare.Y, endLocation.X, endLocation.Y);                 // oblicz wartosc H
                            adjacentSquare.H = ComputeHScoreDiagonal(adjacentSquare.X, adjacentSquare.Y, endLocation.X, endLocation.Y);                 // oblicz wartosc H
                            //adjacentSquare.H = 0;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;                                                             // wyznacz wartosc F
                            adjacentSquare.Parent = current;                                                                                    // przypisz sasiadowi rodzica (czyli wezel aktualny)

                            openList.Insert(0, adjacentSquare);                                                                                 // dodaj sasiada do listy wezlow otwartych
                        }
                        else    // jesli sasiad znajduje sie juz na liscie wezlow otwartych
                        {
                            if (g + adjacentSquare.H < adjacentSquare.F)        // sprawdz czy koszt dotarcia do tego wezla obecna trasa (poprzez aktualny wezel) jest mniejszy niz poprzedni przypisany
                            {
                                adjacentSquare.G = g;                                       // przypisz nowa wartosc funkcji G
                                adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;     // przypisz nowa wartosc funkcji F
                                adjacentSquare.Parent = current;                            // przypisz sasiadowi rodzica (aktualny wezel)
                            }
                        }
                    }
                }



                if(current.X == endLocation.X && current.Y == endLocation.Y)        // sprawdz czy znaleziony punkt to punkt koncowy
                {
                    Node target = current;              // algorytm zakonczony stad current to punkt koncowy

                    while (current != null)                 // rysowanie sciezki ( wypelnia sciezke pomaranczowymi elipsami), zaczyna rysowac od konca (od punktu koncowego do startowego)
                    {
                        Ellipse ellipse = new Ellipse();
                        ellipse.Fill = Brushes.Orange;
                        
                        ellipse.Name = "Path";

                        Grid.SetRow(ellipse, current.Y);
                        Grid.SetColumn(ellipse, current.X);
                        AStarGrid.Children.Add(ellipse);
                        current = current.Parent;               // pobierz rodzica aktualnego wezla

                    }

                    if (target != null)
                    {
                        
                        target.G = Math.Round(target.G, 4);     // zaokraglij do 4 miejsc po przecinku
                        CostOfTrack = target.G.ToString();      // konwertuj na string
                    }
                }
                else 
                {
                    MessageBox.Show("Nie znaleziono drogi do punktu koncowego");
                }

                stopWatch.Stop();                                                           // zatrymaj stoper
                AlgorithmDuration = stopWatch.ElapsedMilliseconds.ToString() + " ms";       // oblicz czas jaki uplynal od startu do zatrzymania stopera


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// List of walkable adjacent cells
        /// </summary>
        /// <param name="x">X coordinate of current cell</param>
        /// <param name="y">Y coordinate of current cell</param>
        /// <param name="openList">List of open nodes</param>
        /// <param name="obstacleList">List of obstacles</param>
        /// <returns>List of walkable adjacent cells</returns>
        static List<Node> GetWalkableAdjacentSquares(int x, int y, List<Node> openList, List<Node> obstacleList)
        {
            List<Node> list = new List<Node>();                             // stworz pusta liste 
            
            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null)           // sprawdz czy sasiad po lewej jest na liscie przeszkod
            {                                                                       // jesli nie to:
                Node node = openList.Find(l => l.X == x - 1 && l.Y == y);       // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (x > 0)
                {
                    if (node == null) list.Add(new Node() { X = x - 1, Y = y });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else list.Add(node);                                                // jesli istnieje to dodaj do listy
                }

            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null)               // sprawdz czy sasiad po prawej jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x + 1 && l.Y == y);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (x < 19)
                {
                    if (node == null) list.Add(new Node() { X = x + 1, Y = y });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else list.Add(node);                                                // jesli istnieje to dodaj do listy
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)               // sprawdz czy sasiad na dole jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x && l.Y == y - 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (y > 0)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y - 1 });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else list.Add(node);                                                // jesli istnieje to dodaj do listy
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)               // sprawdz czy sasiad na gorze jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x && l.Y == y + 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (y < 19)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y + 1 });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else list.Add(node);                                                // jesli istnieje to dodaj do listy
                }

            }

            return list;                                                                // zwroc liste sasiadow
        }

        static List<Node> GetWalkableAdjacentSquaresDiagonal(int x, int y, List<Node> openList, List<Node> obstacleList)
        {
            List<Node> list = new List<Node>();                             // stworz pusta liste 

            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null)           // sprawdz czy sasiad po lewej jest na liscie przeszkod
            {                                                                       // jesli nie to:
                Node node = openList.Find(l => l.X == x - 1 && l.Y == y);       // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (x > 0)
                {

                    if (node == null) list.Add(new Node() { X = x - 1, Y = y });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else                                                                // jesli istnieje    
                    {
                        node.IsOnDiagonalFromCurrent = false;                           // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                        list.Add(node);                                                 // dodaj do listy
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null)               // sprawdz czy sasiad po prawej jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x + 1 && l.Y == y);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (x < NumberOfColumns - 1)
                {
                    if (node == null) list.Add(new Node() { X = x + 1, Y = y });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else                                                                // jesli istnieje
                    {
                        node.IsOnDiagonalFromCurrent = false;                           // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                        list.Add(node);                                                 // dodaj do listy
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)               // sprawdz czy sasiad na dole jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x && l.Y == y + 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (y < NumberOfRows - 1)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y + 1 });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else                                                                // jesli istnieje        
                    {
                        node.IsOnDiagonalFromCurrent = false;                           // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                        list.Add(node);                                                 // dodaj do listy
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)               // sprawdz czy sasiad na gorze jest na liscie przeszkod
            {                                                                           // jesli nie to:
                Node node = openList.Find(l => l.X == x && l.Y == y - 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                if (y > 0)
                {
                    if (node == null) list.Add(new Node() { X = x, Y = y - 1 });    // jesli nie istnieje to dodaj nowa lokacje do listy
                    else                                                                // jesli istnieje
                    {
                        node.IsOnDiagonalFromCurrent = false;                           // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                        list.Add(node);                                                 // dodaj do listy
                    }
                }

            }


            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y - 1) == null)               // sprawdz czy sasiad na gorze po lewej (po przekatnej) jest na liscie przeszkod
            {                                                                               // jesli nie to:
                if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)   // sprawdz czy sasiad po lewej i sasiad na gorze jest na liscie przeszkod
                {
                    Node node = openList.Find(l => l.X == x - 1 && l.Y == y - 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                    if (x > 0 && y > 0)
                    {

                        if (node == null) list.Add(new Node() { X = x - 1, Y = y - 1, IsOnDiagonalFromCurrent = true });    // jesli nie istnieje to dodaj nowa lokacje do listy
                        else                                                                // jesli istnieje
                        {
                            node.IsOnDiagonalFromCurrent = true;                            // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                            list.Add(node);                                                 // dodaj do listy
                        }
                    }
                }
            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y - 1) == null)               // sprawdz czy sasiad na gorze po prawej (po przekatnej) jest na liscie przeszkod
            {                                                                               // jesli nie to:
                if (obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y - 1) == null)   // sprawdz czy sasiad po prawej i sasiad na gorze sa na liscie przeszkod
                {
                    Node node = openList.Find(l => l.X == x + 1 && l.Y == y - 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                    if (x < NumberOfColumns - 1 && y > 0)
                    {
                        if (node == null) list.Add(new Node() { X = x + 1, Y = y - 1, IsOnDiagonalFromCurrent = true });    // jesli nie istnieje to dodaj nowa lokacje do listy
                        else                                                                // jesli istnieje
                        {
                            node.IsOnDiagonalFromCurrent = true;                            // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                            list.Add(node);                                                 // dodaj do listy
                        }
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x - 1 && l.Y == y + 1) == null)               // sprawdz czy sasiad na dole po lewej (po przekatnej) jest na liscie przeszkod
            {                                                                               // jesli nie to:
                if (obstacleList.Find(l => l.X == x - 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)   // sprawdz czy sasiad po lewej i sasiad na dole sa na liscie przeszkod
                {
                    Node node = openList.Find(l => l.X == x - 1 && l.Y == y + 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                    if (x > 0 && y < NumberOfRows - 1)
                    {
                        if (node == null) list.Add(new Node() { X = x - 1, Y = y + 1, IsOnDiagonalFromCurrent = true });    // jesli nie istnieje to dodaj nowa lokacje do listy
                        else                                                                // jesli istnieje
                        {
                            node.IsOnDiagonalFromCurrent = true;                            // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                            list.Add(node);                                                 // dodaj do listy
                        }
                    }
                }

            }
            if (obstacleList.Find(l => l.X == x + 1 && l.Y == y + 1) == null)               // sprawdz czy sasiad na dole po prawej (po przekatnej) jest na liscie przeszkod
            {                                                                               // jesli nie to:
                if(obstacleList.Find(l => l.X == x + 1 && l.Y == y) == null && obstacleList.Find(l => l.X == x && l.Y == y + 1) == null)    // sprawdz czy sasiad po prawej i sasiad na dole sa na liscie przeszkod
                {
                    Node node = openList.Find(l => l.X == x + 1 && l.Y == y + 1);           // poszukaj wskazanego wezla na liscie otwartych wezlow
                    if (x < NumberOfColumns - 1 && y < NumberOfRows - 1)
                    {
                        if (node == null) list.Add(new Node() { X = x + 1, Y = y + 1, IsOnDiagonalFromCurrent = true });    // jesli nie istnieje to dodaj nowa lokacje do listy
                        else                                                                // jesli istnieje
                        {
                            node.IsOnDiagonalFromCurrent = true;                            // zaktualizuj stan flagi informujacej czy sasiad znajduje sie na diagonali od obecnego wezla
                            list.Add(node);                                                 // dodaj do listy
                        }
                    }
                }            

            }

            return list;                                                                // zwroc liste sasiadow
        }



        /// <summary>
        /// Calculates the value of the H function by the Manhattan method (direct distance between points)
        /// </summary>
        /// <param name="x">X coordinate of current cell</param>
        /// <param name="y">Y coordinate of current cell</param>
        /// <param name="targetX">X coordinate of end point</param>
        /// <param name="targetY">Y coordinate of end point</param>
        /// <returns></returns>
        static int ComputeHScore(int cost, int x, int y, int targetX, int targetY)
        {
            int dx = Math.Abs(targetX - x);
            int dy = Math.Abs(targetY - y);
            return cost * (dx + dy);
        }

        static double ComputeHScoreDiagonal(int x, int y, int targetX, int targetY)
        {
            int dx = Math.Abs(targetX - x);
            int dy = Math.Abs(targetY - y);
            return CostOfNonDiagonalMove * (dx + dy) + (CostOfDiagonalMove - 2* CostOfNonDiagonalMove) * Math.Min(dx, dy);
        }
    }

    #endregion

    */
}
