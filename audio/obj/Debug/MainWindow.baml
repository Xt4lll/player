   M S B A M L   `   `   `  ����@  <audio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:audioaudio  5   	       audio.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:audio     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5   
   �� -   5        $-��'выбор папки с музыкой��5      $��6��61   $��Stretch=�6E   $��	10,5,10,5q�6c   $��Stretch=�6v   6�   �� 5   
   -   5         ��Name$ listBox��5      $��6��6#   $��1��67   $��	10,5,10,5q�6D   $��Stretch=�6W   $��Stretch=�6s   6�   r� 5   
   -   5         r�Name$ mediaPlayer��5       r� LoadedBehavior$ Manual=�6,   6j   �� 5   
   -   5         ��Name$ slider��5      $��6��6!   $��Stretch=�65   $��	10,5,10,5q�6S   $��2��6f   $	��Top=�6s   6�   �� 5   
   -   5         ��Name$ mediaPlayerTimer��5      $
��Left=�6.    �� Padding$
 10,0q�6I   $��2��6X   $��	TextBlock��6e   $
��Wrap=�6v   $��Bottom=�6�   �� 5   
   -   5        $ timeLeft��5      $��Right=�6&   $
 10,0q�6B   $��2��6Q   $��5��6^   $��	TextBlock��6n   $
��Wrap=�6   $��Bottom=�6�   �� 5   
   -   5           MaterialDesignIconButton#��[  5       $��Stretch=�5!      $��	10,5,10,5q�6+   $��3��6>   $��1��6K   $��Stretch=�6[   	 � ToolTip$	 MaterialDesignIconButton��5"      {�5#      �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ WindowL�.��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Play=�5%      5&      �� 5'   
   -   5         ��Name$ previous��5)      #��[  5(      $��Stretch=�5)      $��	10,5,10,5q�6=   $��3��6P   $��Stretch=�6]   $	 MaterialDesignIconButton��5*      {�5+      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�.��5,        $ PreviousTitle=�5-      5.      �� 5/   
   -	   5        $
 next��51      #��[  50      $��Stretch=�51      $��	10,5,10,5q�69   $��3��6L   $��2��6Y   $��Stretch=�6i   $	 MaterialDesignIconButton��52      {�53      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�.��54        $ 	NextTitle=�55      56      �� 57   
   -
   5        $ repeat��59      #��[  58      $��Stretch=�59      $��	10,5,10,5q�6;   $��3��6N   $��3��6[   $��Stretch=�6k   $	 MaterialDesignIconButton��5:      {�5;      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�.��5<        $ Repeat=�5=      5>      �� 5?   
   -   5        $ shuffle��5A      #��[  5@      $��Stretch=�5A      $��	10,5,10,5q�6<   $��3��6O   $��4��6\   $��Stretch=�6l   $	 MaterialDesignIconButton��5B      {�5C      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+$ WindowL�.��5D        $ Shuffle=�5E      5F      5G      5H      