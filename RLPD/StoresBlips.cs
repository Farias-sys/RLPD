using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Drawing;

namespace RealLifePD
{
    class StoresBlips
    {
        public static void proccessBlips(bool option)
        {
            if (option == true)
            {
                Vector3 store1Coords = new Vector3(26.06f, -1345.75f, 29.49f);
                Vector3 store2Coords = new Vector3(2555.405f, 382.132f, 108.623f);
                Vector3 store3Coords = new Vector3(1960.272f, 3742.25f, 32.34f);
                Vector3 store4Coords = new Vector3(1729.742f, 6416.143f, 35.03f);

                Blip FoodStore1 = new Blip(store1Coords);
                Blip FoodStore2 = new Blip(store2Coords);
                Blip FoodStore3 = new Blip(store3Coords);
                Blip FoodStore4 = new Blip(store4Coords);

                BlipSprite sprite = new BlipSprite();
                sprite = BlipSprite.Bar;

                FoodStore1.Name = "Food Shop";
                FoodStore1.Sprite = sprite;

                FoodStore2.Name = "Food Shop";
                FoodStore2.Sprite = sprite;

                FoodStore3.Name = "Food Shop";
                FoodStore3.Sprite = sprite;

                FoodStore4.Name = "Food Shop";
                FoodStore4.Sprite = sprite;
            if (option == false)
            {
                FoodStore1.Delete();
                FoodStore2.Delete();
                FoodStore3.Delete();
                FoodStore4.Delete();
            }

            }
        }
    }
}
