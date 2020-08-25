using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.SocketModels
{
    [SerializableAttribute]
    public class Message
    {
        public const string RELOAD_MEC_SUMMARY_MESSAGE = "RELOAD_MEC_SUMMARY_MESSAGE";

        public const string ALL_OTHER_USERS = "ALL_OTHER_USERS";
        public const string ALL_USERS = "ALL_USERS";

        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Content { get; set; }
    }
}
