using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ProjetWorms
{
    class SimpleAnimationDefinition
    {
        public string AssetName { get; set; }
        public Point FrameSize { get; set; }
        public Point NbFrames { get; set; }
        public int FrameRate { get; set; }
    }
}
