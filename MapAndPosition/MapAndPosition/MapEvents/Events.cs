using System;
using System.Collections.Generic;

namespace MapAndPosition.MapEvents {
	// extend from the Events class to write events for a map
	public class Events {
		// onEnter should be executed when the map loads
		public virtual void onEnter () {}

		// onExit should be executed before the map exits
		public virtual void onExit () {}

		// onStep should be executed when a character moves to a new position
		// in the future, onStep will also require the character
		// stepped on the tile to be passed
		public virtual void onMove (Vector3D tile_position) {}
	}
}

