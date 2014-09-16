using System;

namespace MapAndPosition {
	class Program {
		static int numPlayers = 2;

		static void Main (string[] args) {
			MapSystem.generateTestMap();
			//MapSystem.loadMap (AppDomain.CurrentDomain.BaseDirectory + "../../MapXMLs/Map1.xml");

			Vector3D[] startPositionsForPlayers = new Vector3D[numPlayers];
			for (int index = 0; index < startPositionsForPlayers.Length; index++) {
				startPositionsForPlayers [index] = Vector3D.NewZero ();
			}



			PositionSystem.placeCharacters (new Vector3D[1][] {startPositionsForPlayers});
			MapSystem.currentMap.events.onEnter ();

			do {
				displayTextMap ();
				displayPlayerLocations ();
			} while (doMenu ());
				
			MapSystem.currentMap.events.onExit ();

			MapSystem.currentMap.serialize (AppDomain.CurrentDomain.BaseDirectory + "../../MapXMLs/Map1.xml");
		}
			
		static void displayTextMap () {
			for (int y = 0; y < MapSystem.currentMap.tileArray.GetLength (0); y++) {
				for (int x = 0; x < MapSystem.currentMap.tileArray[y].GetLength (0); x++) {
					Console.Out.Write("{0:D2}", MapSystem.currentMap.tileArray[y][x].imageNumber);
					Console.Out.Write(' ');
				}
				Console.Out.Write(Console.Out.NewLine);
			}
		}

		static void displayPlayerLocations () {
			for (int playerIndex = 0; playerIndex < numPlayers; playerIndex++) {
				Console.Out.WriteLine ("Player " + playerIndex + " is at " + PositionSystem.getCharacterPosition (0, playerIndex));
			}
		}

		// displays a menu and asks for a movement of a player
		// returns true on continue
		// returns false on quit
		static bool doMenu () {
			Console.Out.WriteLine ("Q to quit.  0->" + (numPlayers - 1).ToString () + " to move a player");

			string input = Console.ReadLine ();
			if (input.ToLower () == "q") return false;

			int playerIndex;
			try {
				playerIndex = int.Parse (input);
			}
			catch {
				return true;
			}

			if (playerIndex < 0 || playerIndex >= numPlayers) {
				Console.Out.WriteLine ("There is no player " + playerIndex);
				return true;
			}

			Console.Out.WriteLine ("'+X' to move player " + playerIndex + " in the +X direction");
			Console.Out.WriteLine ("'-X' to move player " + playerIndex + " in the -X direction");
			Console.Out.WriteLine ("'+Y' to move player " + playerIndex + " in the +Y direction");
			Console.Out.WriteLine ("'-Y' to move player " + playerIndex + " in the -X direction");
			Console.Out.WriteLine ("'T' to teleport player " + playerIndex + " to " + Vector3D.NewZero());

			input = Console.ReadLine ().ToLower ();

			try {
				switch (input) {
				case "+x":
					PositionSystem.walkCharacterPlusX (0, playerIndex);
					MapSystem.currentMap.events.onMove(PositionSystem.getCharacterPosition(0, playerIndex));
					break;
				case "-x":
					PositionSystem.walkCharacterMinusX (0, playerIndex);
					MapSystem.currentMap.events.onMove(PositionSystem.getCharacterPosition(0, playerIndex));
					break;
				case "+y":
					PositionSystem.walkCharacterPlusY (0, playerIndex);
					MapSystem.currentMap.events.onMove(PositionSystem.getCharacterPosition(0, playerIndex));
					break;

				case "-y":
					PositionSystem.walkCharacterMinusY (0, playerIndex);
					MapSystem.currentMap.events.onMove(PositionSystem.getCharacterPosition(0, playerIndex));
					break;
				case "t":
					PositionSystem.teleportCharacterToWalkableLocation (0, playerIndex, Vector3D.NewZero ());
					MapSystem.currentMap.events.onMove(PositionSystem.getCharacterPosition(0, playerIndex));
					break;
				default:
					Console.Out.WriteLine ("Invalid Input");
					break;
				}
			}
			catch (PositionSystem.PositionNotOnMapException) {
				Console.Out.WriteLine ("Cannot walk off the map.");
			}
			catch (PositionSystem.MoveToNewPositionIsBlockedException e) {
				Console.Out.WriteLine (e.Message);
			}
			catch (PositionSystem.NoSuchCharacterException e) {
				// this should never happen, so throw an exception
				throw e;
			}

			return true;
		}
    }
}
