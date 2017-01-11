using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMediaFramework.App.iOS
{

    public class VideoData
	{
        public string VideoUrl { get; set; }
        public string Title { get; set; }

        public string Summary { get; set; }

        public string AdTagUrl { get; set; }


        public VideoData(string videoUrl, string title, string summary, string adTagUrl)
        {
            VideoUrl = videoUrl;
            Title = title;
            Summary = summary;
            AdTagUrl = adTagUrl;
        }
	}
}
