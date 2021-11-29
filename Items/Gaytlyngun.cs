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

	    DashPlayer mp; 
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            mp.DashingActive = true;
            mp.OldVelocity = player.velocity;
            //player.velocity.X += 4.0f * player.direction;
        }

        public override void UpdateInventory(Player player) 
        {
            mp = player.GetModPlayer<DashPlayer>();


            if (!mp.DashingActive) return;

            player.eocDash = mp.DashTimer;
			player.armorEffectDrawShadowEOCShield = true;

            // player.velocity.X += mp.DashVelocity * player.direction;
            if(mp.DashTimer == DashPlayer.MAX_DASH_TIMER)
			{	
				player.velocity.X += mp.DashVelocity * player.direction;
			}

			//Decrement the timers
			mp.DashTimer--;
			mp.DashDelay--;
            if(mp.DashDelay == 0)
			{
				//The dash has ended.  Reset the fields
				mp.DashDelay = DashPlayer.MAX_DASH_DELAY;
				mp.DashTimer = DashPlayer.MAX_DASH_TIMER;
				mp.DashingActive = false;
                player.velocity /= 10.0f;
			}
        }

        public class DashPlayer : ModPlayer
        { 
            public bool DashingActive = false;
            public int DashDelay = MAX_DASH_DELAY;
            public int DashTimer = MAX_DASH_TIMER;
            public readonly float DashVelocity = 10.0f;
            public Vector2 OldVelocity;
            //These two fields are the max values for the delay between dashes and the length of the dash in that order
            //The time is measured in frames
            public static readonly int MAX_DASH_DELAY = 25;
            public static readonly int MAX_DASH_TIMER = 35;
        }
    }
}
