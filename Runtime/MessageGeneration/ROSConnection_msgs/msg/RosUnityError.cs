using System;
using System.Collections.Generic;
using System.Text;
using RosMessageGeneration;

namespace RosMessageTypes.TcpEndpoint
{
    public class RosUnityError : Message
    {
        public const string RosMessageName = "tcp_endpoint/RosUnityError";

        public string message;

        public RosUnityError()
        {
            this.message = "";
        }

        public RosUnityError(string message)
        {
            this.message = message;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(SerializeString(this.message));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            var messageStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.message = DeserializeString(data, offset, messageStringBytesLength);
            offset += messageStringBytesLength;

            return offset;
        }

    }
}
