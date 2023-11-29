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
using System.Windows.Threading;

namespace T_RexRunning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool gameOver = false;
        bool jumping = false;
        int gravity = 8;
        Rect rexHitBox;
        Rect groudHitBox;

        DispatcherTimer gameTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            Canvas.SetTop(Rex, Canvas.GetTop(Rex) + gravity);

            rexHitBox = new Rect(Canvas.GetLeft(Rex),Canvas.GetTop(Rex), Rex.Width, Rex.Height);
            groudHitBox = new Rect(Canvas.GetLeft(Ground), Canvas.GetTop(Ground)-5, Ground.Width, Ground.Height);
            if (rexHitBox.IntersectsWith(groudHitBox))
            {
                gravity = 0;
                jumping = false;
            }
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space && jumping == false)
            {
                gravity = -8;
            }
        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                gravity = 8;
            }
        }

        private void StartGame()
        {
            gameTimer.Start();
        }

        private void EndGame()
        {
            gameTimer.Stop();
        }
    }
}
