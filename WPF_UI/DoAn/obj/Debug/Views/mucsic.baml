   M S B A M L   `   `   `  ����  DoAn    DoAn.Views.mucsic   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          >�Name$  Window��5      $	��711��5      $	��300��6   
������ $
��Bold"�67   $��14(�6I    � 	Resources 5	         CircleButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType (� Stretch A�Name � Color	 � Offset
 J� RenderTransformOrigin J� SnapsToDevicePixels �� Triggers P� Property P� Value��%�  &	        �� 5
   
   " ��6*   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      (� $
 Fill=�6"   .��5      � $��50��6#   $��50��6/   .+�5   "   A� $ ellipse��6*   $
��Auto��6;   $
��Auto��6I   ��5   &   �� 5   *   .��5   .   � $ #EFEFF2��6;   $	 1Q�6K   5   +   5   #   A� 5   "   $ ellipse1��6*   $
��Auto��6<   $
��Auto��6J   ���#fff$��8q�6c   $
 0.5,0.5&�6n   z�5   &   V� 5   *   .~�5   .   �� �� 5   .   �� 5   .   T� 5   .   5   +   5    #   �� 5!   "   $��Stretch=�63   ��. # z 6l   $��Stretch=�6�   #��z��6�   $
��Auto��6�   $
��Auto��6�   $��0q�6  5"      5#       5$      P� 5%       �@J�	IsFocused . 6;   P� 5&       �@��IsDefaulted . 6=   P� 5'       �@J�IsMouseOver . 6=   P� 5(       � �� . 6;   P� 5)       � {� .  6;   5+      5-      5.      5/      .��50      � -   5         �Name$ 
LayoutRoot��50       � ColumnDefinitions 51   
   �� 52      .+�54   
   r� -   5         r�Name$ MEmusicPlayer��54       r� LoadedBehavior$ Manual=�6.    r� UnloadedBehavior$ Close=�6F    r� Volume 55   w   ��  �� Path$ Value� �� ElementName$ SliderVolume���� 57   
   -   5         ��Name$ listaDeReproduccion��57   �   $��65,33,220,172q�6   $��Britannic Bold)�6)   $��14(�6E   ���#000 J� 	AllowDrop . 
������  J� Effect 59      3  -System.Windows.Media.Effects.DropShadowEffect  5:      5<      �� 5@   
   -   5         ��Name$ btnStop��5A   ,   $y�Hidden=�5@      $��Center=�6%   $��40��6B   $��40��6O   $��306,0,331,35q�6Z   #���   6p   $��Bottom=�5A      .��5C      �� $��20q�6   $
 0.783,0.528&�6$   $��30��6H   $��30��6S   ���	#FF49CA116_   5D      �� 5F   
   -   5        $ btnPause��5G   X   $��Center=�5F      $��40��6.   $��40��6;   $��245,0,426,67q�6F   #���   5G      $��Bottom=�6=   .��5I      "  FontAwesome.WPF.ImageAwesome     Icon$ Pause=�6      SpinDuration$ 30Q�6+   $��20��6=   $��20��6H      
Foreground �#0006j   5J      �� 5M   
   -   5        $ btnPlay��5N   J   $��40��5M      $��40��6   $��317,0,354,67q�6(   #���   6>   $��Bottom=�5N      $��Center=�6-   .��5P        $ CaretSquareOutlineRight=�6   $ 30Q�6>   $��20��6P   $��20��6[    �#0006}   5Q      �� 5R   
   -   5        $��SliderTimeLine��5S      $��23��5R      $��65,0,220,130q�6   $��Bottom=�5S   '    �� IsMoveToPointEnabled . ��5U   F   Z� 6^   �� 5V   
   -	   5        $��btnNext��5V   [   $��40��6   $��40��6   $��Center=�6(   $��398,0,273,69q�6E   #���   6j   $��Bottom=�6�   .��5X        $ FastForward=�6   $ 30Q�62   $��20��6D   $��20��6O    �#0006q   5Y      �� 5Z   
   -
   5        $��btnPrecedent��5Z   [   $��40��6   $��40��6   $��Center=�6(   $��160,0,511,68q�6E   #���   6o   $��Bottom=�6�   .��5\        $ FastBackward=�6   $ 30Q�63   $��20��6E   $��20��6P    �#0006r   5]      �� 5^   
   -   5        $��SliderVolume��5^   ?   $
��Left=�6   $��	65,0,0,67q�6,   $��27��6S    �� Orientation$ Vertical=�6^   $��62��6u   $��Bottom=�6�     � Maximum$  1Q�6�   ! � SmallChange$! 1Q�6�   " �� TickFrequency$	" 0.1Q�6�   # � Value$	# 0.5Q�6�   5_      5`      