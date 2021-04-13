//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Nav
{
    public class MSetMapResponse : Message
    {
        public const string k_RosMessageName = "nav_msgs/SetMap";
        public override string RosMessageName => k_RosMessageName;

        public bool success;

        public MSetMapResponse()
        {
            this.success = false;
        }

        public MSetMapResponse(bool success)
        {
            this.success = success;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.success));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.success = BitConverter.ToBoolean(data, offset);
            offset += 1;

            return offset;
        }

        public override string ToString()
        {
            return "MSetMapResponse: " +
            "\nsuccess: " + success.ToString();
        }
    }
}
