   M S B A M L   `   `   `  ����L  HMiniEditorBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MiniEditorBindingMiniEditorBinding  5   	   "    MiniEditorBinding.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MiniEditorBinding     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      #   MiniEditorBinding.GlassToBool   GlassToBoolconv��%   &	          5
   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6    � DataContext 6%   ��  �� ElementName$
 lbox�� �� Path$ SelectedItem�.+�5      �� $
��Név��6   
����ح�$��10q�69   �� 5      $��10q�6Q   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6Q   �� 5      $��Életkor��6   
����ح�$��10q�6=   �� 5      $��10q�6P   ��6   �� *Age+$ PropertyChanged=�6P   �� 5      $��Szemüveges-e?��6   
����ح�$��10q�6C   �� 5      $
��Igen��6   $��10q�6t    d� 	IsChecked 6&   �� *HaveGlasses+ �� 	Converter# [  6t   �� 5      -   5        $��	Váltás!��5      $��10q�6'   64   �� 5      $��
Müveletek��6   
����ح�$��10q�6?   �� 5      -   5        $��Új személy!��5      $��10q�6+   68   5      �� 5   
   -   5        	 ��Name$
	 lbox��5   "   $��1��6   $��Stretch=�60   ��5      �� 5      .R�5      �� 
���   �$��1q�61   ._�5       �� .+�5!      �� 
 �� ContentStringFormat$
 	Név: {0}��6=   ��6$   �� *Name+6=   �� 5"      $
 Életkor: {0}��6<   ��6$   �� *Age+6<   �� 5#      $
 Szemüveges: {0}��6D   ��6$   �� *HaveGlasses+6D   5$      5%      5&      5(      5)      5*      