using System; 

namespace eventhub_sender
{
    [Serializable()]
    public class SensorData
    {
        public DateTime Timestamp 
        {
            get { return DateTime.UtcNow; }
        }

        public string Name
        {
            get { return "sensor"; }
        }
        
        public int Value
        {
            get 
            {
                var rnd = new Random();
                return rnd.Next(1,10); 
            }
        }
    }
}