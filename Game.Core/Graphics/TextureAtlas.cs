using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.Graphics
{
    internal class TextureAtlas
    {
        private readonly Dictionary<string, AtlasItem> _atlas;

        public TextureAtlas(string atlas)
        {
            var contentManager = GameCore.Game.Services.GetService<ContentManager>();
            Texture = contentManager.Load<Texture2D>(atlas);
            _atlas = GetAtlas(contentManager, atlas);
        }

        public Rectangle this[int index]
        {
            get { return _atlas.ElementAt(index).Value.Rect; }
        }

        public Rectangle this[string name]
        {
            get { return _atlas[name].Rect; }
        }

        public Texture2D Texture { get; }

        private static Dictionary<string, AtlasItem> GetAtlas(ContentManager content, string atlas)
        {
            using (var stream = TitleContainer.OpenStream($"{content.RootDirectory}/{atlas}.txt"))
            {
                var reader = new StreamReader(stream);
                var lines = reader.ReadToEnd().Split(new char[] {'\r', '\n'});
                return lines
                    .Select(ParseLine)
                    .ToDictionary(ai => ai.Name, ai => ai);
            }
        }

        private static AtlasItem ParseLine(string atlasDescription)
        {
            var parts = atlasDescription.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            var name = parts[0];
            var x = parts[1];
            var y = parts[2];
            var w = parts[3];
            var h = parts[4];

            var rect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));
            return new AtlasItem(name, rect);
        }
    }
}