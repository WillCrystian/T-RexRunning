﻿using System;
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
using WpfAnimatedGif;

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
        int gravity = 10;
        bool isGround;
        bool isLowered;

        int speedObstacle;
        Rect rexHitBox;
        Rect groudHitBox;
        Rect obstacleHitBox;

        List<Image> listImage = new List<Image>();

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
           
            HitBoxSelect();
            groudHitBox = new Rect(Canvas.GetLeft(Ground), Canvas.GetTop(Ground)-5, Ground.Width, Ground.Height);
            
            //verifica se está tocando no chão e não está pulando
            if (rexHitBox.IntersectsWith(groudHitBox) && jumping == false)
            {
                gravity = 0;
                force = 15;
                jumping = false;
                isGround = true;
            }

            // se estiver pulando e a força estiver acabado
            if (jumping == true && force < 0)
            {
                jumping = false;
            }           
            
            // verifica se está pulando
            if (jumping == true)
            {
                force -= 1;
                gravity = -10;
                isGround = false;
            }
            //verifica se não está pulando e se não está tocando o chão
            else if(jumping == false && !rexHitBox.IntersectsWith(groudHitBox))
            {
                gravity = 8;
            }     
            
            foreach(var x in listImage)
            {
                //se estiver visivel movimenta-se
                if(x.Visibility == Visibility.Visible)
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - speedObstacle);

                    obstacleHitBox = new Rect(Canvas.GetLeft(x)+5, Canvas.GetTop(x), x.Width-5, x.Height);                    
                    if (rexHitBox.IntersectsWith(obstacleHitBox))
                    {
                        EndGame();
                    }

                    //se estiver fora da tela, fique invisível
                    if (Canvas.GetLeft(x) < -150)
                    {
                        x.Visibility = Visibility.Hidden;
                        Canvas.SetLeft(x, 700);
                        SpawnGrid();
                    }
                }

                
            }
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {            
            if(e.Key == Key.Space && jumping == false && force >= 0)
            {                
                jumping = true;           
            }

            //Restart Game
            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }

            //troca de imagem
            if(e.Key == Key.Down && isGround == true)
            {
                SwapDinoToLowered();
            }
        }       

        private void KeyisUp(object sender, KeyEventArgs e)
        {           
            if (e.Key == Key.Space)
            {
                jumping = false;
            }
            //troca de imagem
            if (e.Key == Key.Down)
            {
                SwapDinoToUppered();
            }
        }

        private void StartGame()
        {
            gameOver = false;
            jumping = false;
            isGround = true;
            isLowered = false;
            speedObstacle = 7;
            force = 15;
            lbGameOver.Visibility = Visibility.Hidden;

            Canvas.SetTop(Rex, 288);
            SwapDinoToUppered();
            rexHitBox = new Rect(Canvas.GetLeft(Rex), Canvas.GetTop(Rex), Rex.Width, Rex.Height - 3);
            MyCanvas.Focus();

            //Adicionando todos os gridsna lista
            foreach(var x in MyCanvas.Children.OfType<Image>())
            {                
                if(x is Image && x.Name.Contains("gdObstacle"))
                {
                    listImage.Add((Image)x);
                }
            }  
            
            //colocar todos grid em invisível
            foreach(var y in listImage)
            {
                y.Visibility = Visibility.Hidden;
                Canvas.SetLeft(y, 800);
            }

            //Spawn de obstáculo para começar a lógica
            listImage[0].Visibility = Visibility.Visible;
            Canvas.SetLeft(listImage[0], -100);

            gameTimer.Start();
        }

        private void EndGame()
        {
            lbGameOver.Visibility = Visibility.Visible;
            gameOver = true;
            gameTimer.Stop();
        }

        private void SpawnGrid()
        {
            int cont = 0;
            foreach(var x in listImage)
            {
                if(x.Visibility == Visibility.Visible)
                {
                    cont++;
                }
            }
            if(cont == 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, listImage.Count);
                
                listImage[index].Visibility = Visibility.Visible;
            }            
        }

        private void SwapDinoToLowered()
        {
            isLowered = true;
            Canvas.SetLeft(Rex, -300);
            Canvas.SetLeft(RexAbaixado, 75);            
        }
        private void SwapDinoToUppered()
        {
            isLowered = false;
            Canvas.SetLeft(RexAbaixado, -300);
            Canvas.SetLeft(Rex, 75);            
        }

        private void HitBoxSelect()
        {
            if (isLowered)
            {
                rexHitBox = new Rect(Canvas.GetLeft(RexAbaixado), Canvas.GetTop(RexAbaixado), RexAbaixado.Width, RexAbaixado.Height - 3);
            }
            else
            {
                rexHitBox = new Rect(Canvas.GetLeft(Rex), Canvas.GetTop(Rex), Rex.Width, Rex.Height - 3);
            }
        }
    }
}
