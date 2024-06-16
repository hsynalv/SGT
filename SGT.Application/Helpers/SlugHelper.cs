using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGT.Application.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            var slug = title.ToLower();
            slug = Regex.Replace(slug, @"\s+", "-");  // Boşlukları tire ile değiştir
            slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");  // Alfanumerik olmayan karakterleri kaldır
            slug = slug.Trim('-');  // Baş ve sondaki tireleri kaldır

            return slug;
        }
    }
}
