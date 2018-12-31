using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class Set_Frame_Sequence_Command : Command
    {
        private Vector2 _acceleration;

        public Set_Frame_Sequence_Command(Vector2 acceleration)
        {
            _acceleration = acceleration;
        }

        public Set_Frame_Sequence_Command()
        {
        }

        public override void Execute(GameObject gameObject)
        {
            if (_acceleration.Y == 1)
                gameObject.GetComponent<Animator>().SetFrameSequence(0);
            if (_acceleration.Y == -1)
                gameObject.GetComponent<Animator>().SetFrameSequence(3);
            if (_acceleration.X == -1)
                gameObject.GetComponent<Animator>().SetFrameSequence(1);
            if (_acceleration.X == 1)
                gameObject.GetComponent<Animator>().SetFrameSequence(2);
        }

        public override void Continue(GameObject gameObject)
        {

        }

        public override void Terminate(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
