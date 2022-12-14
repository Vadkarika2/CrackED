using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CrackED
{
    /// <summary>
    /// Interaction logic for CaretLayer.xaml
    /// </summary>
    public partial class CaretLayer : UserControl
    {
        internal Editor Owner;

        public CaretLayer(Editor owner)
        {
            InitializeComponent();

            Owner = owner;
        }

        public void Repaint()
        {
            RepaintRequested = true;
            InvalidateVisual();
        }

        private bool RepaintRequested = false;
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (RepaintRequested)
            {
                RepaintRequested = false;

                Owner.TransformDrawingContext(ref drawingContext);

                if (Owner.Caret.IsVisible)
                {
                    Owner.Caret.DrawCaret(ref drawingContext);
                }
            }
        }
    }
}
