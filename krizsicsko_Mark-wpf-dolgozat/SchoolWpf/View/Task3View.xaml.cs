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
using System.Collections.ObjectModel;
using Task3Database.Data;
using Task3Database.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SchoolWpf.View
{
    public partial class Task3View : UserControl
    {

        public ObservableCollection<People> People;
        public Context context;

        public Task3View()
        {
            InitializeComponent();
            People = new ObservableCollection<People>();
            context = new Context();
            Refresh();
            lbPeople.ItemsSource = People;
            spInput.DataContext = People;
        }

        private void Refresh()
        {
            People.Clear();

            if (context.People.Any())
                foreach (var item in context.People)
                    People.Add((People)item);
            else People.Add(new People());

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

            People user = lbPeople.SelectedItem as People;
            if (user == null) user = new People();
            user.Id = 0;
            context.People.Add(user);
            context.SaveChanges();
            Refresh();
            lbPeople.SelectedItem = user;
            lbPeople.UpdateLayout();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            People user = lbPeople.SelectedItem as People;
            if (user != null)
            {
                int index = lbPeople.SelectedIndex;

                context.People.Remove(user);
                context.SaveChanges();
                Refresh();

                lbPeople.SelectedIndex = index < lbPeople.Items.Count - 1 ? index : lbPeople.Items.Count - 1;
                lbPeople.UpdateLayout();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            People user = lbPeople.SelectedItem as People;
            if (user != null)
            {
                context.People.Update(user);
                context.SaveChanges();
                Refresh();
                lbPeople.SelectedItem = user;
                lbPeople.UpdateLayout();
            }
        }
    }
}
