   M S B A M L   `   `   `  ����D  @AviViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AviViewer	AviViewer  5   	       AviViewer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AviViewer     5   	     � Icon$E  ?https://www.iconpacks.net/icons/1/free-video-icon-818-thumb.png��5   	    � Title$ 
Avi Viewer��5	   	   $	��560��6   $	��900��6)   .��5
      � ���#FFE3E3 � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $	��300 �6   6+   �� 5      $��50 �6   6*   �� 5      $	��120 �6   6+   .+�5   
   �� $��0��6    �� Padding$ 5q�6   ._�5      �  � Orientation$ 
Horizontal=�6   .+�5      o� $��50��6   $��20��6#   ���#789DBC���#fff$��10q�6V   .@�5      m� $��файл��6   ���#789DBC.@�5      m� -   5        ���#789DBC m� Icon$ +��5   8   $��Открыть��6]   ���#000.@�6�   Подтвердить5      m� 5      -   5        ���#789DBC$ -��5   8   $��Удалить��6b   ���#000.@�6�   Подтвердить5      5      5      �� 5      -   5        $��	730 0 0 0q�5   .   $��20��6A   ���#C9E9D2$��70��6b   .��6m   справка6v   5      5      �� 5    
   $��1��6   ���#FFE3E3._�5!      r� -   5        $��mediaElement��5!       r� LoadedBehavior$ Manual=�60    r� UnloadedBehavior$ Manual=�6H   5"      �� 5#   
    �� CornerRadius$ 20��6   $��2��6#   ���#789DBC$	��0 5q�6E   ._�5$      � $��Center=�6   $��Center=�65   .+�5%      �� -   5        $��playPauseButton��5%   P   
������ $
��Bold"�62   $	��100��6D   $��Center=�6�   $
��Left=�6�   $��	50 0 20 0q�6�   .��5&      �� 	 �� Orientation$	 
Horizontal=�6"   .+�5'      �� -   5        
 ��Name$
 playIcon��5'       $��Images/PlayIcon.png��62   $��20��6P   $��20��6[   �� 5(      -   5        $
 	pauseIcon��5(       $��Images/PauseIcon.png��63   $��20��6R   $��20��6]   5)      5*      �� 5+      -   5        $��PositionSlider��5+       � Minimum$ 0Q�60    � Maximum$ 1Q�6<    � Value$ 0Q�6H   $
��Left=�6R   $��Center=�6m   $	��600��6�   5,   D   �� 5.      $��Right=�6   ._�5/      � .+�50      �� -	   5        $��CurrentPositionText��50   $   $
��0:00��6?   $��0,0,10,0q�6K   �� 51      $��/��6$   $��0,0,5,0q�6-   �� 52      -
   5        $��TotalDurationText��52   $   $
��0:00��6=   53      54      55      56      �� 57   
   $��3��6   $ 20q�6   ._�58      �� ���#C9E9D2$	 Vertical=�6.   $
��Left=�6E   $��	10 0 10 0q�6`   .+�59      � .+�5:      �� $��10q�6    ���#789DBC$��Громкость��6A   $��Center=�6R   $
��Left=�6m   �� 5;      -   5         ��Name$ 
VolumeText��5;   =   $��30��6    $��70 0 0 0q�6+    �� TextAlignment$ Center=�6Q   $��Center=�6h   $��16(�6�   $��DemiBold"�6�   ���#789DBC6�   5<      �� 5=      -   5         ��Name$ VolumeSlider��5=   .   ���#FFE3E3$ 0Q�6D   $ 1Q�6P   $	 0.6Q�6\   $��Bottom=�5>      $
��Left=�6,   $	��200��6G   $��10q�5?      6   5@      5A      5B      5C      