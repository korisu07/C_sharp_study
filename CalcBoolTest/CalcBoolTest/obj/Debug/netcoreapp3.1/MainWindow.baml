   M S B A M L   `   `   `  ����G  CCalcBoolTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CalcBoolTestCalcBoolTest  5   	       CalcBoolTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CalcBoolTest     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��0,10,0,0q�6   $	��500��6   $	��320��6*   $��Center=�66   $	��Top=�6S    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��320 �6   �� 5      $	��160 �6    � RowDefinitions 5   
   �� 5      $
��320* �6   �� 5      $
��150* �6   �� 5      $	��30* �6   .+�5   
   �� -   5        $��0��5      $
��Left=�6   $��50��68   $��50��6D   $��
30,85,0,15q�6O   $��25(�6c   $��Yu Gothic UI)�6q   $��1��6�   $��1��6�   �� 5   
   -   5        $��(��5      $
��Left=�6   $��50��68   $��50��6D   $��	95,0,0,15q�6O   $��Bottom=�6b   $��25(�6}   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5   
   $��.��6   $
��Left=�6   $��50��68   $��50��6E   $��
160,0,0,15q�6P   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5   
   -   5        $��1��5      $
��Left=�6   $��50��68   $��50��6E   $��	30,0,0,75q�6P   $��Bottom=�6c   $��25(�6~   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5   
   -   5        $��2��5      $
��Left=�6   $��50��68   $��50��6E   $��	95,0,0,75q�6P   $��Bottom=�6c   $��25(�6~   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5   
   -   5        $��3��5      $
��Left=�6   $��50��68   $��50��6E   $��
160,0,0,75q�6P   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5   
   -   5        $��4��5      $
��Left=�6   $��50��68   $��50��6E   $��
30,0,0,135q�6P   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $��1��6�   $��2��6�   �� 5    
   -   5        $��5��5       $
��Left=�6   $��50��68   $��50��6E   $��
95,0,0,135q�6P   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $��1��6�   $��2��6�   �� 5!   
   -   5        $��6��5!      $
��Left=�6   $��50��68   $��50��6E   $��160,0,0,135q�6P   $��Bottom=�6e   $��25(�6�   $��Yu Gothic UI)�6�    J� RenderTransformOrigin$ -0.09,0.071&�6�   $��1��6�   $��2��6�   �� 5#   
   -	   5        $��7��5#      $
��Left=�6   $��50��68   $��50��6E   $��	30,0,0,45q�6P   $��Bottom=�6c   $��25(�6~   $��Yu Gothic UI)�6�   $��1��6�   �� 5$   
   -
   5        $��8��5$      $
��Left=�6   $��50��68   $��50��6E   $��	95,0,0,45q�6P   $��Bottom=�6c   $��25(�6~   $��Yu Gothic UI)�6�   $��1��6�   �� 5%   
   -   5        $��9��5%      $
��Left=�6   $��50��68   $��50��6E   $��
160,0,0,45q�6P   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $ -0.06,0.491&�6�   $��1��6�   �� 5&   
   $	��+/-��6   $
��Left=�6   $��50��6:   $��50��6G   $��160,0,0,118q�6R   $��Bottom=�6g   $��25(�6�   $��Yu Gothic UI)�6�   $��1��6�   �� 5'   
   -   5        $��÷��5'      $��Right=�6   $��50��69   $��50��6F   $��
0,0,30,118q�6Q   $��Bottom=�6e   $��35(�6�   $��Yu Gothic UI)�6�   $��1��6�   �� 5(   
   -   5        $��×��5(      $��Right=�6   $��50��69   $��50��6F   $��	0,0,30,45q�6Q   $��Bottom=�6d   $��25(�6   $��Yu Gothic UI)�6�   $��1��6�   �� 5)   
   -   5        $��-��5)      $��Right=�6   $��50��69   $��50��6F   $��
0,0,30,135q�6Q   $��Bottom=�6e   $��35(�6�   $��Yu Gothic UI)�6�   $��1��6�   $��2��6�   �� 5*   
   -   5        $��+��5*      $��Right=�6   $��50��69   $��50��6F   $��	0,0,30,75q�6Q   $��Bottom=�6d   $��35(�6   $��Yu Gothic UI)�6�   $��1��6�   $��1��6�   �� 5+   
   $��1q�6   
���   �$��Center=�69   $	��125��6V   $	��260��6c   $	��Top=�6o   $��1��6�   (� 5-   
   $
��Left=�6   $��85��6-   $	��260��69   $��30,0,0,0q�6E   $	��Top=�6W   $��1��6o   .��5.      �� -   5        $��
TopViewbox��5.      $�� ��6*   $
��Wrap=�62   $��10(�6F    �� 
LineHeight$
 42.5��6T   5/      (� 51   
   $
��Left=�6   $��40��6-   $	��260��69   $��	30,85,0,0q�6E   $	��Top=�6X   $��1��6p   .��52      �� -   5        $��BottomViewbox��52      $�� ��6-   $
��Wrap=�65   $��10(�6J   $ 20��6X   53      56      57      