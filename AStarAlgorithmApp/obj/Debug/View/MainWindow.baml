   M S B A M L   `   `   `  ����L  HAStarAlgorithmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmAppAStarAlgorithmApp  5   	   I)clr-namespace:AStarAlgorithmApp.ViewModelAStarAlgorithmApp.ViewModel  5   	   '    !AStarAlgorithmApp.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmApp     5   	   8vm)clr-namespace:AStarAlgorithmApp.ViewModel     5   	   [ WEsri.ArcGISRuntime, Version=100.6.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013  5   	     � Title$  A* algorithm app��5
   	   $	��600��6"   $	��908��6/    � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      (�  (� StretchDirection$
 Both=�6    (� Stretch$ Uniform=�6&   .��5   
   � .+�5      �� -   5         ��Name$ Start��5      $��Start��6$     ButtonStyle#��[ 64   $��	20,20,0,0q�6�   ��6Y   �� *StartAlgorithmCommand+6�   �� 5      -   5        $
 Stop��5      $
��Stop��6#   #��[ 6\   $��	20,55,0,0q�6�   ��62   �� *StopAlgorithmCommand+6�   �� 5      -   5        $ SetParameters��5      $��Set parameters��6,   #��[ 6o   $��	20,90,0,0q�6�   ��6E   �� *SetParametersCommand+6�   �� 5      -   5        $ Clear��5      $��
Clear grid��6$   #��[ 6^   $��
20,450,0,0q�6�   $��2��6�   ��69   �� *ClearGridCommand+6�   �� 5      -   5        $ StartingPoint��5      $��Set starting point��6,   #��[ 6u   $��
20,161,0,0q�6�   ��6I   �� *SetStartingPointCommand+6�   �� 5      -   5        $ EndPoint��5      $��Set end point��6'   #��[ 6f   $��
20,196,0,0q�6�   ��6?   �� *SetEndPointCommand+6�   �� 5      -   5        $ SetObstacle��5      $��Set obstacle��6*   #��[ 6j   $��
20,231,0,0q�6�   ��6A   �� *SetObstaclesCommand+6�   A� 5      -   5         A�Name$ ProgramStateDiode��5      $
��Left=�6O   $��22��6j   $��108,128,0,0q�6v   
���   �$	��Top=�6�   $��22��6�    J� RenderTransformOrigin$ 	0.5,0.545&�6�   ��61   �� *StateOfDiode+6�   � 5      -	   5        	 �Name$	 astarOutputGrid1��5   >   
�������$��53,15,0,10.045q�6&   $	��500��6X   $	��500��6d   $ 0.5,0.49&�6q   z�5      V� 5      .~�5      �� 
 �� ScaleX$
 1Q�6)    �� ScaleY$ -1Q�64   5       J� InputBindings 5!      d� 5"       d� Gesture$ LeftDoubleClicka�6#    �� Command 6=   �� *LeftMouseDoubleClickCommand+d� 5#      $ RightDoubleClicka�6#    6>   �� *RightMouseDoubleClickCommand+.+�5%      �� $��1q�6   
���`���._�5&      �� -
   5         ��Name$ GridContent��5&   '   $��0 0 0 0q�6Z   ��6<   �� *	AStarGrid+6Z   5'      5(      �� 5*      -   5         ��Name$ State��5*      $��State:��6#   $
��Left=�64   $��
20,126,0,0q�6O   $	��Top=�6c   $ 0.487,0.596&�6{   �� 5+      $��2q�6   
�������$��20,309,739,123.045q�6A   ._�5,      �� -   5         ��Name$ panel��5,      $
��Left=�6,   $	��Top=�6H   $	��160��6`   $��90��6l   $��	0,0,-2,-6q�6x   .+�5-      �� -   5        $ ResultsLabel��5-      
�������$��Results:��6I   $��30��6\   $	��Top=�6h   �� 5.       �� Orientation$ 
Horizontal=�6!   $��30��6:   .+�5/      �� -   5        $ CostOfTrackLabel��5/       
�������$��Cost of path:��6Q   $��30��6i   $��85��6u   $	��Top=�6�   $
��Left=�6�   �� 50      -   5         ��Name$ CostOfTrackText��50   $   $��Right=�6=   $
��Wrap=�6v   $	��Top=�6�   $��30��6�   $��75��6�    �� Padding$ 0,5,0,0q�6�   ��6Y   �� *CostOfTrack+6�   51      �� 52      $ 
Horizontal=�6!   .+�53      �� -   5        $ ElapsedTimeLabel��53       
�������$��Time elapsed: ��6Q   $��30��6j   $��85��6v   $	��Top=�6�   $
��Left=�6�   �� 54      -   5        $ ElapsedTimeText��54   $   $��Right=�6=   $
��Wrap=�6|   $	��Top=�6�   $��30��6�   $��75��6�   $ 0,5,0,0q�6�   ��6Y   �� *AlgorithmDuration+6�   55      56      57      59      5;      5<      