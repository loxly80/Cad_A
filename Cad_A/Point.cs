using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Cad_A
{
  public class Point
  {
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
      X = x;
      Y = y;
    }

    public void AddToCanvas(Canvas canvas)
    {
      Ellipse ellipse = new Ellipse();
      ellipse.Fill = Brushes.Black;
      ellipse.Width = 8;
      ellipse.Height = 8;
      Canvas.SetLeft(ellipse, X - 4);
      Canvas.SetTop(ellipse, Y - 4);
      canvas.Children.Add(ellipse);
    }
  }
}
