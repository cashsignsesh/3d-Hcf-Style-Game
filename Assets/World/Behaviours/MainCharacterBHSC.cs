/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 12/29/2020
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.World.Behaviours.Util;

namespace Assets.World.Behaviours {
	
	public class MainCharacterBHSC : MonoBehaviour {
		
		internal List<MovementInstance> movementQueue;
		
		private String selectedTile;
		private Dictionary<String,Byte> inventory;
		
		private void Start () {
			
			this.movementQueue=new List<MovementInstance>();
			this.inventory=new Dictionary<String, Byte>();
			this.inventory.Add("Wood_Tile",3);
			this.selectedTile="Wood_Tile";
			
		}
		
		private void Update () {
			
			Vector3 goPos=this.gameObject.transform.position;
			
			if (this.movementQueue.Count>0) {
				
				MovementInstance mi=this.movementQueue[0];
				Creature.mainCharacter.x=mi.x;
				Creature.mainCharacter.z=mi.z;
				this.movementQueue.RemoveAt(0);
				
			}
			
			if (Creature.mainCharacter.x!=goPos.x||Creature.mainCharacter.z!=goPos.z)
				this.gameObject.transform.position=new Vector3(Creature.mainCharacter.x,0F,Creature.mainCharacter.z);
			
			if (Input.GetMouseButtonDown(1)) {
				
				Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
				Single dis;
				if (Hcf3dGame.world.xzPlane.Raycast(ray,out dis)) {//TODO:: stop the raycast at a wall/creature when walls/creatures are added
					
					Vector3 pointOnPlane=ray.GetPoint(dis);//TODO:: if (dis.y!=0)dis.y=0, so that when it stops at the wall it will go to y=0
					Movement.processMovement(Creature.mainCharacter,pointOnPlane,this);
					GameObject ln=new GameObject("pathLn");
					LineRenderer lr=ln.AddComponent<LineRenderer>();
					lr.material=new Material(Shader.Find("Sprites/Diffuse"));
					lr.startColor=Color.white;
					lr.endColor=Color.white;
					lr.startWidth=0.1F;
					lr.endWidth=0.1F;
					lr.SetPositions(new []{new Vector3(pointOnPlane.x,0F,pointOnPlane.z),new Vector3(pointOnPlane.x+0.1F,0F,pointOnPlane.z+0.1F)});
					GameObject.Destroy(ln,0.6F);
					
				}
				
			}
			if (Input.GetMouseButtonDown(0)) {
				
				Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
				Single dis;
				if (Hcf3dGame.world.xzPlane.Raycast(ray,out dis)) {//TODO:: stop the raycast at a wall/creature when walls/creatures are added
					
					if (dis>Creature.mainCharacter.reach) return;
					this.GetComponent<Animator>().SetBool("Jab",true);
					
					Vector3 pointOnPlane=ray.GetPoint(dis);
					
					//TODO:: if it is tile do this.. if it is wall do other..
					if (this.inventory[this.selectedTile]>0) {
						
						Hcf3dGame.world.grid.setTile(Hcf3dGame.world.grid.tileAt(pointOnPlane.x,pointOnPlane.z),this.selectedTile);
						--this.inventory[this.selectedTile];
						
					}
					
				}
				
			}
			
		}
		
		/// <summary>
		/// Set rotation
		/// </summary>
		/// <param name="degrees">
		/// Probably vulnurable to stack overflow exception if this parameter is a really high number
		/// </param>
		public void setRotation (Single degrees) {
			
			if (degrees>359F) {
				
				this.setRotation(degrees-360F);
				return;
				
			}
			
			this.gameObject.transform.rotation=Quaternion.Euler(0F,degrees-90F,0F);
			
			//TODO:: rotate and move camera along with this
			
		}
		
	}
	
}