   M S B A M L   `   `   `  ���� L  HAStarAlgorithmApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AStarAlgorithmApp.ViewAStarAlgorithmApp.View  0    *AStarAlgorithmApp.View.AngleSettingsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:AStarAlgorithmApp.View       � Title$  Heading��$	��115��$	��200�� � WindowStartupLocation$ CenterOwner=� � DataContext ��    Locator �� Source# [   �� Path$
 Main�.��� .+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��30��$��10 5 0 0q�.+��� -    ��Name$ Heading��$��
Set angle:��$��30��$��85��$	��Top=�$
��Left=��� -    ��Name$ 	AngleText��$��Right=� �� TextWrapping$
 Wrap=�$	��Top=�$��30��$��75��$��0,5,0,0q����� *
CarHeading+	 �� Mode$	 OneWayToSource=��� -   
 ��Name$
 AcceptAngle��$��Accept changes��$��Center=�$��Bottom=�$��0 10 0 0q����� *AcceptAngleCommand+