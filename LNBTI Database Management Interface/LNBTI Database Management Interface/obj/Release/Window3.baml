   M S B A M L   `   `   `  ���� ^  ZLNBTI Database Management Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:LNBTI_Database_Management_Interface#LNBTI_Database_Management_Interface  1    +LNBTI_Database_Management_Interface.Window3   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:LNBTI_Database_Management_Interface     -     �Name$  frmNewPayment�� � Title$ New Payment Record��$��283.67��$��382.5�� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=� � Icon$ LNBTI_logo.png��.���  � RowDefinitions �� .+��� $��Index No��$��	15,19,0,0q�$	��Top=�$
��Left=��� $
��Name��$��	15,44,0,0q�$	��Top=�$
��Left=��� -    ��Name$ txtReg_No_4�� �� TextWrapping$
 Wrap=�$��
114,23,0,0q�$	��Top=�$
��Left=�$	��178���� $��Slip No��$��
14,167,0,0q�$	��Top=�$
��Left=��� -   $ 	txtSlipNo��$
 Wrap=�$��114,171,0,0q�$	��Top=�$
��Left=�$	��152���� $��	Paid Date��$��
14,202,0,0q�$	��Top=�$
��Left=�(  "System.Windows.Controls.DatePicker  -   	  Name$	 dpkPaidDate��
   SelectedDateFormat$
 Short=� J� RenderTransformOrigin$ 0.814,14.042&�$��114,202,0,0q�$��24��$	��Top=�$
��Left=��� $��Payment Option��$��	15,70,0,0q�$	��Top=�$
��Left=��� -    ��Name$ lblPaymentOption��$�� ��$��
116,71,0,0q�$	��Top=�$
��Left=�$
��Bold"��� -    ��Name$ 	btnSubmit��$��Submit��$
��Left=�$��26��$��284,169,0,0q�$	��Top=�$��70���� -   $ 	btnCancel��$��Cancel��$
��Left=�$��26��$��284,200,0,0q�$	��Top=�$��70���� -   $ lblName��$�� ��$��
116,45,0,0q�$	��Top=�$
��Left=�$ 0.619,-0.577&�$
��Bold"��� -	   $ btnAutoFill��$��	Auto Fill��$
��Left=�$��28��$��
297,18,0,0q�$	��Top=�$��57���� $��Amount��$��	15,96,0,0q�$	��Top=�$
��Left=�$ 0.5,0.5&��� -
   $ 	lblAmount��$�� ��$��
116,97,0,0q�$	��Top=�$
��Left=�$
��Bold"��� $
��NOPD��$��
237,70,0,0q�$	��Top=�$
��Left=��� -   $ lblNOPD��$�� ��$��
285,71,0,0q�$	��Top=�$
��Left=�$
��Bold"��� -   $ btnToday��$��Today��$
��Left=�$��24��$��221,202,0,0q�$	��Top=�$��45��