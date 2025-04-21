using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace PomoMeetApp.Classes
{
    internal class FirebaseConfig
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""pomomeet"",
          ""private_key_id"": ""2f8833b9f034dff7221ae9a968d096181bf47b64"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQC7WqVeb22nR3e5\nwSGpjbfM7bbWocKM6++HPhkHjDixhQbL+uXfBSCSb+wB6Tw9JZYz71GD4kzp4XMz\ns3ENIhMb//qZH33TMGMQKrrQeAV21AUW5/S+9ChYvyunhafaYQqX8FGzvbuyhv1k\nLIPnso1FvysH/Oqh5nRsdx8mRD0Bku2MAhkokzOmb8L3AdINF+sfWfMbJud77thN\n3mzXWol+NvtmPHyP5x9UaEq/ZoehGKcvZ2EZdr5OLqu5xsC9gwjXEimMGXeNvX7U\nM7wHo60ptqxUMs+Ix+aH7piYUJA0inHjyB282vK1ug5ibClkf1uBkk1p7WEfvzqU\nZkg4tLFxAgMBAAECggEABsKe0HFDWuOah5aXLRvKu8eBDy4Pi8+wmSfttcbCve8P\nn3kaZcl00yvcL3Z3wLoUOSQDxDc8cLz8j+tD40YtO9eo9nD7NI1cqbbs/jwycEb2\ntwygGWrMcOVXASiytY/GVtSqUgrA1NCHoJ91k/zumYtsFVH0MmrTHR3QPyx7qgyP\n8sxWvYnCTUf7XuuIFIulOvloTnWd2uxCCs8KYEXrOLLCtsKbSHzd73L2af6LX03H\nbwpLM1bFNQ1vmHZowFf2A+yJ6ImWtAwu5f82iMnYXze3hzHaAn4a/izhrgTPSVpB\n9pza682R6l3Bo3y2/Ubwgf4LTb3lk0qyajEDPitP1QKBgQD9GPz/HPhOwZr+EMfM\nxvGwuHclUV8bHpS0fYxjq7jhWxOhCvXDLFa56k2ilSSmEDkbxggqL1um/X28fClG\nl0iJ/M2biydu39V5sN64FJKrjFXpNehsFnM9T3UYhyjYqzp9/c3WGkcb5ZrIFnb2\nyM9x8vgl32Svof+Rk/x9NFdEDQKBgQC9gKf/LxYUmolMOxVZPu0C/RPCdnVMucqD\nnRsoH/0wOvTdwDfOn8P9IQq7HVosEBzRt4I1oMrJY7qUljIXJfZBRFp+rVgzwC/a\nrpCwRFN8USDrExlaZaAJS4qX69yii0iAwRvc4HlmnKCkDDXiM41LIXlLJ1lgvQW0\n+d8fkqmV9QKBgE60ophCzgTPt/8iAL/xbd9ivcphD45DaELod+vWzttlkykVW2+i\nLiYKcrIIZyktClVUs91KdNntIlim078b9HbUoquoDk8wVBZPpjLgUuv97Allti1G\nnfeG6gcCoPUf6kSb1JKsAUjvkb5/HeeIctogkIJWgd0MJ4mB15an3CtRAoGAHA0A\nUSjCJvidHDiet2A2KzwVAbMRN/NEg+jsjSr3Cn2fo3eBi0dg9oY+lWYJ4/3aljyI\nvLF5cwgdJUN6VKzc39pjXt7/8GEhdEhkyILErOFBcyqXlSb34ohZEpXqSfE+ITj0\ni+R6c/L5YG8iRsKExrtEvhgsBcLVJm3aVk0aZ0UCgYA9TT9LrgBXAJk6S1eSgDEw\nnUThuVnsTbl8wGY+f/4qI6IQhdB7Ku2WsbumzJTwSkh1UKCbHgs3KJPxhuOix+xO\nXzgjGQKyY4zjdfWnTR3zhnbkEZH+KmQzyYkDC1oVQhlLhbupC83Dxs6MwplfYiXe\n3vWdAp+e5YCddtAKeil6OQ==\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-fbsvc@pomomeet.iam.gserviceaccount.com"",
          ""client_id"": ""115473271361194920384"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-fbsvc%40pomomeet.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";
        static string filepath = "";
        public static FirestoreDb? database {  get; private set; }

        public static void SetEnviromentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            database = FirestoreDb.Create("pomomeet");

            //File.Delete(filepath);
        }
        public static string StorageBucket = "pomomeet.appspot.com";
    }
}
