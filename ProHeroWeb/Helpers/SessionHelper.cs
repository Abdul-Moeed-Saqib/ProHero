﻿using Newtonsoft.Json;

namespace ProHeroWeb.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string? value = session.GetString(key);
            return value != null ? JsonConvert.DeserializeObject<T>(value) : default;
        }
    }
}
