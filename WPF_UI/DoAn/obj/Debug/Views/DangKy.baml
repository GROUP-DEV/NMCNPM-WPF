   M S B A M L   `   `   `  ����?  ;DoAn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DoAn.Views
DoAn.Views  5          DoAn.Views.DangKy   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:DoAn.Views     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      
������ $	��800��5      $
��1300��6   .��5      � ��5   
   �� 5        �� ImageSource$  ../Images/bg-plane.jpg��6    j� TileMode$
 Tile=�6?   .+�5   
   �� -   5        $��textBlockHeading��5   e   $��DemiBold"�6   $��37��6*   $
��Left=�66   $��
518,15,0,0q�6Q   $��ĐĂNG KÝ TÀI KHOẢN��6}   $	��Top=�6�   $	��268��6�   $��25(�6�   $��ExtraCondensed&�6�   �� 5   
   -   5        
������ $��136,15,1115,636q�5   +    � Cursor$
 Hand��6D    � ToolTip 5&      _� 5'      .��6   Quay về trang trước5)      .��5+      "  FontAwesome.WPF.ImageAwesome     Icon$ ArrowCircleLeft=�6      Spin .     SpinDuration$ 30Q�6B   $��40��6T   $��40��6_      
Foreground
 �   �6�   5,      � 5.   
   
������ $	��264��6)   $��Bottom=�66   $��338,0,469,288q�6Q    � RowDefinitions 5/      �� 50      $
��252* �6    .+�53      �� -   5        	 ��Name$	 errormessage��53   Q   $��20��6   $
��Left=�6$   $��67,0,0,0q�6?   $	��Top=�6h   $	��247��6�   
 J� OpacityMask

 �<�����	#FFE5572C6�   �� 54      -   5        $��textBlockId��54   `   $��15(�6   $��23��6&   $
��Left=�62   $��	67,20,0,0q�6M   $��Tên đăng Nhập:��6s   $	��Top=�6�   $	��110��6�   �� 55      -   5        $��textBlockLastName��55   a   $��15(�6   $��23��6'   $
��Left=�63   $��	67,50,0,0q�6N   $��Họ Và Tên:��6z   $	��Top=�6�   $	��110��6�   �� 56      -   5        $��textBlockEmailId��56   a   $��15(�6   $��23��6'   $
��Left=�63   $��	67,80,0,0q�6N   $��Email��6y   $	��Top=�6�   $	��110��6�   �� 57      -   5        $��textBlockPassword��57   b   $��15(�6   $��23��6'   $
��Left=�63   $��
67,107,0,0q�6N   $��Mật Khẩu:��6{   $	��Top=�6�   $	��110��6�   �� 58      -   5        $��textBlockConfirmPwd��58   a   $��15(�6   $��23��6&   $
��Left=�62   $��
67,136,0,0q�6M   $ ��Nhập Lại Mật Khẩu:��6|   $	��Top=�6�   $	��126��6�   �� 59      -	   5        $��textBlockAddress��59   a   $��15(�6   $��23��6&   $
��Left=�62   $��
67,166,0,0q�6M   $��Địa Chỉ :��6y   $	��Top=�6�   $	��110��6�   �� 5;      -
   5        $��textBoxUser��5;   k   $��23��60   $
��Left=�6<   $��
197,20,0,0q�6W   $	��Top=�6~   $	��222��6�   �� 5<      -   5        $��textBoxLastName��5<   k   $��23��60   $
��Left=�6<   $��
198,50,0,0q�6W   $	��Top=�6�   $	��222��6�   �� 5=      -   5        $��textBoxEmail��5=   k   $��23��60   $
��Left=�6<   $��
198,80,0,0q�6W   $	��Top=�6   $	��222��6�   G� 5?      -   5        $��passwordBox1��5?   p   $��23��64   $
��Left=�6@   $��198,108,0,0q�6[   $	��Top=�6�   $	��222��6�   G� 5A      -   5        $��passwordBoxConfirm��5A   p   $��23��64   $
��Left=�6@   $��198,136,0,0q�6[   $	��Top=�6�   $	��222��6�   �� 5B      -   5        $��textBoxAddress��5B   k   $��23��60   $
��Left=�6<   $��
198,0,0,75q�6W   $��Bottom=�6�   $	��222��6�   �� 5C      -   5        $��Submit��5C   �   
������ 
����  �
����  �$��Submit��6S   $��23��6d   $
��Left=�6p   $��183,204,0,0q�6�   $	��Top=�6�   $��70��6�   6�   �� 5D      -   5        $��button2��5D   �   
������ 
����  �
����  �$��Reset��6S   $��23��6c   $
��Left=�6o   $��259,204,0,0q�6�   $	��Top=�6�   $��70��6�   6�   �� 5E      -   5        $��button3��5E   �   
������ 
����  �
����  �$��Cancel��6S   $��23��6d   $��Right=�6p   $��
0,204,82,0q�6�   $	��Top=�6�   $��70��6�   6�   5F      5G      5H      