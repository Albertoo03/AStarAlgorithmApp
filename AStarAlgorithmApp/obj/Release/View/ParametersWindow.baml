   M S B A M L   `   `   `  ���� L  HAStarAlgorithmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AStarAlgorithmApp.ViewModelAStarAlgorithmApp.ViewModel  P:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmAppAStarAlgorithmApp  ?$clr-namespace:AStarAlgorithmApp.ViewAStarAlgorithmApp.View  -    'AStarAlgorithmApp.View.ParametersWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  2vm)clr-namespace:AStarAlgorithmApp.ViewModel  Bb:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmApp  0local$clr-namespace:AStarAlgorithmApp.View    � Title$  ParametersWindow��$	��300��$	��300�� � WindowStartupLocation$ CenterOwner=� � DataContext ��    Locator �� Source# [   �� Path$
 Main�.��(�  (� Stretch$ Uniform=�$��Stretch=�.��� .+��� $��2q�.+��� $��Set size of grid��$
��Left=�$	��Top=�$��	75,10,0,0q��� $��1q�
�������$��0,0,0,0q�._���  �� Orientation$ 
Horizontal=�
�������.+��� $��
Map width:��$��10q��� -    ��Name$ MapWidthSlider�� �� Orientation$ 
Horizontal=�	 � Minimum$	 1Q�
 � Maximum$
 50Q� � SmallChange$ 1Q� � LargeChange$ 5Q� �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q� �� TickPlacement$ BottomRight=�$	��100��$��
28,10,0,10q� � Value �� *
MapWidth+ �� Mode$ TwoWay=���  �� TextAlignment$ Center=� �� Padding$ 10q�$��50������ $ MapWidth��� $��1q�
�������$��0,0,0,0q�._��� $ 
Horizontal=�
�������.+��� $��Cell width:��$��10q��� -   $ CellWidthSlider��$ 
Horizontal=�$	 1Q�$	 0.1Q�$ 5Q� . $ 1Q�$ BottomRight=�$	��100��$��
28,10,0,10q� �� *	CellWidth+$ TwoWay=�
 �� *MaxCellWidth+�� $ Center=�$ 10q�$��50������ $ 	CellWidth��� -    ��Name$ AcceptChanges��$��Accept changes��$��Center=�$��Bottom=�$��	0,100,0,0q����� *AcceptChangesCommand+