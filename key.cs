xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
Title="Window1" Height="350" Width="525"
KeyDown="Window_KeyDown">
  private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                MessageBox.Show("Pressed F5 mordo");
            }
        }
