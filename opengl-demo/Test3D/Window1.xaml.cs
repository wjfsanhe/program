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
using System.Windows.Media.Media3D;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Test3D
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int _positionState = 0x0000;
        private DispatcherTimer _handleKeyTimer = null;
        private Point _mousePosition;

        public double Sensitivity
        {
            get { return (double)GetValue(SensitivityProperty); }
            set { SetValue(SensitivityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sensitivity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensitivityProperty =
            DependencyProperty.Register("Sensitivity", typeof(double), typeof(Window1), new UIPropertyMetadata(3.0));

        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            this.Closed += new EventHandler(Window_Closed);
        }

        // 开启另外一个线程来处理键盘响应
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;

            Win32Native.ShowCursor(false);
            this._mousePosition = new Point(this.ActualWidth / 2, this.ActualHeight / 2);
            Win32Native.SetCursorPos((int)this._mousePosition.X, (int)this._mousePosition.Y);

            this._handleKeyTimer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(1),
                DispatcherPriority.Input,
                new EventHandler(HandleKeyInput),
                this.Dispatcher);
            this._handleKeyTimer.Start();
        }

        // 在窗口关闭的时候要关掉Timer
        private void Window_Closed(object sender, EventArgs e)
        {
            if (this._handleKeyTimer != null)
            {
                this._handleKeyTimer.Stop();
            }

            Win32Native.ShowCursor(true);
        }

        // 不直接在KeyDown中处理，只是置标志位，可以实现同时按下几个键的响应
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    this._positionState |= 0x0010;
                    break;
                case Key.D:
                    this._positionState |= 0x0001;
                    break;
                case Key.W:
                    this._positionState |= 0x1000;
                    break;
                case Key.S:
                    this._positionState |= 0x0100;
                    break;
                //case Key.F4:
                //    if (this.WindowState == WindowState.Maximized && this.WindowStyle == WindowStyle.None)
                //    {
                //        this.WindowStyle = WindowStyle.SingleBorderWindow;
                //        this.WindowState = WindowState.Normal;
                //    }
                //    else if (this.WindowState == WindowState.Normal && this.WindowStyle == WindowStyle.SingleBorderWindow)
                //    {
                //        this.WindowStyle = WindowStyle.None;
                //        this.WindowState = WindowState.Maximized;
                //    }
                //    break;
                default:
                    break;
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    this._positionState &= 0x1101;
                    break;
                case Key.D:
                    this._positionState &= 0x1110;
                    break;
                case Key.W:
                    this._positionState &= 0x0111;
                    break;
                case Key.S:
                    this._positionState &= 0x1011;
                    break;
                default:
                    break;
            }
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point currentMousePosition = e.GetPosition(this);

            double deltaX = currentMousePosition.X - _mousePosition.X;
            double deltaY = currentMousePosition.Y - _mousePosition.Y;

            this.UpdateDirection(deltaX * this.Sensitivity / 5, deltaY * this.Sensitivity / 5);

            Win32Native.SetCursorPos((int)this.ActualWidth / 2, (int)this.ActualHeight / 2);
        }

        // 通过标志位来处理按键，保证可以同时按下几个键
        private void HandleKeyInput(object sender, EventArgs e)
        {
            double deltaX = 0.0, deltaZ = 0.0;
            // 按下上
            if ((this._positionState & 0x1000) != 0)
            {
                deltaZ = -0.05;
            }
            // 按下下
            if ((this._positionState & 0x0100) != 0)
            {
                deltaZ = 0.05;
            }
            // 按下左
            if ((this._positionState & 0x0010) != 0)
            {
                deltaX = -0.05;
            }
            // 按下右
            if ((this._positionState & 0x0001) != 0)
            {
                deltaX = 0.05;
            }
            this.UpdatePosition(deltaX, deltaZ);
        }

        // 更新位置
        private void UpdatePosition(double deltaX, double deltaZ)
        {
            //Point3D currentPos = this._camera.Position;
            //this._camera.Position = new Point3D(currentPos.X + deltaX, currentPos.Y, currentPos.Z + deltaZ);
            this._translate.OffsetX += deltaX;
            this._translate.OffsetZ += deltaZ;
        }

        // 更新方向
        private void UpdateDirection(double deltaX, double deltaY)
        {
            this._rotateX.Angle -= deltaY;
            this._rotateY.Angle -= deltaX;
        }
    }
}
