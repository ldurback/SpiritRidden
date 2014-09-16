using System;
using System.Collections.Generic;

using MapAndPosition;

namespace MapAndPosition.MapEvents {
	// a basic Events that displays a message on loading and exiting
	public class Events1 : Events {
		override public void onEnter () {
			Console.Out.WriteLine ("Map Loaded");
		}

		override public void onExit () {
			Console.Out.WriteLine ("Map Exiting");
		}

		override public void onMove (Vector3D tile_postion) {
			Console.Out.WriteLine ("A character moved to " + tile_postion.ToString ());
		}
	}
}

