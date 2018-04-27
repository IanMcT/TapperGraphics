using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tapperGraphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BitmapImage bitmap = new BitmapImage(new Uri("tapped.png", UriKind.Relative));
            canvas.Background = new ImageBrush(bitmap);
            //drawSemiTransparentBackground();

            
            drawLeftWall();
            drawRightWall();
            drawBackWall();
            drawFloor();
            drawServingBars();
        }

        private void drawLeftWall()
        {
            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.LimeGreen;
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(236, 0));
            polygon.Points.Add(new Point(236, 124));
            polygon.Points.Add(new Point(10, this.Height));
            polygon.Points.Add(new Point(0, this.Height));
            canvas.Children.Add(polygon);
        }
        private void drawBackWall()
        {
            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.LightYellow;
            polygon.Points.Add(new Point(236, 124));
            polygon.Points.Add(new Point(674, 123));
            polygon.Points.Add(new Point(673, 0));
            polygon.Points.Add(new Point(236, 0));
            canvas.Children.Add(polygon);
        }
        private void drawFloor()
        {
            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.Magenta;
            polygon.Points.Add(new Point(236, 124));
            polygon.Points.Add(new Point(674, 123));
            polygon.Points.Add(new Point(911, this.Height));
            polygon.Points.Add(new Point(10, this.Height));
            canvas.Children.Add(polygon);
        }
        private void drawRightWall()
        {
            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.Purple;
            polygon.Points.Add(new Point(673, 0));
            polygon.Points.Add(new Point(674, 123));
            polygon.Points.Add(new Point(911, this.Height));
            polygon.Points.Add(new Point(this.Width, this.Height));
            polygon.Points.Add(new Point(this.Width, 0));
            canvas.Children.Add(polygon);
        }

        private void drawSemiTransparentBackground()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Color.FromArgb(175, 255, 255, 255));
            rectangle.Width = this.Width;
            rectangle.Height = this.Height;
            canvas.Children.Add(rectangle);
        }

        private void drawServingBars()
        {
            //drawLinesToDetermineDistance();

            Rectangle topBar = new Rectangle();
            topBar.Width = 420;
            topBar.Height = 55;
            topBar.Fill = Brushes.Blue;
            canvas.Children.Add(topBar);
            Canvas.SetTop(topBar, 125);
            Canvas.SetLeft(topBar, 200);

            Rectangle secondBar = new Rectangle();
            secondBar.Width = 540;
            secondBar.Height = 55;
            secondBar.Fill = Brushes.Yellow;
            canvas.Children.Add(secondBar);
            Canvas.SetTop(secondBar, 234);
            Canvas.SetLeft(secondBar, 140);

            Rectangle thirdBar = new Rectangle();
            thirdBar.Width = secondBar.Width + (secondBar.Width - topBar.Width);
            thirdBar.Height = 55;
            thirdBar.Fill = Brushes.Pink;
            canvas.Children.Add(thirdBar);
            Canvas.SetTop(thirdBar, Canvas.GetTop(secondBar) + (Canvas.GetTop(secondBar) - Canvas.GetTop(topBar)));
            Canvas.SetLeft(thirdBar, Canvas.GetLeft(secondBar) + (Canvas.GetLeft(secondBar) - Canvas.GetLeft(topBar)));

            Rectangle bottomBar = new Rectangle();
            bottomBar.Width = thirdBar.Width + (thirdBar.Width - secondBar.Width);
            bottomBar.Height = 55;
            bottomBar.Fill = Brushes.Green;
            canvas.Children.Add(bottomBar);
            Canvas.SetTop(bottomBar, Canvas.GetTop(thirdBar) + (Canvas.GetTop(thirdBar) - Canvas.GetTop(secondBar)));
            Canvas.SetLeft(bottomBar, Canvas.GetLeft(thirdBar) + (Canvas.GetLeft(thirdBar) - Canvas.GetLeft(secondBar)));
        }

        private void drawLinesToDetermineDistance()
        {
            for (int i = 0; i < this.Height; i = i + 78)
            {
                Rectangle r = new Rectangle();
                r.Fill = Brushes.Red;
                r.Height = 2;
                r.Width = this.Width;
                canvas.Children.Add(r);
                Canvas.SetTop(r, i);
            }
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(e.GetPosition(this).ToString());
            
            
        }
    }
}
