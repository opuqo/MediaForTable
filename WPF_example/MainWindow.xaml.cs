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
using System.Windows.Media.Animation;

namespace WPF_example
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIElement el;
        public int number = 0;
        public MediaElement mel;
       // Canvas MyCanvas = new Canvas();
        public List<FileInfo> di;
        String dir;
        private Point _startPoint;
        private double _originalLeft;
        private double _originalTop;
        private bool _isDown;
        private bool _isDragging;
        private UIElement _originalElement;
        private SimpleCircleAdorner _overlayElement;
        public MainWindow()
        {
            InitializeComponent();
            //AddHandler(System.Windows.Controls.StackPanel.MouseLeftButtonDownEvent, new RoutedEventHandler(delegate {
            //    MessageBox.Show("eeeee");}));
            
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
        void stackpanel2MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            el = e.Source as UIElement;
            //ip.Source = el.;
            if (el.Uid != "")
            {
                Uri uri = new Uri(@dir + "\\" + el.Uid);
                BitmapImage bitmap = new BitmapImage(uri);
                var img = new Image();
                img.Source = bitmap;
                // img.Margin = new Thickness(5, 5, 5, 0);
                //img.Height = 70;
                img.Visibility = System.Windows.Visibility.Visible;
                veiw.Children.Clear();
                //veiw.Height = img.Height;
                //veiw.Width = img.Width;
                veiw.Margin = new Thickness(216, 16, 0, 0);
                veiw.MaxWidth = 300;
                veiw.MinWidth = 300; 
                veiw.MinHeight = 700; //костыль какойто
                veiw.MaxHeight = 700;
                veiw.Children.Add(img);
            }
            grid1.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(MyCanvas_PreviewMouseLeftButtonDown);
            grid1.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(MyCanvas_PreviewMouseMove);
            grid1.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MyCanvas_PreviewMouseLeftButtonUp);


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
            
             if (result.ToString().Equals("OK"))
             {
                 try
                 {
                     dir = openFileDialog1.SelectedPath;
                     stackpanel2.Children.Clear();
                     di = new List<FileInfo>(new DirectoryInfo(dir).GetFiles("*.avi", SearchOption.AllDirectories));
                     di.AddRange(new DirectoryInfo(dir).GetFiles("*.flv", SearchOption.AllDirectories));
                     di.AddRange(new DirectoryInfo(dir).GetFiles("*.jpg", SearchOption.AllDirectories));
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
                                 Uri uri = new Uri(@"C:/VS/MediaForTable/video.png");
                                 BitmapImage bitmap = new BitmapImage(uri);
                                 var img = new Image();
                                 
                                 img.Uid = i.ToString();
                                 img.Source = bitmap;
                                 img.Name = "img1" + number.ToString();
                                 img.Margin = new Thickness(5, 5, 5, 0);
                                 img.Height = 70;
                                 img.Visibility = System.Windows.Visibility.Visible;
                                 div.Children.Add(img);
                             }
                             else
                             {
                                 Uri uri = new Uri(@dir+"\\" + i.ToString());
                                 BitmapImage bitmap = new BitmapImage(uri);
                                 var img = new Image();
                                 img.Source = bitmap;
                                 img.Uid = i.ToString();
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
          //тест
        void MyCanvas_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isDown)
            {
                DragFinished(false);
                e.Handled = true;
            }
        }

        private void DragFinished(bool cancelled)
        {
            System.Windows.Input.Mouse.Capture(null);
            if (_isDragging)
            {
                AdornerLayer.GetAdornerLayer(_overlayElement.AdornedElement).Remove(_overlayElement);

                if (cancelled == false)
                {
                    veiw.Margin = new Thickness((_originalLeft + _overlayElement.LeftOffset), (_originalTop + _overlayElement.TopOffset), 0, 0);
                    //veiw.Margin.Top = _originalTop + _overlayElement.TopOffset;
                    //veiw.SetLeft(_originalElement, _originalLeft + _overlayElement.LeftOffset);
                }
                _overlayElement = null;

            }
            _isDragging = false;
            _isDown = false;
        }

        void MyCanvas_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) && ((Math.Abs(e.GetPosition(grid1).X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(grid1).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                {
                    DragStarted();
                }
                if (_isDragging)
                {
                    DragMoved();
                }
            }
        }

        private void DragStarted()
        {
            _isDragging = true;
            _originalLeft = veiw.Margin.Left; //   Canvas.GetLeft(_originalElement);
            _originalTop = veiw.Margin.Top;//Canvas.GetTop(_originalElement);

            _overlayElement = new SimpleCircleAdorner(_originalElement);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(_originalElement);
            layer.Add(_overlayElement);

        }

        private void DragMoved()
        {
            Point CurrentPosition = System.Windows.Input.Mouse.GetPosition(grid1);

            _overlayElement.LeftOffset = CurrentPosition.X - _startPoint.X;
            _overlayElement.TopOffset = CurrentPosition.Y - _startPoint.Y;

        }

        void MyCanvas_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source == grid1)
            {
            }
            else
            {
                _isDown = true;
                _startPoint = e.GetPosition(grid1);
                _originalElement = e.Source as UIElement;
                grid1.CaptureMouse();
                e.Handled = true;
            }
        }

        

        //Canvas MyCanvas ;

    }

    // Adorners должен быть подклассом абстрактного базового класса Adorner.
    public class SimpleCircleAdorner : Adorner
    {
        // Обеспечить вызов конструктора базового класса.
        public SimpleCircleAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            VisualBrush _brush = new VisualBrush(adornedElement);

            _child = new Rectangle();
            _child.Width = adornedElement.RenderSize.Width;
            _child.Height = adornedElement.RenderSize.Height;
           

            DoubleAnimation animation = new DoubleAnimation(0.3, 1, new Duration(TimeSpan.FromSeconds(1)));
            animation.AutoReverse = true;
            animation.RepeatBehavior =  System.Windows.Media.Animation.RepeatBehavior.Forever;
            _brush.BeginAnimation(System.Windows.Media.Brush.OpacityProperty, animation);

            _child.Fill = _brush;
        }

        // Общий подход к реализации визуального поведения декоративного элемента состоит в переопределении метода OnRender,
        // который вызывается подсистемой макета как части процесса построения изображения.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Получить прямоугольник, представляющий желаемый размер визуализированного элемента
            // после построения изображения.  Будет использоваться для отрисовки углов 
            // настроенного элемента.
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            // Несколько произвольных графических реализаций.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;
            
            // Просто нарисовать круг в каждом углу.
            drawingContext.DrawRectangle(renderBrush, renderPen, adornedElementRect);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _child.Measure(constraint);
            return _child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _child;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        public double LeftOffset
        {
            get
            {
                return _leftOffset;
            }
            set
            {
                _leftOffset = value;
                UpdatePosition();
            }
        }

        public double TopOffset
        {
            get
            {
                return _topOffset;
            }
            set
            {
                _topOffset = value;
                UpdatePosition();

            }
        }

        private void UpdatePosition()
        {
            AdornerLayer adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
            {
                adornerLayer.Update(AdornedElement);
            }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(_leftOffset,_topOffset));
            return result;
        }

        private Rectangle _child = null;
        private double _leftOffset=0;
        private double _topOffset = 0;
    }
}
        







