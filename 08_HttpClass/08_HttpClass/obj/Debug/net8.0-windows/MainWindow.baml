   M S B A M L   `   `   `  ����G  C08_HttpClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:_08_HttpClass_08_HttpClass  5   	       _08_HttpClass.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:_08_HttpClass     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� $
��True��6   .+�5
   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   �� 5      $
��Auto �6#   62    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      �� $��Center=�6   .��6/   Url:65   �� 5      -   5        $��
srcTextBox��5      $��1��6(   6:   �� 5      -   5        $��2��5   +   $��5q�6;   $��5q�6F   .��6S   Browse6[   5      �� 5   
   -   5        $	��Top=�5   ,   $��35��6A   .��6M   	Downoload6X   �� 5   
   -   5        $��Bottom=�5   !   $��35��69   .��6E   Stop6K   �� 5   
   -   5        $
��list��5   7   $��Stretch=�6   ��6D   �� *	Processes+��5      �� 5      .R�5      �  5      �� 5       $
��Auto �6/   6>   �� 5!      $
��Auto �6/   6>   �� 5"      $��* �6/   6;   �� 5#      $
��Auto �6/   6>   .+�5(      �� $
��Bold"�6$   $
��20,0q�66   ��6D   �� *
FileName+6`   � 5+      $��2��6&   $	��500��66   $��10��6E   $��5q�6Q    � Value 6\   �� *
Percentage+6{   �� 5,      $��3��6$   $
��Bold"�64   $
��20,0q�6F   �� 6U   �6Y   �� *PercentageInt+ �� Mode$ OneWay=�6�   %6�   50      51      56      5:      5<      