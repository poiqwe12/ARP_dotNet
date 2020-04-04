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

using ManagementApp.Controler;
using ManagementApp.DataBase;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ManagementViev.xaml
    /// </summary>
    public partial class ManagementView : Page
    {
        public ManagementView()
        {
            InitializeComponent();


            //W tej klasie należy określić który będzie widziany, a który nie na podstawie zaznaczonego elementu w menu
            
            //PoinListToRender
            //TaskListToRender


        }
    }
}
