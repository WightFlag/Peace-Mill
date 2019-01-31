using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class AnimationController :Script
    {
        private Animator _animator;

        public AnimationController()
        {           
        }

        public AnimationController(GameObject gameObject)
        {
            this.gameObject = gameObject;
            this._animator = this.gameObject.GetComponent<Animator>();
        }

        public override void LoadContent()
        {
            base.LoadContent();     
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
