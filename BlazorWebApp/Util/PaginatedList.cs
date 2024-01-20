using System;
using System.Collections.Generic;

namespace BlazorWebApp.Util
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }

        public PaginatedList()
        {

        }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items = new List<T>();
            Items.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }

        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }

        }
    }

}
