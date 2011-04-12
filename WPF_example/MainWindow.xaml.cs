using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;

namespace WPF_example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int number = 0;
        public MediaElement mel;
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(System.Windows.Controls.StackPanel.MouseLeftButtonDownEvent, new RoutedEventHandler(delegate {
                MessageBox.Show("eeeee");}));
            
        }
        public void _myMethod(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("123");
        }
        public void listView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void mel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mel.LoadedBehavior == MediaState.Pause)
            {
                mel.LoadedBehavior = MediaState.Play;
            }
            else
            {
                mel.LoadedBehavior = MediaState.Pause;
            }

        }

        private void mediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mel.LoadedBehavior == MediaState.Pause)
            {
                mel.LoadedBehavior = MediaState.Play;
            }
            else
            {
                mel.LoadedBehavior = MediaState.Pause;
            }

        }

        private void mediaElement1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void grid1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void previous_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void UpD_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (scroll2.Height == 0)
            {
               
            }
            else
            {
                scroll2.Height = 0;
            }
        }

        private void but2_Click(object sender, RoutedEventArgs e)
        {
            if (wrap2.Height == 20)
            {
                wrap2.Height = 138;
            }
            else
            {
                wrap2.Height = 20;
            }
        }
        public void spLineUp(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)stackpanel2).LineUp();
        }
        public void spLineDown(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)stackpanel2).LineDown();
        }
        void but3_Click(object sender, RoutedEventArgs e)
        {

            ((IScrollInfo)stackpanel2).PageRight();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            ((IScrollInfo)stackpanel2).PageLeft();
        }
        void stackpanel2_MouseMove(object sender, MouseEventArgs e)
        {

        }
         void stackpanel2_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
         
        }
         private void butOpen_Click(object sender, MouseButtonEventArgs e)
         {
             var openFileDialog1 = new OpenFileDialog { };
             var result = openFileDialog1.ShowDialog();
             var filename = openFileDialog1.FileName;


         }
         private void butOpen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
         {

         }

         private void butOpen_Click(object sender, RoutedEventArgs e)
         {

         }

         public void butt_Click(object sender, RoutedEventArgs e)
         {
             var openFileDialog1 = new System.Windows.Forms.FolderBrowserDialog();
             var result = openFileDialog1.ShowDialog();
             var dir = openFileDialog1.SelectedPath;
             if (result.ToString() == "OK")
             {
                 try
                 {
                     stackpanel2.Children.Clear();
                     List<FileInfo> di = new List<FileInfo>(new DirectoryInfo(dir).GetFiles("*.avi", SearchOption.AllDirectories));
                     di.AddRange(new DirectoryInfo(dir).GetFiles("*.flv", SearchOption.AllDirectories));
                     di.AddRange(new DirectoryInfo(dir).GetFiles("*.jpg", SearchOption.TopDirectoryOnly));
                     number = 0;
                     foreach (var i in di)
                     {
                         if (i != null)
                         {
                             number += 1;
                             listView1.Items.Add(i.ToString());
                             var div = new StackPanel();
                             div.Name = "div1" + number.ToString();
                             div.Height = stackpanel2.Height - 10;
                             div.Orientation = Orientation.Vertical;
                             div.Visibility = System.Windows.Visibility.Visible;
                             div.Background = System.Windows.Media.Brushes.SlateGray;
                             div.Margin = new Thickness(5, 0, 5, 0);
                             div.MaxWidth = 120;
                             div.MinWidth = 120;
                             stackpanel2.Children.Add(div);
                             // превьюшка
                             if (i.ToString().Substring(i.ToString().Length - 4, 4) == ".avi" || i.ToString().Substring(i.ToString().Length - 4, 4) == ".flv")
                             {
                                 Uri uri = new Uri(@"G:/play.png");
                                 BitmapImage bitmap = new BitmapImage(uri);
                                 var img = new Image();
                                 var lab1 = "123";
                                 img.Tag = lab1;
                                 img.Source = bitmap;
                                 img.Name = "img1" + number.ToString();
                                 img.Margin = new Thickness(5, 5, 5, 0);
                                 img.Height = 70;
                                 img.Visibility = System.Windows.Visibility.Visible;
                                 div.Children.Add(img);
                             }
                             else
                             {
                                 Uri uri = new Uri(@dir + i.ToString());
                                 BitmapImage bitmap = new BitmapImage(uri);
                                 var img = new Image();
                                 img.Source = bitmap;
                                 img.Name = "img1" + number.ToString();
                                 img.Margin = new Thickness(5, 5, 5, 0);
                                 img.Height = 70;
                                 img.Visibility = System.Windows.Visibility.Visible;
                                 div.Children.Add(img);
                             }


                             //надпись
                             var label1 = new Label();
                             label1.Name = "label1" + number.ToString();
                             if (i.ToString().Length > 20)
                             {
                                 label1.Content = i.ToString().Substring(0, 20);
                                 label1.Content += i.ToString().Substring(i.ToString().Length - 4, 4);
                             }
                             else
                             {
                                 label1.Content = i.ToString();
                             }
                             div.Children.Add(label1);
                             label1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                             label1.MinHeight = 10;

                         }
                     }
                 }
                 catch(Exception e1)
                 {
                     MessageBox.Show(e1.ToString());
                 }
             }
         }

        


       
    }
}
