using System;
using Cairo;

namespace DSLImplementation
{
	public abstract class Edge2Base : IEdge2 {

		private INode node1, node2;
		private PointD loc1, loc2;

		#region IEdge2 implementation
		public INode NodeFrom {
			get {
				return this.node1;
			}
			set {
				compareAndRegister(ref this.node1,value);
			}
		}
		
		public INode NodeTo {
			get {
				return this.node2;
			}
			set {
				compareAndRegister(ref this.node2,value);
			}
		}
		#endregion

		public PointD Location1 {
			get {
				return this.loc1;
			}
		}
		public PointD Location2 {
			get {
				return this.loc2;
			}
		}

		protected Edge2Base () : this(null,null) {
		}
		protected Edge2Base (INode node1, INode node2) {
			this.NodeFrom = node1;
			this.NodeTo = node2;
			this.recalculateLocations(this,null);
		}

		void compareAndRegister (ref INode node1, INode value) {
			if(node1 != value) {
				if (node1 != null) {
					node1.BoundsChanged -= this.recalculateLocations;
				}
				node1 = value;
				if (node1 != null) {
					node1.BoundsChanged += this.recalculateLocations;
				}
				recalculateLocations(this,null);
			}
		}
		private void recalculateLocations (object s, EventArgs e)
		{
			if (this.node1 == null || this.node2 == null) {
				this.loc1 = this.loc2 = new PointD ();
			} else if (this.node1 == this.node2) {
				this.loc1 = this.loc2 = this.node1.Location;
			} else {
				double dx = this.node2.Location.X-this.node1.Location.X;
				double dy = this.node2.Location.Y-this.node1.Location.Y;
				this.loc2 = this.node2.GetLocationByAngle(Math.Atan2(-dy,-dx));
				this.loc1 = this.node1.GetLocationByAngle(Math.Atan2(dy,dx));
			}
		}

		#region IPaintPrimitive implementation
		public abstract void Paint (Context ctx);
		public abstract IPaintPrimitive Clone ();
		public abstract bool Contains (PointD point);
		public Rectangle GetBounds () {
			double x0 = this.Location1.X;
			double x1 = this.Location1.Y;
			double y0 = this.Location2.X;
			double y1 = this.Location2.Y;
			double xm = Math.Min(x0,x1);
			double xM = Math.Max(x0,x1);
			double ym = Math.Min(y0,y1);
			double yM = Math.Max(y0,y1);
			return new Rectangle(xm,ym,xM-xm,yM-ym);
		}
		#endregion

		#region IEdge implementation
		public void setEdgeNode (int index, INode node)
		{
			switch(index) {
			case 0x00 :
				this.NodeFrom = node;
				break;
			case 0x01 :
				this.NodeTo = node;
				break;
			}
		}
		#endregion
	
	}
}

