using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageAndSlider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] imagePaths;
        private int currentIndex = 0;

        private TransformGroup transformGroup;
        private ScaleTransform scaleTransform;
        private RotateTransform rotateTransform;
        private SkewTransform skewTransform;
        public MainWindow()
        {
            InitializeComponent();

            imagePaths = new string[]
            {
                "https://wallpapers.com/images/high/cat-pictures-9myur9v0ca86msmx.webp",
                "https://wallpapers.com/images/high/beautiful-cats-1600-x-1000-picture-hrwwwvyup3q0vmwg.webp",
                "https://wallpapers.com/images/high/beautiful-cats-1080-x-1920-picture-kebu9tec6x6sknza.webp",
                "https://wallpapers.com/images/high/beautiful-cats-2200-x-1467-picture-913bua4vrxbkagve.webp",
                "https://wallpapers.com/images/high/beautiful-cats-1433-x-924-picture-x5cgjadw65p7t6h1.webp",
                "https://wallpapers.com/images/high/beautiful-cats-2121-x-1414-picture-xfbykidls2i9vnw0.webp",
                "https://wallpapers.com/images/high/beautiful-cats-2545-x-1692-picture-yv0yggf2gr811xd5.webp",
                "https://wallpapers.com/images/high/beautiful-cats-1800-x-1200-picture-o1fx1eprdzh5j74t.webp"
            };
            LoadImage(currentIndex);

            transformGroup = new TransformGroup();
            scaleTransform = new ScaleTransform();
            rotateTransform = new RotateTransform();
            skewTransform = new SkewTransform();

            image.RenderTransform = transformGroup;
            image.RenderTransformOrigin = new Point(0.5, 0.5);

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(skewTransform);

            InitializeSliders();
        }

        private void LoadImage(int index)
        {
            if (index >= 0 && index < imagePaths.Length)
                image.Source = new BitmapImage(new Uri(imagePaths[index]));
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadImage(currentIndex);
            }
            else if (currentIndex == 0)
            {
                currentIndex = imagePaths.Length - 1;
                LoadImage(currentIndex);
            }
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentIndex < imagePaths.Length - 1)
            {
                currentIndex++;
                LoadImage(currentIndex);
            }
            else if (currentIndex == imagePaths.Length - 1)
            {
                currentIndex = 0;
                LoadImage(currentIndex);
            }
        }

        private void InitializeSliders()
        {
            sliderBlur.Minimum = 0;
            sliderBlur.Maximum = 50;
            sliderBlur.ValueChanged += (s, e) =>
            {
                image.Effect = new BlurEffect { Radius = e.NewValue };
            };

            sliderOpacity.Minimum = 0;
            sliderOpacity.Maximum = 1;
            sliderOpacity.Value = 1;
            sliderOpacity.ValueChanged += (s, e) =>
            {
                image.Opacity = e.NewValue;
            };

            sliderRotate.Minimum = 0;
            sliderRotate.Maximum = 360;
            sliderRotate.Value = 0;
            sliderRotate.ValueChanged += (s, e) =>
            {
                rotateTransform.Angle = e.NewValue;
            };

            sliderScale.Minimum = 0.1;
            sliderScale.Maximum = 2;
            sliderScale.Value = 1;
            sliderScale.ValueChanged += (s, e) =>
            {
                scaleTransform.ScaleX = e.NewValue;
                scaleTransform.ScaleY = e.NewValue;
            };

            sliderSkew.Minimum = -45;
            sliderSkew.Maximum = 45;
            sliderSkew.Value = 0;
            sliderSkew.ValueChanged += (s, e) =>
            {
                skewTransform.AngleX = e.NewValue;
                skewTransform.AngleY = e.NewValue;
            };
        }
    }
}
