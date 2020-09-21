using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testXF.Data;
using testXF.Models;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace testXF.Services
{
    public class MovieServices
    {
        private const string Fullurl = "https://api.themoviedb.org/3/search/movie?api_key=1b7379446c64c65ef9206621be4e08e3&language=en-US&query=REEL&page=";
        public async Task<InfiniteScrollCollection<Movie>> GetMoviesByPageNumberAsync(int pageNumber)
        {
            try
            {
                RestClient<Models.Page> restClient = new RestClient<Models.Page>(Fullurl + pageNumber);
                var res = await restClient.GetAsync();
                return res.results;
            }
            catch (Exception ex)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
            return null;
        }
        public async Task<InfiniteScrollCollection<Movie>> GetMoviesAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2000);

            RestClient<Models.Page> restClient = new RestClient<Models.Page>(Fullurl + pageIndex);

            try
            {
                var res = await restClient.GetAsync();
                InfiniteScrollCollection<Movie> InfiniteList = new InfiniteScrollCollection<Movie>();
                InfiniteList.AddRange(res.results);
                return InfiniteList;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<DetailsMovie> GetMovieByIdAsync(int? MovieId)
        {
            string urlById = $"https://api.themoviedb.org/3/movie/{MovieId}?api_key=1b7379446c64c65ef9206621be4e08e3&language=en-US";

            try
            {
                RestClient<DetailsMovie> restClient = new RestClient<DetailsMovie>(urlById);
                var res = await restClient.GetAsync();
                return res;
            }
            catch (Exception ex)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
            return null;
        }
    }
}
