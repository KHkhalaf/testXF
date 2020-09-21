using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Extended;

namespace testXF.Models
{
    public class Page
    {
        public int Number { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public InfiniteScrollCollection<Movie> results { get; set; }
    }
}
