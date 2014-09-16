using System;

namespace MapAndPosition
{
	static public class PositionSystem {
		// the positions of the characters
		static private Vector3D[][] _characterPositions;

		// check that the positions exist on the map, and place the characters there
		static public void placeCharacters(Vector3D[][] characterPositions) {
			if (characterPositions == null)
				throw new NoPositionPassedException ();

			foreach (Vector3D[] group in characterPositions) {
				foreach (Vector3D position in group) {
					try {
						if ((position.x < 0) || (position.x >= MapSystem.currentMap.tileArray [position.y].Length))
							throw new PositionNotOnMapException ("The position " + position.ToString () + " is not on the map.", null);
					} catch (IndexOutOfRangeException e) {
						throw new PositionNotOnMapException ("The position " + position.ToString () + " is not on the map.", e);
					}
				}
			}

			_characterPositions = characterPositions;
		}

		static public Vector3D getCharacterPosition(int characterGroup, int characterIndex) {
			try {
				return _characterPositions [characterGroup] [characterIndex];
			}
			catch (ArgumentOutOfRangeException e) {
				throw new NoSuchCharacterException ("No character exists in group " + characterGroup + " at index " + characterIndex, e);
			}
		}

		static private void moveCharacterWithoutMovementCheck(int characterGroup, int characterIndex, Vector3D new_position) {
			if (new_position == null)
				throw new NoPositionPassedException ();

			// check that the position exists on the map
			// if the position does not exist, then throw
			// a PositionNotOnMapException
			// do this by checking that the x value is within the range of the jagged tileArray
			// if this throws an IndexOutOfRangeException,
			// then the positition is also not on the map
			try {
				if ((new_position.x < 0) || (new_position.x >= MapSystem.currentMap.tileArray[new_position.y].Length))
					throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", null);
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}

			// assign the character's position
			try {
				_characterPositions [characterGroup] [characterIndex] = new_position;
			}
			catch (IndexOutOfRangeException e) {
				throw new NoSuchCharacterException ("No character exists in group " + characterGroup + " at index " + characterIndex, e);
			}
		}

		static public void walkCharacterPlusX(int characterGroup, int characterIndex) {
			Vector3D current_position = getCharacterPosition (characterGroup, characterIndex);

			// throw an exception if the you can't exit the character's current tile to the positive x direction
			if (MapSystem.currentMap.tileArray [current_position.y] [current_position.x].exit_to_positive_x == false)
				throw new MoveToNewPositionIsBlockedException ("Character (" + characterGroup + "," + characterIndex + ") cannot exit the position " + current_position.ToString() + " in the +x direction.");

			Vector3D new_position = current_position + new Vector3D (1, 0, 0);

			// if the new position is not walkable, throw an error

			// if an index out of range exception is thrown, there is no tile in the positive x direction
			try {
				if (MapSystem.currentMap.tileArray [new_position.y] [new_position.x].walkable == false)
					throw new MoveToNewPositionIsBlockedException ("The position " + new_position.ToString() + " cannot be walked on.");
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}

			// set the new height to the new tile's height
			new_position.z = MapSystem.currentMap.tileArray [new_position.y] [new_position.x].height;

			// move the character to the new position
			moveCharacterWithoutMovementCheck (characterGroup, characterIndex, new_position);
		}

		static public void walkCharacterMinusX(int characterGroup, int characterIndex) {
			Vector3D current_position = getCharacterPosition (characterGroup, characterIndex);

			// throw an exception if the you can't exit the character's current tile to the negative x direction
			if (MapSystem.currentMap.tileArray [current_position.y] [current_position.x].exit_to_negative_x == false)
				throw new MoveToNewPositionIsBlockedException ("Character (" + characterGroup + "," + characterIndex + ") cannot exit the position " + current_position.ToString() + " in the -x direction.");

			Vector3D new_position = current_position + new Vector3D (-1, 0, 0);

			// if the new position is not walkable, throw an error

			// if an index out of range exception is thrown, there is no tile in the positive x direction
			try {
				if (MapSystem.currentMap.tileArray [new_position.y] [new_position.x].walkable == false)
					throw new MoveToNewPositionIsBlockedException ("The position " + new_position.ToString() + " cannot be walked on.");
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}

			// set the new height to the new tile's height
			new_position.z = MapSystem.currentMap.tileArray [new_position.y] [new_position.x].height;

			// move the character to the new position
			moveCharacterWithoutMovementCheck (characterGroup, characterIndex, new_position);
		}

