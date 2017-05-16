#r "Newtonsoft.Json"

using System.Net;
using Newtonsoft.Json;

public static void Run(HttpRequestMessage req, TraceWriter log, out string outItem)
{
    log.Info("C# HTTP trigger function processed a request.");

    // grab the data sent in
    string data = req.Content.ReadAsStringAsync().Result;
    FacebookUserReq fb_rq = new FacebookUserReq();
    fb_rq = JsonConvert.DeserializeObject<FacebookUserReq>(data);
    JsonConvert.
    // log to make sure it works
    log.Info($"UserID: {fb_rq.fb_user_id} Token: {fb_rq.fb_access_token}");

    // lets go out to facebook and grab everything
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://graph.facebook.com/" + fb_rq.fb_user_id + "?fields=email,first_name,last_name,birthday,locale,location,picture.width(500),about,education,friends,hometown,photos,relationship_status,religion,political,tagged_places,work");
    request.Method = "GET";
    request.Headers.Add("Authorization", "OAuth " + fb_rq.fb_access_token );
    String fb_resp = String.Empty;
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        fb_resp = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
    }
    //log.Info(fb_resp);

    outItem = fb_resp;  

}

public class FacebookUserReq {
    
    public string fb_access_token {get;set;}
    public string fb_user_id {get;set;}

}