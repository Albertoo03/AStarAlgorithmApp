   M S B A M L   `   `   `  ���� L  HAStarAlgorithmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmAppAStarAlgorithmApp  I)clr-namespace:AStarAlgorithmApp.ViewModelAStarAlgorithmApp.ViewModel  '    !AStarAlgorithmApp.View.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Llocal:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmApp     8vm)clr-namespace:AStarAlgorithmApp.ViewModel     [ WEsri.ArcGISRuntime, Version=100.6.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013    � Title$  A* algorithm app��$	��600��$	��908�� � DataContext ��    Locator �� Source# [   �� Path$
 Main�.��(�  (� StretchDirection$
 Both=� (� Stretch$ Uniform=�.��� .+��� -    ��Name$ Start��$��Start��  ButtonStyle#��[ $��	20,20,0,0q����� *StartAlgorithmCommand+�� -   $
 Stop��$
��Stop��#��[ $��	20,55,0,0q����� *StopAlgorithmCommand+�� -   $ SetParameters��$��Set parameters��#��[ $��	20,90,0,0q����� *SetParametersCommand+�� -   $ Clear��$��	Clear map��#��[ $��
20,450,0,0q�$��2������ *ClearMapCommand+�� -   $ StartingPoint��$��Set starting point��#��[ $��
20,161,0,0q����� *SetStartingPointCommand+�� -   $ EndPoint��$��Set end point��#��[ $��
20,196,0,0q����� *SetEndPointCommand+�� -   $ SetObstacle��$��Set obstacle��#��[ $��
20,231,0,0q����� *SetObstaclesCommand+A� -    A�Name$ ProgramStateDiode��$
��Left=�$��22��$��108,128,0,0q�
���   �$	��Top=�$��22�� J� RenderTransformOrigin$ 	0.5,0.545&����� *StateOfDiode+�� -	   	 ��Name$	 ScrollXValue��
 �� Orientation$
 
Horizontal=� � SmallChange$
 0.25Q� � LargeChange$	 0.5Q�$��300,-10,200,450.045q� � Minimum �� $ MinValueSliders� �� Mode$ TwoWay=� � Maximum �� $ MaxValueSliders�$ TwoWay=� � Value �� $ ScrollXValue�$ TwoWay=��� -
   $	 ScrollYValue��$
 Vertical=�$
 0.25Q�$	 0.5Q�$��770, 70,000,70q� �� $ MinValueSliders�$ TwoWay=� �� $ MaxValueSliders�$ TwoWay=� �� $ ScrollYValue�$ TwoWay=��� -   $
	 Zoom��$
 
Horizontal=�$ 1Q�$	 2.5Q�$
 0.25Q�$	 0.5Q�$��300, 500,200,0q� �� $
 Zoom�$ TwoWay=�� -    �Name$ astarOutputGrid1��
�������$��53,15,0,10.045q�$	��500��$	��500��$ 0.5,0.49&�z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ -1Q� J� InputBindings d�  d� Gesture$ LeftDoubleClicka� �� Command �� *LeftMouseDoubleClickCommand+d� $ RightDoubleClicka� �� *RightMouseDoubleClickCommand+.+��� �� -    ��Name$ GridContent��$��0 0 0 0q����� *	AStarGrid+�� -    ��Name$ State��$��State:��$
��Left=�$��
20,126,0,0q�$	��Top=�$ 0.487,0.596&��� $
��Left=�$��56��$	��Top=�$	��141�� �� Orientation$ 
Horizontal=�$��
18,290,0,0q�.+��� $��Set cost value��$ -0.829,-0.462&�$��1q�#��� �����	#FFF7D7D7$��93��$��0,0,0,25q��� -    ��Name$ CostOfPoint�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=� �� TextAlignment$ Center=�$��0,5,0,0q�$��31��$��47���� $��2q�
�������$��20,339,739,93.045q�._��� -    ��Name$ panel��$
��Left=�$	��Top=�$	��160��$��90��$��	0,0,-2,-6q�.+��� -   $ ResultsLabel��
�������$��Results:��$��30��$	��Top=��� $ 
Horizontal=�$��30��.+��� -   $ CostOfTrackLabel��
�������$��Cost of path:��$��30��$��85��$	��Top=�$
��Left=��� -    ��Name$ CostOfTrackText��$��Right=�$
��Wrap=�$	��Top=�$��30��$��75�� �� Padding$ 0,5,0,0q����� $ CostOfTrack��� $ 
Horizontal=�.+��� -   $ ElapsedTimeLabel��
�������$��Time elapsed: ��$��30��$��85��$	��Top=�$
��Left=��� -   $ ElapsedTimeText��$��Right=�$
��Wrap=�$	��Top=�$��30��$��75��$ 0,5,0,0q����� *AlgorithmDuration+