   M S B A M L   `   `   `  ����D  @09_DzSmtp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:_09_DzSmtp
_09_DzSmtp  5   	       _09_DzSmtp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:_09_DzSmtp     5   	     � Title$  
MainWindow��5	   	   $	��720��6   $
��1280��6)    � 	Resources 5       �� 
TargetType �� Property �� Value   FocusVisual �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName  TextBox.Static.Border  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle1-  'System.Windows.Input.KeyboardNavigation ��Name �� Triggers ]� 
Conditions �� Property �� Value��%�  '��       '�� n     '�� �     &	  L    &	 �    &	 "    &	 E    &	 f    &	 �    &	 �    &	 �    &	 �    &		     &	
 8    7   7  7  7  7  7  7  7  7  7 	 &	 /    &	 R    &	 u    &	 �    7  7  7  �� 5   
   " ��6   .�5      ��  � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�69   �� 5       � ��$ 16(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5       5!      �� 5"   
   $ 	#FFDDDDDD��6;   �� 5#   
   $ 	#FF707070��67   �� 5$   
   $ #3f2bbd��6>   �� 5%   
   $ 	#FF3C7FB1��6:   �� 5&   
   $ 	#FFC4E5F6��6<   �� 5'   
   $ 	#FF2C628B��68   �� 5(   
   $ 	#FFF4F4F4��6=   �� 5)   
   $ 	#FFADB2B5��69   �� 5*   
   $ 	#FF838383��6=   �� 5+   
   " ��6%   .�5,      ��  �@�FocusVisualStyle8   61   �� 5-       � ��8  6+   �� 5.       � ��8  6,   �� 5/       � ��# � ��6+   �� 50       � ��$ 1q�60   �� 51       � ��$ Center=�6;   �� 52       � ��$ Center=�69   �� 53       � ��$ 1q�6(   �� 54       � �� 55      �� 56      " ��6&   .R�57      �� $	 border��6!   $
 8��61   #��z��6B   $
 true��6l   ._�58      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  59       5:      P� 5;       �@��IsDefaulted$
 true��6=   . �5<   "   �� $ border��6@   # � ��6T    � ��5=      P� 5>       �@J�IsMouseOver$
 true��6=   . �5?   "   �� $ border��6?   8   � ��6S   �� 5@   "   $ border��6@   8   � ��6T   5A      P� 5B       � ��$
 true��6;   . �5C   "   �� $ border��6?   8   � ��6S   �� 5D   "   $ border��6@   8   � ��6T   5E      P� 5F       � {�$ false��6;   . �5G   "   �� $ border��6?   8   � ��6S   �� 5H   "   $ border��6@   8   � ��6T   �� 5I   "   $ contentPresenter��6K   8 	  � ��6i   5J      5L      5N      5O      �� 5P   
   $ 	#FFABAdB3��68   �� 5Q   
   $ 	#FF7EB4EA��6;   �� 5R   
   $ 	#FF569DE5��67   �� 5S   
   " ��6&   .�5T      ��  � ��# � ��6+   �� 5U       � ��8   6,   �� 5V       � ��# � ��6+   �� 5W       � ��$ 1q�60   �� 5X       �@ TabNavigation$
 None=�6A   �� 5Y       � ��$
 Left=�6;   �� 5Z       �@�FocusVisualStyle 61   Z� �� 5[       �@J�	AllowDrop$
 true��6*   �� 5\       �@��PanningMode$ VerticalFirst=�69   �� 5]       �@��IsFlicksEnabled$ False��67   �� 5^       � �� 5_      �� 5`      " ��6&   .R�5a      �� $	 border��6!   $
 8��61   #��z��6B   #��z��6l   #��z��6�   $
 True��6�   ._�5b      �� $ PART_ContentHost��6+   $|�false��6E   $��Hidden=�6W   $��Hidden=�6~   5c       5d      P� 5e       � {�$ false��6;   . �5f   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5g      P� 5h       �@J�IsMouseOver$
 true��6=   . �5i   "   �� $ border��6@   8   � ��6T   5j      P� 5l       �@J�IsKeyboardFocused$
 true��6C   . �5m   "   �� $ border��6@   8   � ��6T   5n      5p      5r       5s      ]� 5t       5u      �� 5v      + �@��#IsInactiveSelectionHighlightEnabled$
 true��6S   �� 5w       �@��IsSelectionActive$ false��6A   ./�5y      ��  �@��SelectionBrush# � /�67   5z      5|      5}      .��5~       � -   5        $��	MainFrame��5~        � NavigationUIVisibility$ Hidden=�6   6?   5�      