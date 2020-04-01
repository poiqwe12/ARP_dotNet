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
using ManagementApp.Model;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PointListView.xaml
    /// </summary>
    public partial class PointListView : Page
    {
        List<Model.Point> points = new List<Model.Point>();


        public PointListView()
        {
            InitializeComponent();

            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());
            points.Add(new Model.Point());


            ListView_PointsList.ItemsSource = points;

        }
    }
}
