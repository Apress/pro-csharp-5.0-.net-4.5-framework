using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace RenderingWithVisuals
{
    class CustomVisualFrameworkElement : FrameworkElement
    {
        // A collection of all the visuals we are building.
        VisualCollection theVisuals;

        #region Fill the VisualCollection
        public CustomVisualFrameworkElement()
        {
            // Fill the VisualCollection with a few DrawingVisual objects.
            theVisuals = new VisualCollection(this);
            theVisuals.Add(AddRect());
            theVisuals.Add(AddCircle());

            // Handle the MouseDown event.
            this.MouseDown += MyVisualHost_MouseDown;
        }

        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Create a rectangle and draw it in the DrawingContext.
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }

        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Create a rectangle and draw it in the DrawingContext.
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }
        #endregion

        #region Required overrides
        protected override int VisualChildrenCount
        {
            get { return theVisuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            // Value must be creater than zero, so do a sainity check.
            if (index < 0 || index >= theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return theVisuals[index];
        }
        #endregion

        #region Hit testing logic
        void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Figure out where the user clicked.
            Point pt = e.GetPosition((UIElement)sender);

            // Call helper function via delegate to see if we clicked on a visual.
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior myCallback(HitTestResult result)
        {        
            // Toggle between a skewed rendering and normal rendering,
            // if a visual was clicked. 
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Transform == null)
                {
                    ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Transform = null;
                }
            }

            // Tell HitTest() to stop drilling into the visual tree.
            return HitTestResultBehavior.Stop;
        }
        #endregion
    }
}
