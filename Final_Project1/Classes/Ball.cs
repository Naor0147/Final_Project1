using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using System.Windows;
using Windows.UI.Xaml;
using System.Diagnostics;

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

        private List<Rectangle> Borders { get; set; }

        public Ball(double Size, double x, double y, double vy, double vx, Canvas canvas , List<Rectangle> Borders)
        {
            this.Size = Size;
            this.x = x;
            this.y = y;
            this.vy = vy;
            this.vx = vx;
            this.canvas = canvas;

            this.Borders = Borders;

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
            
            Rect ellipseBounds = new Rect(new Point(Canvas.GetLeft(ellipse), Canvas.GetTop(ellipse))
                , new Point(Canvas.GetLeft(ellipse) + ellipse.Width, Canvas.GetTop(ellipse) + ellipse.Height));
            
            
            foreach (Rectangle rect in Borders)
            {
                // Get the positions and sizes of the rectangle and ellipse
                // Corrected code to create Rect objects
                Rect rectBounds = new Rect(new Point(Canvas.GetLeft(rect), Canvas.GetTop(rect)), new Point(Canvas.GetLeft(rect) + rect.Width, Canvas.GetTop(rect) + rect.Height));


                // Check for collision by comparing the bounds of the rectangle and ellipse
                //bool hasCollided = rectBounds.IntersectsWith(ellipseBounds);
                Rect _rect = RectHelper.Intersect(ellipseBounds, rectBounds);
                bool _rectHelp = AreRectanglesColliding(rectBounds, ellipseBounds);


                if (_rect.Width > 0 || _rect.Height > 0)
                {
                    Debug.WriteLine(_rect.ToString());

                    See_Collison(_rect);
                    if (_rect.Width>_rect.Height)
                    {
                        this.vx = -vx;
                    }
                    else
                    {
                       this.vy = -vy;
                    }

                }


            }




        /*    if (x >(canvas.ActualWidth) || x<0)//doesnt get the real height and width 
            {
                this.vx = -5;
            }
            if (y>(canvas.ActualWidth)|| y<0)
            {
                this.vy = -5;
            }
        */
        }

        private void See_Collison(Rect _rect)
        {
            Rectangle boundaryRect = new Rectangle();
            boundaryRect.Width = _rect.Width;  // Set the width to match the Rect
            boundaryRect.Height = _rect.Height;  // Set the height to match the Rect
            boundaryRect.Stroke = new SolidColorBrush(Colors.Red);  // Set the border color to red
            boundaryRect.StrokeThickness = 2;
            Canvas.SetLeft(boundaryRect, _rect.Left);
            Canvas.SetTop(boundaryRect, _rect.Top);
            canvas.Children.Add(boundaryRect);
        }

        public bool AreRectanglesColliding(Rect rect1, Rect rect2)
        {
            return (rect1.Left < rect2.Right && rect1.Right > rect2.Left && rect1.Top < rect2.Bottom && rect1.Bottom > rect2.Top);
        }

    }
}
