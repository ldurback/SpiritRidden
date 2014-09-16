using System;

namespace MapAndPosition
{
	public class Vector3D {
		public static Vector3D Zero = NewZero ();
		public static Vector3D One = NewOne ();

		public int x;
		public int y;
		public int z;

		public Vector3D ()
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public Vector3D (int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3D (int xyz)
		{
			this.x = xyz;
			this.y = xyz;
			this.z = xyz;
		}

		public Vector3D (Vector3D v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		public static Vector3D NewZero ()
		{
			return new Vector3D (0);
		}

		public static Vector3D NewOne ()
		{
			return new Vector3D (1);
		}

		public float DotProduct (Vector3D other)
		{
			return x * other.x + y * other.y + z * other.z;
		}

		public static Vector3D operator + (Vector3D v1, Vector3D v2)
		{
			return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
		}

		public static Vector3D operator - (Vector3D v1, Vector3D v2)
		{
			return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
		}

		public static Vector3D operator - (Vector3D v)
		{
			return new Vector3D(-v.x, -v.y, -v.z);
		}

		public static Vector3D operator * (Vector3D v, int scalar)
		{
			return new Vector3D(v.x * scalar, v.y * scalar, v.z * scalar);
		}

		public static Vector3D operator / (Vector3D v, int scalar)
		{
			return new Vector3D(v.x / scalar, v.y / scalar, v.z / scalar);
		}

		public static bool operator == (Vector3D v1, Vector3D v2)
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

			return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
		}

		public static bool operator !=(Vector3D v1, Vector3D v2)
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

			return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
		}

		public static Vector3D CrossProduct (Vector3D a, Vector3D b)
		{
			return new Vector3D (a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
		}

		public Vector3D Add (Vector3D v)
		{
			x += v.x;
			y += v.y;
			z += v.z;
			return this;
		}

		public Vector3D Clone ()
		{
			return new Vector3D (this);
		}

		override public bool Equals (Object o)
		{
			if (o == null)
			{
				return false;
			}

			Vector3D v = (Vector3D) o;

			return this.x == v.x && this.y == v.y && this.z == v.z;
		}

		public override string ToString ()
		{
			return "(" + x + ", " + y + ", " + z + ")";
		}

		public override int GetHashCode ()
		{
			return new { x, y, z }.GetHashCode ();
		}
	}
}

