﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "35D00A035E6D7ED7B7E85E386F474761"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Test3D {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Window1.xaml"
        internal System.Windows.Media.Media3D.PerspectiveCamera _camera;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Window1.xaml"
        internal System.Windows.Media.Media3D.AxisAngleRotation3D _rotateX;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Window1.xaml"
        internal System.Windows.Media.Media3D.AxisAngleRotation3D _rotateY;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Window1.xaml"
        internal System.Windows.Media.Media3D.TranslateTransform3D _translate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Test3D;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\Window1.xaml"
            ((Test3D.Window1)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\Window1.xaml"
            ((Test3D.Window1)(target)).PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.Window_PreviewKeyUp);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Window1.xaml"
            ((Test3D.Window1)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Window_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this._camera = ((System.Windows.Media.Media3D.PerspectiveCamera)(target));
            return;
            case 3:
            this._rotateX = ((System.Windows.Media.Media3D.AxisAngleRotation3D)(target));
            return;
            case 4:
            this._rotateY = ((System.Windows.Media.Media3D.AxisAngleRotation3D)(target));
            return;
            case 5:
            this._translate = ((System.Windows.Media.Media3D.TranslateTransform3D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
