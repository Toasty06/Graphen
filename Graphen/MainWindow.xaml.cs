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
using System.Drawing;
using System.Windows.Threading;

namespace Graphen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int m;
        int t;
        int unitstobarrier=15;
        int gridx=0;
        int gridy=3;
        int count=0;

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
            if (Keyboard.IsKeyDown(Key.Enter) || btn.IsPressed==true)
            {

                if (mf.Text != "" && tf.Text != "")
                {
                    m = Int32.Parse(mf.Text);
                    t = Int32.Parse(tf.Text);
                    drawLine(500, 225-(t*20), 500 + 1000, 225-t*20 - m*1000,1, Brushes.Red);
                    drawLine(500, 225 - (t * 20), 500-20*unitstobarrier, 225-(m*20*(-unitstobarrier)+t*20),1,Brushes.Red);
                }
                else { }
            }
            L2.Content = m;

        }

        private void drawLine(int x1, int y1, int x2, int y2,int st, System.Windows.Media.Brush cl)
        {
            Line objLine = new Line();


            objLine.Stroke = cl;
            objLine.Fill = cl;
            objLine.StrokeThickness = st;

            objLine.X1 = x1;
            objLine.Y1 = y1;

            objLine.X2 = x2;
            objLine.Y2 = y2;

            paint.Children.Add(objLine);

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
            drawLine(501, 0, 501, 450,2, Brushes.Black);
            drawLine(200, 225, 800, 225, 2, Brushes.Black);

        }

        private void InitGrid()
        {
            int i = 0;
            while (i < 200)
            {
                drawGrid(500 + gridx, gridy);
                gridx = gridx + 20;
                if (count == 15)
                {
                    gridx = 0;
                    gridy = gridy + 20;
                    count = 0;
                    i++;
                }
                else
                {
                    count++;
                }
            }
            gridx = 0;
            gridy = 3;
            count = 0;
            i = 0;
            while (i < 200)
            {
                drawGrid(500 - gridx, gridy);
                gridx = gridx + 20;
                if (count == 15)
                {
                    gridx = 0;
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
