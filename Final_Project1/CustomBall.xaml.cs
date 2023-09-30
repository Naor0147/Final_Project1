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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Final_Project1
{
    public sealed partial class CustomBall : UserControl
    {
        public CustomBall()
        {
            InitializeComponent();
        }

        // Define a dependency property for the ball's color
        public static readonly DependencyProperty BallColorProperty =
            DependencyProperty.Register(
                "BallColor",
                typeof(Brush),
                typeof(CustomBall),
                new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        public Brush BallColor
        {
            get { return (Brush)GetValue(BallColorProperty); }
            set { SetValue(BallColorProperty, value); }
        }

        // Add more properties as needed
    }
}
