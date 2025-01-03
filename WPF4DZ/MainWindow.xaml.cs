using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF4DZ
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point offset;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            offset = e.GetPosition(MovingRectangle);
            MovingRectangle.CaptureMouse();
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point position = e.GetPosition(this);
                double x = position.X - offset.X;
                double y = position.Y - offset.Y;

                Canvas.SetLeft(MovingRectangle, x);
                Canvas.SetTop(MovingRectangle, y);

                XTextBox.Text = x.ToString("0");
                YTextBox.Text = y.ToString("0");
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            MovingRectangle.ReleaseMouseCapture();
        }

        private void XTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateRectanglePosition();
        }

        private void YTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateRectanglePosition();
        }

        private void UpdateRectanglePosition()
        {
            if (double.TryParse(XTextBox.Text, out double x) && double.TryParse(YTextBox.Text, out double y))
            {
                Canvas.SetLeft(MovingRectangle, x);
                Canvas.SetTop(MovingRectangle, y);
            }
        }
    }
}