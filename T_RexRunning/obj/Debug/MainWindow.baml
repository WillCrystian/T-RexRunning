   M S B A M L   `   `   `  ����G  CT_RexRunning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:T_RexRunningT_RexRunning  5   	       T_RexRunning.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   &localclr-namespace:T_RexRunning  5   	     � Title$  T-Rex Running��5	   	   $	��450��6   $	��800��6,   .��5
      �� -   5        $��MyCanvas��5
      ���	#FFD2D2D2|�. .+�5   
   �� -   5        $	��Rex��5      $��70��6   $��60��6(    �� Left$ 75��63   
 �� Top$	 290��6D   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ image/running.gif��6U   $
��fill=�6�   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5        $��RexAbaixado��5      $��45��6$   $��80��60   $
 -117��6;   $	 317��6N   $ image/lowered.gif��6_   $
��fill=�6�   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5        $��gdObstacle1��5      $	 200��6#   $	 300��65   $��60��6F   $��40��6R   $��image/obstacle1.gif��6]   $
��Fill=�6z   $
��Left=�6�   $	��top=�6�   �� 5   
   -   5        $��gdObstacle2��5      $	 400��6#   $	 300��65   $��60��6F   $��60��6R   $��image/obstacle2.gif��6]   $
��Fill=�6z   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5        $��gdObstacle3��5      $	 600��6#   $	 310��65   $��50��6F   $��90��6R   $��image/obstacle3.png��6]   $
��Fill=�6z   $
��Left=�6�   $	��Top=�6�   �� 5   
   -   5        $��gdObstacle4��5      $	 800��6#   $	 260��65   $��50��6F   $��70��6R   $ image/passaro.gif��6]   $
��Fill=�6�   $
��Left=�6�   $	��top=�6�   �� 5   
   -   5        $��Ground��5      $	��100��6"   $
 -114��6/   
���   �$	 360��6Q   $	��998��6b   
���   �$
��Left=�6{   $��Center=�6�   �� 5   
   -	   5        $��
lbGameOver��5      $��	Game Over��6"   $	 281��66   $	 159��6H   $��Center=�6Y   $	��222��6t   $��49��6�   $��36(�6�   $
��Bold"�6�   $��Arial)�6�   $��Center=�6�   $��Center=�6�   $
��Left=�6  5      5      