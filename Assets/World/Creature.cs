/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 12/29/2020
 * Time: 6:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using Assets.World.Behaviours;

namespace Assets.World {
	
	public class Creature {
		
		public static Creature mainCharacter { get; private set; }
		public Single x,z,speed,reach;
		public String name;
		private protected GameObject _creature;
		
		public Creature (CreatureType type,String name,Single x,Single z,Single speed,Single reach,Single y=0F) {
			
			this.x=x;
			this.z=z;
			this.name=name;
			this.speed=speed;
			this.reach=reach;
			
			this._creature=GameObject.Instantiate(GameObject.Find(((type.GetType().GetMember(type.ToString())[0].GetCustomAttributes(typeof(CreatureTypeDataAttribute),false)[0]as CreatureTypeDataAttribute).spriteName)),new Vector3(x,y,z),Quaternion.Euler(0F,35F,0F));
			this._creature.name=name;
			this._creature.AddComponent(typeof(CreatureBHSC));
			
		}
		
		public void setAsMainCharacter () {
			
			if (Creature.mainCharacter!=null) UnityEngine.Object.DestroyImmediate(Creature.mainCharacter._creature.GetComponent<MainCharacterBHSC>());
			Creature.mainCharacter=this;
			this._creature.AddComponent<MainCharacterBHSC>();
			
		}
		
	}
	
}