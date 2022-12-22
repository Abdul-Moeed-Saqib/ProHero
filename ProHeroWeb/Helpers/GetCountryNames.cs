using System.Globalization;

namespace ProHeroWeb.Helpers
{
    public static class GetCountryNames
    {
        public static List<string> GetCountries()
        {
            List<string> countries = new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var culture in getCultureInfo)
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);

                if (!countries.Contains(regionInfo.EnglishName))
                {
                    countries.Add(regionInfo.EnglishName);
                }
            }

            countries.Sort();

            return countries;
        }
    }
}
