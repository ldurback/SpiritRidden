using System;

namespace MapAndPosition {
	public static class MapSystem {
		// the map, once loaded
		static private Map _currentMap;
		static public Map currentMap {
			get {
				return _currentMap;
			}
		}

		static public void generateTestMap () {
			_currentMap = new Map();

			_currentMap.tileArray = new Tile [10] [];

			for (int y = 0; y < 10; y++) {
				_currentMap.tileArray [y] = new Tile [10];
				for (int x = 0; x < 10; x++) {
					_currentMap.tileArray [y] [x] = new Tile ();
					_currentMap.tileArray [y] [x].imageNumber = x * y;
					_currentMap.tileArray [y] [x].walkable = true;
					_currentMap.tileArray [y] [x].height = x * y;
				}
			}

			_currentMap.eventsName = "Events1";

			_currentMap.events = new MapEvents.Events1();
		}

		// loads map
		static public void loadMap (string XMLfilename) {
			// try to deserialize the map from an XML file, and throw errors when errors accur
			try {
				_currentMap = Map.deserialize (XMLfilename);
			}
			catch (System.IO.FileNotFoundException e) {
				throw new MapXMLLoadingException ("File not found: " + XMLfilename, e);
			}
			catch (InvalidOperationException e) {
				throw new MapXMLLoadingException ("Error in XML File " + XMLfilename + ": " + e.Message, e);
			}
			catch (TypeLoadException e) {
				throw new MapXMLLoadingException ("The MapEvents " + e.TypeName + " specified to load in " + XMLfilename + " does not exist.", e);
			}
		}


		// Exception to be thrown when errors occur in loading the XML file for the map
		public class MapXMLLoadingException : Exception {
			public MapXMLLoadingException (string message, Exception e) : base (message, e) {}
		}
	}
}

