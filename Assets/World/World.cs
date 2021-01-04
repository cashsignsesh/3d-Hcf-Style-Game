/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 12/29/2020
 * Time: 6:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.World;
using UnityEngine;
using Assets.World.Grid;

//TODO:: change namespace name so it's not the same as the class.
namespace Assets.World {
	
	public class World {
		
		private List<Creature> creatures;
		public readonly MapGrid grid;
   		public readonly Plane xzPlane;
		
		public World (Byte size) {
			
			this.creatures=new List<Creature>();
			this.xzPlane=new Plane(Vector3.up,Vector3.zero);
			this.grid=new MapGrid(size);
			
		}
		
		public Creature spawnCreature (CreatureType type,String name,Single x,Single z,Single reach,Single y=0F) {
			
			Creature ct=new Creature(type,name,x,z,reach,y);
			this.creatures.Add(ct);
			return ct;
			
		}
   		
   		public void load () {
   			
   			this.grid.generateGrass();
   			this.grid.load();
   			
   		}
   		
   		public void setTile (UInt16 index,String type) { this.grid.setTile(index,type); }
		
	}
	
}