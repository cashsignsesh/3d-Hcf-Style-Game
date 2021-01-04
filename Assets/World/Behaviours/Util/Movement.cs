/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 1/1/2021
 * Time: 2:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace Assets.World.Behaviours.Util {
	
	/// <summary>
	/// Description of Movement.
	/// </summary>
	public static class Movement {
		
		private const Decimal inc=0.01M;
		private const Single degreesPerRadian=57.2958F;
		
		public static void processMovement (Creature creature,Vector3 desiredLocation,MainCharacterBHSC sender) {
			
			Double val=(Math.Abs(Math.Atan2((creature.z-desiredLocation.z),(creature.x-desiredLocation.x)))*degreesPerRadian);
			sender.setRotation((UInt16)((desiredLocation.z<creature.z)?360-val:val));
			
			//HACK:: if this doesn't work because tile movespeed changes, then recalculate the movementQueue
			Decimal x=(Decimal.Round((Decimal)creature.x,2)),z=(Decimal.Round((Decimal)creature.z,2)),x0=(Decimal.Round((Decimal)desiredLocation.x,2)),z0=(Decimal.Round((Decimal)desiredLocation.z,2)),xx=Math.Abs(x0-x),xx0=x<x0?Movement.inc:-Movement.inc,zz=-Math.Abs(z0-z),zz0=(Decimal)z<z0?Movement.inc:-Movement.inc,e=xx+zz,e0=0;
			UInt16 speedCtr=0;
			
			sender.movementQueue.Clear();
			
			while ((x!=x0)&&(z!=z0)) {
				
				++speedCtr;
				e0=2*e;
				if (e0>zz) {e+=zz;x+=xx0;}
				else if (e0<xx) {e+=xx;z+=zz0;}
				
				if (speedCtr==creature.speed) {
					
					sender.movementQueue.Add(new MovementInstance(){x=(Single)x,z=(Single)z});
					speedCtr=0;
					
				}
				
			}
		
		}
		
		public static Vector3 toVector3 (this MovementInstance instance) { return new Vector3(instance.x,0F,instance.z); }
		
	}
	
	public struct MovementInstance { public Single x,z; }
	
}
