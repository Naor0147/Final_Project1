using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;


namespace Final_Project1.Classes
{
    public class Ball
    {
        private double Size { get; set; }
        private double x { get; set; }
        private double y { get; set; }
        private double vy { get; set; }
        private double vx { get; set; }

        private Ellipse ellipse { get; set; }

        private Canvas canvas { get; set; }

        public Ball(double Size, double x, double y, double vy, double vx, Canvas canvas)
        {
            this.Size = Size;
            this.x = x;
            this.y = y;
            this.vy = vy;
            this.vx = vx;
            this.canvas = canvas;

            Create_ball();

        }

        private  void Create_ball()
        {
            ellipse = new Ellipse
            {
                Fill = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Width = this.Size,
                Height = this.Size
            };
            Canvas.SetLeft(ellipse, this.x);
            Canvas.SetTop(ellipse, this.y);
            this.canvas.Children.Add(ellipse);
        }
        public void moveBall()
        {
            this.x += this.vx;
            this.y += this.vy;
            Canvas.SetLeft(ellipse, this.x);
            Canvas.SetTop(ellipse, this.y);
            if (x >(canvas.acWidth-100) || x<0)
            {
                this.vx = -5;
            }
            if (y>(canvas.Height-100)|| y<0)
            {
                this.vy = -5;
            }

        }
    }
}
