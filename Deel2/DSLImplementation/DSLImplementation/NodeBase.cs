using System;
using System.Collections.Generic;
using System.Linq;
using Cairo;

namespace DSLImplementation
{
	public abstract class NodeBase : INode {

		private PointD location = new PointD();
		private event EventHandler boundsChanged;

		public event EventHandler BoundsChanged {
			add {
				this.boundsChanged += value;
			}
			remove {
				this.boundsChanged -= value;
			}
		}
		public PointD Location {
			get {
				return this.location;
			}
			set {
				if(!this.location.Equals(value)) {
					this.location = value;
					OnBoundsChanged(EventArgs.Empty);
				}
			}
		}

		protected NodeBase () : this(new PointD()) {}
		protected NodeBase (PointD location) {
			this.Location = location;
		}

		protected virtual void OnBoundsChanged (EventArgs e) {
			if(this.boundsChanged != null) {
				this.boundsChanged(this,e);
			}
		}

		#region IPaintPrimitive implementation
		public abstract void Paint (Context ctx);
		public abstract IPaintPrimitive Clone ();
		public abstract bool Contains (PointD point);
		public abstract void PaintContour (Context ctx);
		public abstract Rectangle GetBounds ();
		public virtual bool AcceptEdge (IEdge edge, ICollection<INode> othernodes, ref string message)
		{//doesn't accept find queries as children
			if (!othernodes.All (x => !typeof(FindQueryNode).IsAssignableFrom (x.GetType ()))) {
				message = string.Format("\"{0}\" doesn't accept search queries as children!",this.GetType().Name);
				return false;
			}
			return true;
		}
		#endregion

		#region INode implementation
		public abstract PointD GetLocationByAngle (double theta);

		public PointD GetLocationByOtherPoint (PointD other) {
			double dx= other.X-this.Location.X;
			double dy= other.Y-this.Location.Y;
			return GetLocationByAngle(Math.Atan2(dy,dx));
		}
		#endregion


	}
}

