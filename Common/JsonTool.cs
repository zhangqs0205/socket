using Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class JsonTool
    {
        public static string SerializeMessage(Message messageObj)
        {
            return JsonConvert.SerializeObject(messageObj);
        }
        public static Message DeserializeMessage(string message)
        {
            return JsonConvert.DeserializeObject<Message>(message);
        }
    }
}
