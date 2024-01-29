namespace Shabstec.BaggageSystem.Web.Models
{
    public class AirlineInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        //public bool Selected { get; set; }
    } 
    public class MessageModel
    {
        public string EventData { get; set; }
        public string Topic { get; set; }
        public string Subscription { get; set; }
    }

}
