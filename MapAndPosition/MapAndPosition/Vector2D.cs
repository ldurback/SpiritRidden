using System;

namespace MapAndPosition
{
	public class Vector2D
	{
		public static Vector2D Zero = NewZero ();
		public static Vector2D One = NewOne ();

		public int x;
		public int y;

		public Vector2D ()
		{
			x = 0;
			y = 0;
		}

		public Vector2D (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2D (int xy)
		{
			this.x = xy;
			this.y = xy;
		}

		public Vector2D (Vector2D v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		public static Vector2D NewZero ()
		{
			return new Vector2D (0);
		}

		public static Vector2D NewOne ()
		{
			return new Vector2D (1);
		}

		public float DotProduct (Vector2D other)
		{
			return x * other.x + y * other.y;
		}

		public static Vector2D operator + (Vector2D v1, Vector2D v2)
		{
			return new Vector2D(v1.x + v2.x, v1.y + v2.y);
		}

		public static Vector2D operator - (Vector2D v1, Vector2D v2)
		{
			return new Vector2D(v1.x - v2.x, v1.y - v2.y);
		}

		public static Vector2D operator - (Vector2D v)
		{
			return new Vector2D(-v.x, -v.y);
		}

		public static Vector2D operator * (Vector2D v, int scalar)
		{
			return new Vector2D(v.x * scalar, v.y * scalar);
		}

		public static Vector2D operator / (Vector2D v, int scalar)
		{
			return new Vector2D(v.x / scalar, v.y / scalar);
		}

		public static bool operator == (Vector2D v1, Vector2D v2)
		{
			// If both are null, or both are same instance, return true.
			if (Object.ReferenceEquals(v1, v2))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)v1 == null) || ((object)v2 == null))
			{
				return false;
			}

			return v1.x == v2.x && v1.y == v2.y;
		}

		public static bool operator !=(Vector2D v1, Vector2D v2)
		{
			// If both are null, or both are same instance, return false.
			if (Object.ReferenceEquals(v1, v2))
			{
				return false;
			}

			// If one is null, but not both, return true.
			if (((object)v1 == null) || ((object)v2 == null))
			{
				return true;
			}

			return v1.x != v2.x || v1.y != v2.y;
		}
			

		public Vector2D Add (Vector2D v)
		{
			x += v.x;
			y += v.y;
			return this;
		}

		public Vector2D Clone ()
		{
			return new Vector2D (this);
		}

		override public bool Equals (Object o)
		{
			if (o == null)
			{
				return false;
			}

			Vector2D v = (Vector2D) o;

			return this.x == v.x && this.y == v.y;
		}

		public override string ToString ()
		{
			return "(" + x + ", " + y + ")";
		}

		public override int GetHashCode ()
		{
			return new { x, y }.GetHashCode ();
		}
	}
}

