/*
 * Created by SharpDevelop.
 * User: Elite
 * Date: 12/29/2020
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Assets.World {
	
	public enum CreatureType {
		
		[CreatureTypeData("Fighter")]
		FIGHTER
		
	}
	
	public class CreatureTypeDataAttribute : Attribute {
		
		public readonly String spriteName;
		
		public CreatureTypeDataAttribute (String spriteName) { this.spriteName=spriteName; }
		
	}
	
}