/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 1/2/2021
 * Time: 3:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.World.Grid {
	
	public class MapGrid {
		
		private List<Tile> tiles;
		public readonly Byte size;
		
		public MapGrid (Byte size) {
			
			this.size=size;
			
			this.tiles=new List<Tile>(
					
					/* The idea behind this 
					 * equation is 4 quadrants
					 * because size spans from
					 * +size to -size */
					(UInt16)
					(
						(size*size)*4
					)
					
				);
			
		}
		
		public void generateGrass () {
			
			Int32 i=size;
			UInt16 j=0;
			while (i!=((-size)-1)) {
				
				j=0;
				while (j!=size*2) {
					this.tiles.Add(new Tile(size-j,i,"Grass_Tile"));
					++j;
				}
				
				--i;
				
			}
			
		}
		
		public void load () {
			
			foreach (Tile t in this.tiles)
				GameObject.Instantiate(GameObject.Find(t.tileType),new Vector3(t.x,0F,t.z),Quaternion.identity).name="Tile_"+t.id;
			
		}
		
		public UInt16 tileAt (Single x,Single z) { return ((UInt16)this.tiles.IndexOf(this.tiles.Where(i=>(i.x==Math.Floor(x)&&i.z==Math.Floor(z))).First())); }
		public Tile tileAt (UInt16 index) { return this.tiles[index]; }
		
		public void setTile (UInt16 index,String type) {
			
			Tile t=this.tiles[index];
			t.tileType=type;
			GameObject.Destroy(GameObject.Find("Tile_"+t.id.ToString()));
			GameObject.Instantiate(GameObject.Find(type),new Vector3(t.x,0F,t.z),Quaternion.identity);
			
		}
		
	}
	
}
