﻿using HtmlAgilityPack;
using ProHeroWeb.Models;

namespace ProHeroWeb.Data
{
    public static class CountryHungerStatus
    {
        private readonly static string url = "https://www.macrotrends.net/countries/ranking/hunger-statistics";

        /// <summary>
        /// Gives live data of hunger issues in each country 
        /// </summary>
        /// <returns></returns>
        public static List<CountryStatus> ResultStatus()
        {
            string response = CallUrl(url).Result;
            return ParseHtml(response);
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(fullUrl);
            return response;
        }

        private static List<CountryStatus> ParseHtml(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            List<CountryStatus> result = new List<CountryStatus>();

            foreach (var row in htmlDoc.DocumentNode.SelectNodes("//*[@id='country_ranking']//tr"))
            {
                var nodes = row.SelectNodes("td");
                if (nodes != null)
                {
                    string country = nodes[0].InnerText;
                    float twintyNineteen = float.Parse(nodes[1].InnerText.TrimEnd('%'));
                    float twintyEighteen = float.Parse(nodes[2].InnerText.TrimEnd('%'));
                    float twintySeventeen = float.Parse(nodes[3].InnerText.TrimEnd('%'));
                    float twintySixteen = float.Parse(nodes[4].InnerText.TrimEnd('%'));

                    CountryStatus countryStatus = new CountryStatus()
                    {
                        CountryName = country,
                        TwintyNineteen = twintyNineteen,
                        TwintyEighteen = twintyEighteen,
                        TwintySevenTeen = twintySeventeen,
                        TwintySixteen = twintySixteen,
                        Level = twintyNineteen >= 25.99 ? "Red" : "None"
                    };

                    result.Add(countryStatus);
                }
            }

            return result;
        }
    }
}