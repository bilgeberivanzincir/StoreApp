using System.Text.Json;

namespace StoreApp.Infrastructure.Extension
{
    public static class SessionExtension
    {
       public static void SetJson(this ISession session,string key,object value)
       {
         session.SetString(key,JsonSerializer.Serialize(value));
       }  // session verilerini json formatında saklamak için uzantı

       public static void SetJson<T>(this ISession session, string key, T value)
       {
        session.SetString(key,JsonSerializer.Serialize(value));
       } //generic version

       public static T? GetJson<T>(this ISession session,string key)
       {
            var data=session.GetString(key);
            return data is null 
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
       }
    }
}