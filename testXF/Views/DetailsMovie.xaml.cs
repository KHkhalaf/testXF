using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using testXF.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsMovie : ContentPage
    {
        public DetailsMovie(Models.DetailsMovie detailsMovie)
        {
            InitializeComponent();
            BindingContext = detailsMovie;
            videoElement.Source = GetYouTubeUrl("lBeepqQBpvU");
        }
        public string GetYouTubeUrl(string videoId)
        {
            var videoInfoUrl = $"https://www.youtube.com/get_video_info?video_id={videoId}";
            using (var client = new HttpClient())
            {
                var videoPageContent = client.GetStringAsync(videoInfoUrl).Result;
                var videoParameters = HttpUtility.ParseQueryString(videoPageContent);
                var encodedStreamsDelimited1 = WebUtility.HtmlDecode(videoParameters["player_response"]);
                JObject jObject = JObject.Parse(encodedStreamsDelimited1);
                string url = (string)jObject["streamingData"]["formats"][0]["url"];
                return url;
            }
        }
    }
}