		static public void walkCharacterPlusY(int characterGroup, int characterIndex) {
			Vector3D current_position = getCharacterPosition (characterGroup, characterIndex);

			// throw an exception if the you can't exit the character's current tile to the positive y direction
			if (MapSystem.currentMap.tileArray [current_position.y] [current_position.x].exit_to_positive_y == false)
				throw new MoveToNewPositionIsBlockedException ("Character (" + characterGroup + "," + characterIndex + ") cannot exit the position " + current_position.ToString() + " in the +y direction.");

			Vector3D new_position = current_position + new Vector3D (0, 1, 0);

			// if the new position is not walkable, throw an error

			// if an index out of range exception is thrown, there is no tile in the positive x direction
			try {
				if (MapSystem.currentMap.tileArray [new_position.y] [new_position.x].walkable == false)
					throw new MoveToNewPositionIsBlockedException ("The position " + new_position.ToString() + " cannot be walked on.");
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}

			// set the new height to the new tile's height
			new_position.z = MapSystem.currentMap.tileArray [new_position.y] [new_position.x].height;

			// move the character to the new position
			moveCharacterWithoutMovementCheck (characterGroup, characterIndex, new_position);
		}

		static public void walkCharacterMinusY(int characterGroup, int characterIndex) {
			Vector3D current_position = getCharacterPosition (characterGroup, characterIndex);

			// throw an exception if the you can't exit the character's current tile to the negative y direction
			if (MapSystem.currentMap.tileArray [current_position.y] [current_position.x].exit_to_negative_y == false)
				throw new MoveToNewPositionIsBlockedException ("Character (" + characterGroup + "," + characterIndex + ") cannot exit the position " + current_position.ToString() + " in the -y direction.");

			Vector3D new_position = current_position + new Vector3D (0, -1, 0);

			// if the new position is not walkable, throw an error

			// if an index out of range exception is thrown, there is no tile in the positive x direction
			try {
				if (MapSystem.currentMap.tileArray [new_position.y] [new_position.x].walkable == false)
					throw new MoveToNewPositionIsBlockedException ("The position " + new_position.ToString() + " cannot be walked on.");
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}
				
			// set the new height to the new tile's height
			new_position.z = MapSystem.currentMap.tileArray [new_position.y] [new_position.x].height;

			// move the character to the new position
			moveCharacterWithoutMovementCheck (characterGroup, characterIndex, new_position);
		}

		static public void teleportCharacterToWalkableLocation(int characterGroup, int characterIndex, Vector3D new_position) {
			// check that the new position can be walked on
			// if an index out of range exception is thrown, the tile is not on the map

			try {
				if (MapSystem.currentMap.tileArray [new_position.y] [new_position.x].walkable == false)
					throw new MoveToNewPositionIsBlockedException ("The position " + new_position.ToString() + " cannot be walked on.");
			}
			catch (IndexOutOfRangeException e) {
				throw new PositionNotOnMapException ("The position " + new_position.ToString() + " is not on the map.", e);
			}

			// move the character to the new position
			moveCharacterWithoutMovementCheck (characterGroup, characterIndex, new_position);
		}



		//-------------------------------------------------
		// Exceptions having to do with character position

		// Exception to be thrown when no position is passed to the method
		public class NoPositionPassedException : Exception {
			public NoPositionPassedException () {}
		}


		// Exception to be thrown when a character tries to move off the map
		public class PositionNotOnMapException : Exception {
			public PositionNotOnMapException (string message, Exception e) : base (message, e) {}
		}

		// Exception to be thrown when someone tries to move a character that doesn't exist
		public class NoSuchCharacterException : Exception {
			public NoSuchCharacterException (string message, Exception e) : base (message, e) {}
		}

		public class MoveToNewPositionIsBlockedException : Exception {
			public MoveToNewPositionIsBlockedException (string message) : base (message) {}
		}
	}
}

