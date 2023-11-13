using System;

namespace WebCosmetic.Models
{
    public class PagingModel:IDisposable
    {
        // currentPage, totalPage, pagingUrl
        public int currentPage { get; set; }    
        public int totalPage { get; set; }
        public Func<int?,string> pagingUrl { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
