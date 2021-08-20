using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Graphen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double m;
        double t;
        double unitstobarrierleft = 7.5;
        double unitstobarrierup=4.5;
        int gridx = -1;
        int gridy = 4;
        int count = 0;
        bool drawn = false;
        double oldt;
        double oldm;
        public MainWindow()
        {

            DispatcherTimer D = new DispatcherTimer();
            D.Interval = TimeSpan.FromMilliseconds(25);
            D.Tick += D_Tick;
            D.Start();

            InitializeComponent();
            InitGrid();
            InitAxis();

        }


        private void D_Tick(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.Enter) || btn.IsPressed == true)
            {

                if (mf.Text != "" && tf.Text != "")
                {
                    m = double.Parse(mf.Text);
                    t = double.Parse(tf.Text);
                    if (drawn == false)
                    {
                        DrawGraph();
                        oldm = m;
                        oldt = t;
                        drawn = true;
                    }
                    else if (drawn == true && (oldm!=m || oldt!=t))
                    {
                        try
                        {
                            paint.Children.RemoveAt(6464);
                            paint.Children.RemoveAt(6463);
                        }
                        catch { }
                        DrawGraph();
                        drawn = false;
                    }
                }


            }
            L2.Content = m;

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
                myLine.Name = "ThicBoi";
                paint.Children.Add(myLine);
            }

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
            drawLine(500, 0, 450, 0, 2, Brushes.Black);
            drawLine(200, 224, 0, 600, 2, Brushes.Black);

        }
        private void DrawGraph()
        {
            drawLine(500, 225 - (t * 40), -1000*m, 1000, 1, Brushes.Red);
            drawLine(500, 225 - (t * 40), 40 * unitstobarrierleft * m, -unitstobarrierleft * 40, 1, Brushes.Red);
        }

        private void InitGrid()
        {
            int i = 0;
            while (i < 22)
            {
                drawGrid(500 + gridx, gridy);
                gridx = gridx + 20;
                if (count == 15)
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
            while (i < 22)
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
