public class MondayDriverActivityLog
{
   public string Id { get; set; }   
   public string User_id { get; set; }
   public string EventType { get; set; }
   public string CreatedAt { get; set; }

   public MondayDriverActivityLog(string id, string user_id, string eventType, string created_at)
   {
       Id = id;
       User_id = user_id;
       EventType = eventType;
       CreatedAt = created_at;
   }

   public static MondayDriverActivityLog Create(string id, string user_id, string eventType, string created_at)
   {
       return new MondayDriverActivityLog(id, user_id, eventType, created_at);
   }
}