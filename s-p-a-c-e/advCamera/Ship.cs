using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace advCamera
{
    
    class Ship : IFocusable
    {
        Texture2D texture;
        Vector2 position;
        Vector2 widthHeight;
        Vector2 origin; 


        public Vector2 Position
        {
            get { return position; }
        }

        public Vector2 WidthHeight
        {
            get { return widthHeight; }
        }

        public Vector2 Origin
        {
            get { return origin; }
        }

        public Ship()
        {
        }

        float moveSpeed = 5f;
        float rotationAngle = 0;
        public void Update()
        {
            position.X += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * moveSpeed;
            position.Y += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * moveSpeed) * -1;
             rotationAngle = (float)Math.Atan2(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X, GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y);

        }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ship");
            position = new Vector2(100f, 100f);
            widthHeight = new Vector2(texture.Width, texture.Height);
            Debug.WriteLine(texture.Width);            
            origin.X += (float)texture.Width / 2;
            origin.Y += (float)texture.Height / 2;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotationAngle,origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
