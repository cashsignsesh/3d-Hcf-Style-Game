/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 1/2/2021
 * Time: 3:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Assets.World.Grid {
	
	//TODO:: add walk speed
	public struct Tile {
		
		private static UInt32 _id;
		
		public readonly Single x,z;
		public readonly UInt32 id;
		public String tileType;
		
		public Tile (Single x,Single z,String type) {
			
			this.x=x;
			this.z=z;
			this.tileType=type;
			this.id=Tile._id;
			++Tile._id;
			
		}
		
	}
	
}
