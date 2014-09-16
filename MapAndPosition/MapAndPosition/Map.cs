using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

using MapAndPosition;
using MapAndPosition.MapEvents;

namespace MapAndPosition {
	/*
	 * the Map class holds the tiles and events for a map
	 * the Map is (de)serializable (from/)to an XML file

	 * note, the Events class is not serializable, so
	 * I've instead used a string that contains the class
	 * name of the specific Events that should be loaded
	*/

	public class Map {
		// these instance variables are serializable

		[XmlArrayItem("column")]
		[XmlArray("tiles")]
		public Tile[][] tileArray = null;

		[XmlAttribute, DefaultValue("Events")]
		public string eventsName = "Events";

		// these instance variables are not serializable
		[XmlIgnoreAttribute]
		public Events events = null;

		// serializes Map to an XML file
		public void serialize (string serializationFilename) {
			XmlSerializer mySerializer = new XmlSerializer (typeof (Map));

			StreamWriter myWriter = new StreamWriter (serializationFilename);
			mySerializer.Serialize (myWriter, this);
			myWriter.Close ();
		}

		// deserializes Map from an XML file
		// then loads the MapEvents
		public static Map deserialize (string serializationFilename) {
			// load a serializer of the Map type,
			// then open a filestream at the filename
			// then deserialize the filestream
			XmlSerializer mySerializer = new XmlSerializer (typeof (Map));
			FileStream myFileStream = new FileStream (serializationFilename, FileMode.Open);
			Map deserializedMap = (Map) mySerializer.Deserialize (myFileStream);
			myFileStream.Close ();

			// load the MapEvents before returning
			deserializedMap.loadEventsFromName ();

			return deserializedMap;
		}

		// loads the Events from its name
		private void loadEventsFromName () {
			if (eventsName == null) { // load the blank MapEvents if none is specified
				events = new Events();
				return;
			}
				
			// otherwise, load the Type, then the constructor, then make a new instance
			Type eventsType = Type.GetType("MapAndPosition.MapEvents." + eventsName, true);
			var constructor = eventsType.GetConstructor(new Type[] { });
			events = (Events)constructor.Invoke (new object[] { });
		}
	}
}

