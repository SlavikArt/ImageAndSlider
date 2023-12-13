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
        private TransformGroup transformGroup;
        private ScaleTransform scaleTransform;
        private RotateTransform rotateTransform;
        private SkewTransform skewTransform;
        public MainWindow()
        {
            InitializeComponent();

            transformGroup = new TransformGroup();
            scaleTransform = new ScaleTransform();
            rotateTransform = new RotateTransform();
            skewTransform = new SkewTransform();

            image.RenderTransform = transformGroup;
            image.RenderTransformOrigin = new Point(0.5, 0.5);

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(skewTransform);

            sliderBlur.Minimum = 0;
            sliderBlur.Maximum = 50;
            sliderBlur.ValueChanged += (s, e) => { 
                image.Effect = new BlurEffect { Radius = e.NewValue }; 
            };

            sliderOpacity.Minimum = 0;
            sliderOpacity.Maximum = 1;
            sliderOpacity.Value = 1;
            sliderOpacity.ValueChanged += (s, e) => { 
                image.Opacity = e.NewValue; 
            };

            sliderRotate.Minimum = 0;
            sliderRotate.Maximum = 360;
            sliderRotate.Value = 0;
            sliderRotate.ValueChanged += (s, e) => { 
                rotateTransform.Angle = e.NewValue;
            };

            sliderScale.Minimum = 0.1;
            sliderScale.Maximum = 2;
            sliderScale.Value = 1;
            sliderScale.ValueChanged += (s, e) => {
                scaleTransform.ScaleX = e.NewValue;
                scaleTransform.ScaleY = e.NewValue;
            };

            sliderSkew.Minimum = -45;
            sliderSkew.Maximum = 45;
            sliderSkew.Value = 0;
            sliderSkew.ValueChanged += (s, e) => {
                skewTransform.AngleX = e.NewValue;
                skewTransform.AngleY = e.NewValue;
            };
        }
    }
}
