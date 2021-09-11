﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Graphen
{

    public partial class MainWindow : Window
    {
        String version = "0.1"; //set version
        double m;
        double t;
        double unitstobarrierleft = 7.5;
        double a = 0;
        int gridx = -1;
        int gridy = 4;
        int count = 0;
        bool drawn = false;
        double olda;
        double oldt;
        double oldm;
        int children;
        bool delete;
        double iz = 0;
        
        public MainWindow()
        {



            DispatcherTimer D = new DispatcherTimer();
            D.Interval = TimeSpan.FromMilliseconds(25);
            D.Tick += D_Tick;
            D.Start();

            InitializeComponent();
            Title = "Graphs v"+version;
            InitGrid();
            InitAxis();
            children = paint.Children.Count;
            L1_Copy.Content = paint.Children.Count;
        }


        private void D_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter) || btn.IsPressed == true)
            {

                if (mf.Text != "" && tf.Text != "" && af.Text != "")
                {
                    try
                    {
                        a = double.Parse(af.Text);
                        m = double.Parse(mf.Text);
                        t = double.Parse(tf.Text);
                        

                        if (drawn == false)
                        {
                            if (af.Text != "" && af.Text != "0")
                            {
                                

                                drawParabel(a, m, t);
                                drawn = true;
                            }
                            else
                            {
                                DrawGraph();
                                drawn = true;
                            }
                        }
                        else if (drawn == true && (oldm != m || oldt != t || olda != a))
                        {
                            delete = true;
                            while (paint.Children.Count >= children && delete == true)
                            {
                                paint.Children.RemoveAt(paint.Children.Count - 1);
                                paint.Children.RemoveAt(paint.Children.Count - 1);
                            }
                            delete = false;

                            if (af.Text != "" && af.Text != "0")
                            {
                                

                                drawParabel(a, m, t);


                                drawn = true;
                            }
                            else
                            {
                                DrawGraph();
                                drawn = true;
                            }
                        }
                    }
                    catch { }

                    if (mf.Text == "TOAST" && tf.Text == "BROT")
                    {


                    }
                }
            }

        }

        public void drawLine(double x1, double y1, double down, double right, int thickness, System.Windows.Media.Brush cl)
        {
            if (drawn == false)
            {
                System.Windows.Shapes.Line myLine = new System.Windows.Shapes.Line();
                myLine.Stroke = cl;
                Canvas.SetLeft(myLine, x1);
                Canvas.SetTop(myLine, y1);
                myLine.X1 = right;
                myLine.Y1 = down;
                myLine.StrokeThickness = thickness;
                paint.Children.Add(myLine);

            }

        }
        private void drawParabel(double a2, double b2, double c2)
        {

            try
            {
                double a = Convert.ToDouble(a2);
                double b = (double)Convert.ToDouble(b2);
                double c = (double)Convert.ToDouble(c2);
                double klammerfaktor = 1;
                double afkt = 1;
                double bfkt = 1;
                
                klammerfaktor = a;
                bfkt = b / klammerfaktor;
                Math.Round(bfkt, 3);
                //Console.WriteLine(bfkt);
                if (afkt < 0)
                {
                    klammerfaktor = -klammerfaktor;
                    afkt = -1;
                    bfkt = -bfkt;

                }
                else if (afkt > 0)
                {
                }
                //Console.WriteLine(".............");
                //DopGem
                /*Console.WriteLine(bfkt / 2);
                Console.WriteLine(klammerfaktor + "*(" + afkt + "*(x²+" + bfkt / 2 + "*2*x+" + (bfkt / 2) * (bfkt / 2) + "-" + (bfkt / 2) * (bfkt / 2) + ")+" + c5);
                Console.WriteLine(".............");
                Console.WriteLine(klammerfaktor + "(x+" + bfkt / 2 + ")²" + "(" + -bfkt / 2 + "^2))+" + c5);
                Console.WriteLine(".............");
                Console.WriteLine(klammerfaktor + "(x+" + bfkt / 2 + ")²" + "(" + -bfkt / 2 * bfkt / 2 + "))+" + c5);
                Console.WriteLine(".............");
                Console.Write(klammerfaktor + "(x+" + bfkt / 2 + ")²");
                if ((klammerfaktor * -bfkt / 2 * bfkt / 2 + c5) < 0)
                {
                    Console.WriteLine((klammerfaktor * -bfkt / 2 * bfkt / 2 + c5));
                }
                else if ((klammerfaktor * -bfkt / 2 * bfkt / 2 + c5) > 0)
                {
                    Console.WriteLine("+" + (klammerfaktor * -bfkt / 2 * bfkt / 2 + c5));
                }
                else if ((klammerfaktor * -bfkt / 2 * bfkt / 2 + c5) == 0)
                {
                }
                Console.WriteLine("----------------------------");
                */
                L1.Content = (klammerfaktor + "(x+" + bfkt / 2 + ")²" + (klammerfaktor * -bfkt / 2 * bfkt / 2 + c));

                {
                    while (iz < 4)
                    {

                        //Parabel
                        iz = iz + 0.001;
                        if (klammerfaktor > 0)
                        {
                            drawPoint(499- (double)(bfkt / 2)*40 - iz * 40, (223 - (klammerfaktor * -bfkt / 2 * bfkt / 2 + c) * 40) - (iz * iz * 40*klammerfaktor));
                            drawPoint(499- (double)(bfkt / 2)*40 + iz * 40, (223 - (klammerfaktor * -bfkt / 2 * bfkt / 2 + c) * 40) - (iz * iz * 40*klammerfaktor));
                        }
                        
                        
                        else if (klammerfaktor < 0)
                        {
                            
                            drawPoint(499 - (double)(bfkt / 2) * 40 - iz * 40, (223 - (klammerfaktor * -bfkt / 2 * bfkt / 2 + c) * 40) + (-iz * iz * 40 * klammerfaktor));
                            drawPoint(499 - (double)(bfkt / 2) * 40 + iz * 40, (223 - (klammerfaktor * -bfkt / 2 * bfkt / 2 + c) * 40) + (-iz * iz * 40 * klammerfaktor));

                        }
                    }
                    iz = 0;
                }
            }
            catch { }
        }
        private void drawPoint(double topx, double topy)
        {
            System.Windows.Shapes.Rectangle myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = System.Windows.Media.Brushes.Transparent;
            myRect.Fill = Brushes.Red;
            Canvas.SetLeft(myRect, topx);
            Canvas.SetTop(myRect, topy);
            myRect.Height = 2;
            myRect.Width = 2;
            paint.Children.Add(myRect);
        }
        private void drawGrid(int topx, int topy)
        {
            System.Windows.Shapes.Rectangle myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = System.Windows.Media.Brushes.Gray;
            Canvas.SetLeft(myRect, topx);
            Canvas.SetTop(myRect, topy);
            myRect.Height = 21;
            myRect.Width = 21;
            paint.Children.Add(myRect);
        }
        private void InitAxis()
        {
            drawLine(500, 4, 400, 0, 2, Brushes.Black);
            drawLine(200, 224, 0, 14.5 * 40, 2, Brushes.Black);
            drawLine(500, 4, 20, -7, 2, Brushes.Black);
            drawLine(500, 4, 20, 7, 2, Brushes.Black);
            drawLine(779, 225, -7, -20, 2, Brushes.Black);
            drawLine(779, 225, 7, -20, 2, Brushes.Black);

        }
        private void DrawGraph()
        {
            drawLine(500, 225 - (t * 40), -1000 * m, 1000, 1, Brushes.Red);
            drawLine(500, 225 - (t * 40), 40 * unitstobarrierleft * m, -unitstobarrierleft * 40, 1, Brushes.Red);
        }
        private void InitGrid()
        {
            int i = 0;
            while (i < 20)
            {
                drawGrid(500 + gridx, gridy);
                gridx = gridx + 20;
                if (count == 13)
                {
                    gridx = -1;
                    gridy = gridy + 20;
                    count = 0;
                    i++;
                }
                else
                {
                    count++;
                }
            }
            gridx = 1;
            gridy = 4;
            count = 0;
            i = 0;
            while (i < 20)
            {
                drawGrid(500 - gridx, gridy);
                gridx = gridx + 20;
                if (count == 15)
                {
                    gridx = 1;
                    gridy = gridy + 20;
                    count = 0;
                    i++;
                }
                else
                {
                    count++;
                }
            }

        }

    }
}
