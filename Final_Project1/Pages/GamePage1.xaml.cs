using Final_Project1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Final_Project1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage1 : Page
    {
        public DispatcherTimer timer;
        public const double Gravity = 9.8;
        Ball _ball;
        List<Rectangle> _Border_List;
        public GamePage1()
        {
            this.InitializeComponent();

            //Get Borders 
            Get_Borders();

            //Timer
            Start_Timer();

           

        }

        private void Get_Borders()
        {
            _Border_List = new List<Rectangle>();
            var _border_List = Canvas_game.Children.OfType<Rectangle>().Where(rectangle => rectangle.Tag!= null &&rectangle.Tag.ToString() == "border_canvas");// gets all the border i the game page
            int i = 0;
            foreach (var _border in _border_List)
            {
                _Border_List.Add( _border);
                i++;
            }
        }

        private void Start_Timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Timer_text.Text = DateTime.Now.ToString("HH:mm:ss.fff");
            if (_ball!= null)
            {
                _ball.moveBall();

            }
        }

        private void Canvas_game_Loaded(object sender, RoutedEventArgs e)
        {
            _ball = new Ball(100, 400, 400, 4, 5, Canvas_game , _Border_List);

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            foreach(Rectangle rectangle in _Border_List)
            {
                if (rectangle.Width==1880)
                {
                    
                    double calc = (_Grid.ActualHeight / 6 * 5) - 20 - 40 - 20;
                    Canvas.SetTop(rectangle, calc);
                    break;                 
                }
            }
           
            
        }
    }
}
