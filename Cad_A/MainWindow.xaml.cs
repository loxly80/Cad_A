using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Cad_A
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Point> points = new List<Point>();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void ActiveCanvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if(e.LeftButton == MouseButtonState.Pressed)
      {
        var location = e.GetPosition(ActiveCanvas);
        Point point = new Point(location.X, location.Y);
        points.Add(point);
        point.AddToCanvas(ActiveCanvas);
      }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      string json = JsonConvert.SerializeObject(points);
      File.WriteAllText("data.json", json);
    }

    private void Window_Activated(object sender, EventArgs e)
    {
      if (File.Exists("data.json"))
      {
        string json = File.ReadAllText("data.json");
        points = JsonConvert.DeserializeObject<List<Point>>(json) ?? new List<Point>();
        foreach(var point in points)
        {
          point.AddToCanvas(ActiveCanvas);
        }
      }      
    }
  }
}
