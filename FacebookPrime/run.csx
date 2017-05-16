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

    // log to make sure it works
    log.Info($"UserID: {fb_rq.fb_user_id} Token: {fb_rq.fb_access_token}");
    
    outItem = data;  

}

public class FacebookUserReq {
    
    public string fb_access_token {get;set;}
    public string fb_user_id {get;set;}

}