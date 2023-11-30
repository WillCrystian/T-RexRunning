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

        bool gameOver;
        bool jumping;
        int force;
        int gravity = 6;
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

            if (rexHitBox.IntersectsWith(groudHitBox) && jumping == false)
            {
                gravity = 0;
                force = 6;
                jumping = false;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }           
            
            if (jumping == true)
            {
                gravity = -6;
            }
            else if(jumping == false && !rexHitBox.IntersectsWith(groudHitBox))
            {
                gravity = 6;
            }

            
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            force -= 1;
            if(e.Key == Key.Space && jumping == false && force >= 0)
            {                
                jumping = true;           
            }
            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }
        }

       

        private void KeyisUp(object sender, KeyEventArgs e)
        {           
            if (e.Key == Key.Space)
            {
                jumping = false;
            }            
        }


        private void StartGame()
        {
            gameOver = false;
            jumping = false;
            force = 6;

            Canvas.SetTop(Rex, 268);

            MyCanvas.Focus();
            gameTimer.Start();
        }

        private void EndGame()
        {
            gameTimer.Stop();
        }
    }
}
