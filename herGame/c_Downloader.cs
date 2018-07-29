using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herGame
{
	class c_Downloader
	{
		List<string> currentlyDownloading = new List<string>();
		List<string> alreadyDownloaded = new List<string>();

		public List<string> getList()
		{
			List<string> ret = new List<string>();

			string userAgent = c_Functions.getUserAgent();

			return ret;
		}

		public Bitmap getThumbnail()
		{
			return null;
		}

		public Bitmap getImage()
		{
			return null;
		}


	}
}
