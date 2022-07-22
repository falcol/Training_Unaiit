using System;

namespace App.Models
{
    public class PagingModel
    {
        public int CurrentPage { get; set; }
        public int CountPages { get; set; }

        public Func<int?, string> GenerateUrl { get; set; } = default!;
    }
}
