   M S B A M L   `   `   `  ����G  CPrilPractika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PrilPractika.Views.AdminPagePrilPractika.Views.AdminPage  5      +    %PrilPractika.Views.AdminPage.FinePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PrilPractika.Views.AdminPage     5        N� Title$  FinePage��5	      .��5      � ���#e9e9e9 � RowDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��373* �6   .+�5   
   � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Bottom=�6   $��0 50 0 0q�69   $
��Left=�6M   $ 
Horizontal=�6h   .+�5      �� -   5        $��	TxbSearch��5   i   $	��Top=�6   $��20��66   $	��330��6B   $
��Left=�6N      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��
BtnRefresh��5   n   $��Right=�6   $	��Top=�69   $��5 0 10 0q�6Q   $��20��6c   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6    5      5      �� 5      $��40��6   $	��200��6)   $	��Top=�66   $
��Left=�6N   $�� -368 32 0 0q�6i   $ 
Horizontal=�6   .+�5      �� $	��Top=�6   $��24��64   $*��$Количество штрафов:��6@   �� 5      -   5         ��Name$ LBlOrder��5   4   $	��Top=�6   $��24��6G   5      5      �� 5       -   5        $��BtnAdd��5    �   $��15(�6   
������ $��0q�6<   $��30��6P   $	��150��6\   $�� 200 38 25 0q�6h   $!��Добавить штраф��6~   $��Right=�6�   $��Bottom=�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��	GridOrder��5"   1      AutoGenerateColumns$ False��6   $��1��6B     DataGridStyle#��[ 6O      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 62   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *Id+  5%      $# Название штрафа��6%   $ 90 6>   	 6I   �� *Name+  5&      $ Сумма штрафа��6%   $ * 6;   	 6E   �� *
FineAmount+4  .System.Windows.Controls.DataGridTemplateColumn  5'      $  ��6)   
   CellTemplate
 5(      �� 5)      .R�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� $��BtnEdit��6R   -   5        $��20��5+   )   $��23��65   $��5 5 5 5 q�6@   
������ $��0q�6�   .��5,   &   �� $#��\Resource\Imagine\EditPng.png��6,   $��15��6T   $��23��6`   5-   #   �� 5.   "   $��	BtnDelete��6S   -   5        $��20��5.   )   $��23��65   $��5 5 5 5 q�6A   
������ $��0q�6�   .��5/   &   �� $%��\Resource\Imagine\DeletePng.png��6,   $��15��6V   $��23��6b   50   #   51      52      54      56      57      58      