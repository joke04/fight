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
using dragon;

namespace четыре
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> Stats = new List<string>();
        Dracon Dragon = new Dracon();
        SeaDragon seaDragon = new SeaDragon();
        FeatheredSerpent featheredSerpent = new FeatheredSerpent();
        public MainWindow()
        {
            InitializeComponent();
            fightclub.IsEnabled = false;
            fightclub.Opacity = 0;
        }

        private void maxa4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dragon.MaxHP = Dragon.HPnow = Convert.ToInt32(hp1.Text);
                seaDragon.MaxHP = seaDragon.HPnow = Convert.ToInt32(hp2.Text);
                featheredSerpent.MaxHP = featheredSerpent.HPnow = Convert.ToInt32(hp3.Text);

                Dragon.MaxDAMAGE = Convert.ToInt32(d1.Text);
                seaDragon.MaxDAMAGE = Convert.ToInt32(d2.Text);
                featheredSerpent.MaxDAMAGE = Convert.ToInt32(d3.Text);

                seaDragon.XY = Convert.ToInt32(fights2.Text);

                featheredSerpent.Visible = false;

                initil.IsEnabled = false;
                initil.Opacity = 0;
                initil.Margin = new Thickness(0, 0, 0, 0);

                pr1.Maximum = pr1.Value = Dragon.MaxDAMAGE;
                pr2.Maximum = pr2.Value = seaDragon.MaxDAMAGE;
                pr3.Maximum = pr3.Value = featheredSerpent.MaxDAMAGE;
                bosshp.Maximum = bosshp.Value = pr1.Value + pr2.Value + pr3.Value;

                nowhp1.Text = pr1.Value.ToString();
                nowhp2.Text = pr2.Value.ToString();
                nowhp3.Text = pr3.Value.ToString();
                nowhpboss.Text = bosshp.Value.ToString();

                fightclub.IsEnabled = true;
                fightclub.Opacity = 100;

                if (Convert.ToInt32(hp1.Text) <= 0)
                {
                    throw new Exception("Некорректные данные");
                }
                if (Convert.ToInt32(d1.Text) <= 0)
                {
                    throw new Exception("Некорректные данные");
                }

                if (Convert.ToInt32(hp3.Text) <= 0)
                {
                    throw new Exception("Некорректные данные");
                }
                if (Convert.ToInt32(d3.Text) <= 0)
                {
                    throw new Exception("Некорректные данные");
                }
            }

            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void hit1_Click(object sender, RoutedEventArgs e)
        {
            int x = Dragon.DealDamage();
            bosshp.Value -= x;
            switch (combobox.SelectedIndex)
            {
                case 0:
                    Stats.Add("Белый дракон нанёс " + x);
                    break;
                case 1:
                    Stats.Add("Пятнистый дракон нанёс " + x);
                    break;
                case 2:
                    Stats.Add("Желтый дракон нанёс " + x);
                    break;
                case 3:
                    Stats.Add("Зеленый дракон нанёс " + x);
                    break;
                case 4:
                    Stats.Add("Голубой дракон нанёс " + x);
                    break;
            }
            update();
        }

        private void hit2_Click(object sender, RoutedEventArgs e)
        {
            int x = seaDragon.DealDamage();
            bosshp.Value -= x;
            //Stats.Add("Морской дракон нанёс " + x);
            switch (combobox1.SelectedIndex)
            {
                case 0:
                    Stats.Add("Коричневый морской дракон нанес " + x);
                    break;
                case 1:
                    Stats.Add("Сиреневый морской дракон нанёс " + x);
                    break;
                case 2:
                    Stats.Add("Малиновый морской дракон нанес " + x);
                    break;
                case 3:
                    Stats.Add("Клетчатый морской дракон нанес " + x);
                    break;
                case 4:
                    Stats.Add("Оранжевый морской дракон нанес " + x);
                    break;
            }
            update();
        }

        private void hit3_Click(object sender, RoutedEventArgs e)
        {
            int x = featheredSerpent.DealDamage();
            bosshp.Value -= x;
            //Stats.Add("Пернатый змей нанёс " + x);
            switch (combobox2.SelectedIndex)
            {
                case 0:
                    Stats.Add("Абрикосовый пернатый змей нанес " + x);
                    break;
                case 1:
                    Stats.Add("Алый пернатый змей нанёс " + x);
                    break;
                case 2:
                    Stats.Add("Болотный пернатый змей нанес " + x);
                    break;
                case 3:
                    Stats.Add("Изумрудный пернатый змей нанес " + x);
                    break;
                case 4:
                    Stats.Add("Кремовый пернатый змей нанес " + x);
                    break;
            }
            update();
        }

        private void heal1_Click(object sender, RoutedEventArgs e)
        {
            Dragon.Heal();
        }

        private void heal2_Click(object sender, RoutedEventArgs e)
        {
            seaDragon.Heal();
        }

        private void heal3_Click(object sender, RoutedEventArgs e)
        {
            featheredSerpent.Heal();
        }

        private void becomehidden_Click(object sender, RoutedEventArgs e)
        {
            featheredSerpent.Visible = !featheredSerpent.Visible;
        }
        private void update()
        {
            nowhp1.Text = pr1.Value.ToString();
            nowhp2.Text = pr2.Value.ToString();
            nowhp3.Text = pr3.Value.ToString();
            nowhpboss.Text = bosshp.Value.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Statics.Text = "";
            foreach (string r in Stats)
            {
                Statics.Text += r;
                Statics.Text += '\n';
            }
        }

        private void btn123_Click(object sender, RoutedEventArgs e)
        {
            Dragon.Color = combobox.Text.ToString();
            switch (combobox.SelectedIndex)
            {
                case 0:
                    LRes.Content = "Белый";
                    break;
                case 1:
                    LRes.Content = "Пятнистый";
                    break;
                case 2:
                    LRes.Content = "Желтый";
                    break;
                case 3:
                    LRes.Content = "Зеленый";
                    break;
                case 4:
                    LRes.Content = "Голубой";
                    break;
            }
        }

        private void btn234_Click(object sender, RoutedEventArgs e)
        {
            Dragon.Color = combobox1.Text.ToString();
            switch (combobox.SelectedIndex)
            {
                case 0:
                    LRes1.Content = "Коричневый";
                    break;
                case 1:
                    LRes1.Content = "Сиреневый";
                    break;
                case 2:
                    LRes1.Content = "Малиновый";
                    break;
                case 3:
                    LRes1.Content = "Клетчатый";
                    break;
                case 4:
                    LRes1.Content = "Оранжевый";
                    break;
            }
        }
        private void btn345_Click(object sender, RoutedEventArgs e)
        {
            Dragon.Color = combobox2.Text.ToString();
            switch (combobox.SelectedIndex)
            {
                case 0:
                    LRes2.Content = "Абрикосовый";
                    break;
                case 1:
                    LRes2.Content = "Алый";
                    break;
                case 2:
                    LRes2.Content = "Болотный";
                    break;
                case 3:
                    LRes2.Content = "Изумрудный";
                    break;
                case 4:
                    LRes2.Content = "Кремовый";
                    break;
            }
        }

        private void btn_t_Click(object sender, RoutedEventArgs e)
        {
            switch (cb101.SelectedIndex)
            {
                case 0:
                    Grid.Background = Brushes.Pink;
                    break;
                case 1:
                    Grid.Background = Brushes.LightBlue;
                    break;
                case 2:
                    Grid.Background = Brushes.LightYellow;
                    break;
                case 3:
                    Grid.Background = Brushes.LightGreen;
                    break;
            }
        }
    }
}