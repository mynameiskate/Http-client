   M S B A M L   `   `   `  ����G  CHttpProtocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HttpProtocolHttpProtocol  5   	   +clr-namespace:HttpProtocolHttpProtocol  5   	       HttpProtocol.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HttpProtocol     5   	   *srcclr-namespace:HttpProtocol     5   	     � Title$  HTTP protocol manager��5	   	   $	��500��6'   $	��900��64   
������.��5
      � .+�5   
   �� -   5        $��	methodBox��5   q   $
��Left=�6   $��
120,31,0,0q�6.   $	��Top=�6B   $��74��6Z   $��28��6e   $��Futura)�5      $��20(�6(   $��Light"�66   
������� � DataContext$ 
MethodType��6`   .@�5      �� �� 6   $	�GET��6   6+   �� 5      �� 6   $
�POST��6   6,   �� 5      �� 6   $
�HEAD��6   6,   5      �� 5   
   $��Method��6   $
��Left=�6!   $��	25,25,0,0q�6<   $	��Top=�6O   $��90��6g   $��Futura)�5      $��20(�6$   $��Medium"�62   �� 5   
   -   5        $��
uriTextBox��5      $
��Left=�6$   $��28��6?    �� TextWrapping$
 Wrap=�6K   $�� ��6_   $	��Top=�6g   $	��593��6   $��
209,31,0,0q�5      $��Futura)�6&   $��16(�6:   $��Light"�6H   $ �� HorizontalScrollBarVisibility$
 Auto=�6[   �� 5   
   -   5        $��startBtn��5      $��Go��5      $
��Left=�6   $	��Top=�69   $��62��6Q   $��
807,31,0,0q�6\   $��28��6p   
�������$��Futura)�5   8   $��20(�6L   $��Light"�6Z    J� RenderTransformOrigin$ 1.358,0.391&�6�   (  "System.Windows.Controls.WebBrowser  5   
   -   5        $��requestWebBrowser��5      $
��Left=�5      $	��347��60   $	��Top=�6=   $	��510��6U   $��	10,97,0,0q�6a   ?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ Vertical=�5   .   #   HttpProtocol.WebBrowserHelper   Body 5      �� *	Message+6C   �� 5   
   -   5        $��statusTB��5      $
��Left=�5      $	��347��6-   $
 Wrap=�6:   $	��Top=�5      $	��329��5   "   $��
540,97,0,0q�6.   
�������$��Futura)�6Y   $��18(�5      $��Light"�6    " �� VerticalScrollBarVisibility$
 Auto=�63   ��5   N   ��  �� Path$ Status�	 �� Mode$	 TwoWay=�5   3   �� 5   
   -   5        
 ��Name$
 dataTextBox��5      $
��Left=�6'   $��28��6B   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��593��6�   $��
209,64,0,0q�5       $��Futura)�6!   $��16(�65   $��Light"�6C   $
 Auto=�6V   5!      5"      