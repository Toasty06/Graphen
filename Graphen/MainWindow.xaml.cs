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
        int ti=0;
        public MainWindow()
        {
            DispatcherTimer D = new DispatcherTimer();
            D.Interval = TimeSpan.FromMilliseconds(25);
            D.Tick += D_Tick;
            D.Start();
            
            
            InitializeComponent();
        }

        private void D_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter) || btn.IsPressed==true)
            {

                if (mf.Text != "" && tf.Text != "")
                {
                    m = Int32.Parse(mf.Text);
                    t = Int32.Parse(tf.Text);
                    drawLine(500, 225-(t*20), 500 + 1000, 225-t*20 - m*1000);
                    drawLine(500, 225 - (t * 20), 500 - 1000, 225 - t * 20 + m * 1000);
                }
                else { }
            }
            ti++;
            L2.Content = m;
            
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            Line objLine = new Line();

            objLine.Stroke = System.Windows.Media.Brushes.Black;
            objLine.Fill = System.Windows.Media.Brushes.Black;

            objLine.X1 = x1;
            objLine.Y1 = y1;

            objLine.X2 = x2;
            objLine.Y2 = y2;

            paint.Children.Add(objLine);
            
        }
    }

}
