using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace springEquinox.Items
{
    public class Gaytlyngun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Penis, lol");
        }

        public override void SetDefaults()
        {
            Item.damage = 9999999;
            Item.DamageType = DamageClass.Melee;
            Item.width = 100;
            Item.height = 20;
            Item.useTime =10;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 10000000;
            Item.value = 1;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            public int timer=0;

            player.velocity.X += 4.0f * player.direction;
            while(timer<60)
            {
              ++timer;
            }
            player.velocity.X = 0f;


        }

    }

}
