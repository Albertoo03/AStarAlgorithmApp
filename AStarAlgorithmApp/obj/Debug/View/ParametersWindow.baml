   M S B A M L   `   `   `  ����L  HAStarAlgorithmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:AStarAlgorithmApp.ViewModelAStarAlgorithmApp.ViewModel  5   	   P:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmAppAStarAlgorithmApp  5   	   ?$clr-namespace:AStarAlgorithmApp.ViewAStarAlgorithmApp.View  5	   	   -    'AStarAlgorithmApp.View.ParametersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   2vm)clr-namespace:AStarAlgorithmApp.ViewModel  5   	   Bb:clr-namespace:AStarAlgorithmApp;assembly=AStarAlgorithmApp  5   	   0local$clr-namespace:AStarAlgorithmApp.View  5	   	     � Title$  ParametersWindow��5   	   $	��300��6"   $	��300��6/    � WindowStartupLocation$ CenterOwner=�5   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      (�  (� Stretch$ Uniform=�6   $��Stretch=�6    .��5   
   � .+�5      �� $��2q�6   .+�5      �� $��Set size of grid��6   $
��Left=�63   $	��Top=�6N   $��	75,10,0,0q�6f   �� 5      $��1q�6   
�������$��0,0,0,0q�6E   ._�5      ��  �� Orientation$ 
Horizontal=�6!   
�������.+�5      �� $��Grid width:��6    $��10q�67   �� 5      -   5         ��Name$ GridWidthSlider��5   !    �� Orientation$ 
Horizontal=�6:   	 � Minimum$	 20Q�6}   
 � Maximum$
 60Q�6�    � SmallChange$ 1Q�6�    � LargeChange$ 5Q�6�    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6�    �� TickPlacement$ BottomRight=�6�   $	��100��6   $��
60,10,0,10q�6   � Value 6S   �� *
SizeOfGrid+ �� Mode$ TwoWay=�6  �� 5       �� TextAlignment$ Center=�6E    �� Padding$ 10q�6\   $��50��6i   ��6$   �� $ 
SizeOfGrid�6i   5      5      �� 5      $��1q�6   
�������$��0,0,0,0q�6E   ._�5      �� $ 
Horizontal=�6!   
�������.+�5      �� $��Size of grid view:��6    $��10q�6>   �� 5      -   5        $ GridViewSlider��5   !   $ 
Horizontal=�69   $	 20Q�6�   $	 0.1Q�6�   $ 5Q�6�    . $ 1Q�6�   $ BottomRight=�6   $	��100��6  $��
28,10,0,10q�6(   6R   �� *NumOfCellsToDisplay+$ TwoWay=�
 6�   �� *
SizeOfGrid+6(  �� 5      $ Center=�6N   $ 10q�6e   $��50��6r   ��6$   �� $ NumOfCellsToDisplay�6r   5      5       �� 5!      -   5         ��Name$ AcceptChanges��5!      $��Accept changes��60   $��Center=�6I   $��Bottom=�6f   $��	0,100,0,0q�6�   ��6�   �� *AcceptChangesCommand+6�   5"      5$      5%      5'      