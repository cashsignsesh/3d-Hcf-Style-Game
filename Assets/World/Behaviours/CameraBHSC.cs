/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 12/29/2020
 * Time: 8:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace Assets.World.Behaviours {
	
	public class CameraBHSC : MonoBehaviour {
		
		private void Update () {
			
			if (Creature.mainCharacter==null) return;
			
			this.transform.position=new Vector3(Creature.mainCharacter.x+1F,3F,Creature.mainCharacter.z-4.5F);
						
		}
		
	}
	
}