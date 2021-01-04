using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.World;

namespace Assets {
	
	//Game name ideas: Creatures
	
	public class Hcf3dGame {
		
		public static World.World world;
		
		[RuntimeInitializeOnLoadMethod]
		public static void init () {
			
			Hcf3dGame.world=new World.World(24);
			Hcf3dGame.world.load();
			Hcf3dGame.world.spawnCreature(CreatureType.FIGHTER,"Player",0F,0F,2F,8F).setAsMainCharacter();
			
		}
		
	}
	
}