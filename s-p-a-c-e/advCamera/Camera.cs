using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace advCamera
{
    public interface IFocusable
    {
        Vector2 Position { get; }
        Vector2 WidthHeight { get; }
        Vector2 Origin { get; }
    }

    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }


        private Vector2 centre;
        private Viewport viewport;

        private float zoom = 1;
        private float rotation = 0;

        public float x
        {
            get { return centre.X; }
            set { centre.X = value; }
        }
        public float y
        {
            get { return centre.Y; }
            set { centre.Y = value; }
        }

        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; if (zoom < 0.1f) zoom = 0.1f;}
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(IFocusable focusable)
        {
            
            centre = new Vector2(focusable.Position.X, focusable.Position.Y);
            transform = Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0)) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                        Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));

        }
    }
}
