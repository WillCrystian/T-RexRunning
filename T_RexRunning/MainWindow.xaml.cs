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

        int speedObstacle = 8;
        Rect rexHitBox;
        Rect groudHitBox;

        List<Grid> listGrid = new List<Grid>();

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

            //verifica se está tocando no chão e não está pulando
            if (rexHitBox.IntersectsWith(groudHitBox) && jumping == false)
            {
                gravity = 0;
                force = 6;
                jumping = false;
            }

            // se estiver pulando e a força estiver acabado
            if (jumping == true && force < 0)
            {
                jumping = false;
            }           
            
            // verifica se está pulando
            if (jumping == true)
            {
                gravity = -8;
            }
            //verifica se não está pulando e se não está tocando o chão
            else if(jumping == false && !rexHitBox.IntersectsWith(groudHitBox))
            {
                gravity = 4;
            }     
            
            foreach(var x in listGrid)
            {
                //se estiver visivel movimenta-se
                if(x.Visibility == Visibility.Visible)
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - speedObstacle);
                }

                //se estiver fora da tela, fique invisível
                if(Canvas.GetLeft(x) < -150)
                {
                    x.Visibility = Visibility.Hidden;
                    Canvas.SetLeft(x, 700);
                    SpawnGrid();
                }
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

            //Adicionando todos os gridsna lista
            foreach(var x in MyCanvas.Children)
            {                
                if(x is Grid)
                {
                    listGrid.Add((Grid)x);
                }
            }  
            
            //colocar todos grid em invisível
            foreach(var y in listGrid)
            {
                y.Visibility = Visibility.Hidden;
                Canvas.SetLeft(y, 800);
            }

            //Spawn de obstáculo para começar a lógica
            listGrid[0] .Visibility = Visibility.Visible;
            Canvas.SetLeft(listGrid[0], -100);


            gameTimer.Start();
        }

        private void EndGame()
        {
            gameTimer.Stop();
        }

        private void SpawnGrid()
        {
            int cont = 0;
            foreach(var x in listGrid)
            {
                if(x.Visibility == Visibility.Visible)
                {
                    cont++;
                }
            }
            if(cont == 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, listGrid.Count);
                
                listGrid[index].Visibility = Visibility.Visible;
            }
            
        }
    }
}
