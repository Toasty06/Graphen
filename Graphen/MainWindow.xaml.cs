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
        public string WindowTitle
        {
            get
            {
                String version = "0.0.5.1";
                return "Graphs v" + version;
            }
        }
        double m;
        double t;
        double unitstobarrierleft = 7.5;
        double a=0;
        int gridx = -1;
        int gridy = 4;
        int count = 0;
        bool drawn = false;
        double olda;
        double oldt;
        double oldm;
        double iz = 0;
        int  up;
        bool delete;
        bool first = true;
        public MainWindow()
        {



            DispatcherTimer D = new DispatcherTimer();
            D.Interval = TimeSpan.FromMilliseconds(25);
            D.Tick += D_Tick;
            D.Start();

            InitializeComponent();
            Show();
            
        }

        private void Init()
        {
            CTitle.Visibility = Visibility.Visible;
            af.Visibility = Visibility.Visible;
            mf.Visibility = Visibility.Visible;
            tf.Visibility = Visibility.Visible;
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            btn.Visibility = Visibility.Visible;
            x1.Visibility = Visibility.Visible;
            pl3.Visibility = Visibility.Visible;
            pl2.Visibility = Visibility.Visible;
            rec.Visibility = Visibility.Visible;
            x.Visibility = Visibility.Visible;
            y.Visibility = Visibility.Visible;
            InitGrid();
            InitAxis();


        }

        private void D_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.S)&&first==true) { Init(); first = false; }

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
                            if (af.Text != "" && af.Text!="0")
                            {
                                if (a > 0 )
                                {
                                    up = 1;
                                }
                                else { up = -1;
                                }

                                drawParabel(500,t,up,a);
                                label();
                                drawn = true;
                            }
                            else
                            {
                                DrawGraph();
                                label();
                                drawn = true;
                            }
                        }
                        else if (drawn == true && (oldm != m || oldt != t || olda!=a))
                        {
                            delete = true;
                            while (paint.Children.Count - 1 > 672&&delete==true)
                            {
                                paint.Children.RemoveAt(paint.Children.Count - 1);
                                paint.Children.RemoveAt(paint.Children.Count - 1);
                            }
                            delete = false;
                            
                            if (af.Text != "" && af.Text != "0")
                            {
                                if (a > 0)
                                {
                                    up = 1;
                                }
                                else
                                {
                                    up = -1;
                                }

                                drawParabel(500, t, up, a);
                                label();


                                drawn = true;
                            }
                            else
                            {
                                DrawGraph();
                                label();
                                drawn = true;
                            }
                        } }
                    catch { }

                    if (mf.Text == "TOAST" && tf.Text == "BROT")
                    {
                        
                        
                    }
                }
            }
         
        }
        private void label()
        {
            olda = a;
            oldm = m;
            oldt = t;
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
        private void drawParabel(double x, double y, int up , double stretch)
        
        
        {
            while (iz < 4)
            {
        
                //Parabel
                iz = iz + 0.001;
                drawPoint(499 - iz * 40, 223-t*40 - up*iz * iz * 40*stretch);
                drawPoint(499 + iz * 40, 223-t*40 - up*iz * iz * 40*stretch);
            }
            iz = 0;
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
            drawLine(200, 224, 0, 14.5 *40, 2, Brushes.Black);
            drawLine(500, 4, 20, -7, 2, Brushes.Black);
            drawLine(500, 4, 20, 7, 2, Brushes.Black);
            drawLine(779, 225, -7, -20, 2, Brushes.Black);
            drawLine(779, 225, 7, -20, 2, Brushes.Black);

        }
        private void DrawGraph()
        {
            drawLine(500, 225 - (t * 40), -1000, 1000, 1, Brushes.Red);
            drawLine(500, 225 - (t * 40), 40 * unitstobarrierleft, -unitstobarrierleft * 40, 1, Brushes.Red);
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
