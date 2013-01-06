using System;
using System.Collections.Generic;
using Cairo;
using Gdk;

namespace DSLImplementation.UserInterface {

	public static class ImageLoader {

		private static readonly Dictionary<string,ImageSurface> loadedSurfaces = new Dictionary<string,ImageSurface>();
		private static readonly Dictionary<string,Pixbuf> loadedPixbufs = new Dictionary<string, Pixbuf>();

		public static ImageSurface LoadSurface (string name)
		{
			ImageSurface imsu;
			if (!loadedSurfaces.TryGetValue (name, out imsu)) {
				imsu = new ImageSurface(name);
				loadedSurfaces.Add(name,imsu);
			}
			return imsu;
		}

		public static Pixbuf LoadPixbuf (string name) {
			Pixbuf pb;
			if(!loadedPixbufs.TryGetValue(name,out pb)) {
				pb = new Pixbuf(name);
				loadedPixbufs.Add(name,pb);
			}
			return pb;
		}

	}
}

