using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace MapAndPosition {

	// The tiles have an imageNumber which references the image for the tile and a height
	//  a flag that says whether or not you can walk on the tile
	// and flags that say which way you can exit the tile
	[XmlType("t")]
	public class Tile {
	
		[XmlAttribute("i"), DefaultValue(0)]
		public int imageNumber = 0;

		[XmlAttribute("h"), DefaultValue(0)]
		public int height = 0;

		// can a character walk on this tile?
		[XmlAttribute("w"), DefaultValue(true)]
		public bool walkable = true;

		// which directions can a character exit?
		[XmlAttribute("px"), DefaultValue(true)]
		public bool exit_to_positive_x = true;
		[XmlAttribute("nx"), DefaultValue(true)]
		public bool exit_to_negative_x = true;
		[XmlAttribute("py"), DefaultValue(true)]
		public bool exit_to_positive_y = true;
		[XmlAttribute("ny"), DefaultValue(true)]
		public bool exit_to_negative_y = true;
	}
}

