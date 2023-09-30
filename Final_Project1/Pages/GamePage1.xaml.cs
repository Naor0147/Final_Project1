using Final_Project1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
        public GamePage1()
        {
            this.InitializeComponent();
          
            _ball = new Ball(100,400,400,5,5,Canvas_game);

            //Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);
            timer.Tick += Timer_Tick; 
            timer.Start();
            //
        }

        private void Timer_Tick(object sender, object e)
        {
            Timer_text.Text = DateTime.Now.ToString("HH:mm:ss.fff");
            _ball.moveBall();
        }
    }
}
