   M S B A M L   `   `   `  ����E  AWPF-Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_Agenda
WPF_Agenda  5      !    WPF_Agenda.appointmentsList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WPF_Agenda     5        N� Title$  appointmentsList��5	      .��5      � ���#e9ecef � ColumnDefinitions 5   
   �� 5      $	��500 �6   �� 5      $	��300 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��appointmentsDataGrid��5   @      AutoGenerateColumns$ False��6\   $��0��6x      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Client��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *IdCustomerNavigation.Lastname+  5      $ Courtier��6%    67   �� *IdBrokerNavigation.Lastname+  5      $ 
Date/Heure��6%    69   �� *
DateHour+5      �� 5   
   $��1��6   $��10q�6%   .+�5      �� -   5        $��id��5      $y�Hidden=�6   64   �� 5      .��6   
Client :6   �� 5      -   5        $��customerComboBox��5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��16��6D   $��16��6O   $��0,2,5,2q�6[   ��6(   �� *
IdCustomer+6[   �� 5      ��6(   �� *
Lastname+5       5!      5#      �� 5$      .��6   
Courtier :6    �� 5%      -   5        $��brokerComboBox��5%      ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6%   .+�5)      �� $��16��6B   $��16��6M   $��0,2,5,2q�6Y   ��6(   �� *
IdBroker+6Y   �� 5*      ��6(   �� *
Lastname+5+      5,      5.      �� 5/      .��6   Date du rendez-vous6)   (  "System.Windows.Controls.DatePicker  50      -   5        $��appointmentdate��50      62   �� 51      .��6   	Heure :6   �� 52      -   5        $��appHour��52      6'   �� 53      .��6   
Minute :6   �� 54      -   5        $��	appMinute��54      6)   �� 55      .��6   	Sujet :6   �� 56      -   5        $��
appSubject��56      6*   �� 57      -	   5        $��Center=�57   /   .��6L   
Modifiez6V   �� 58      -
   5        $��Center=�58   /   .��6L   	Supprimez6W   �� 59      -   5        $��erreurMessage��59      6+   5:      5;      5<      