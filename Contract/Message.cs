using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contract
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public string Receiver { get; set; }

        [DataMember]
        public string TextMessage { get; set; }

        [DataMember]
        public Bitmap ImageMessage { get; set; }

    }
}
