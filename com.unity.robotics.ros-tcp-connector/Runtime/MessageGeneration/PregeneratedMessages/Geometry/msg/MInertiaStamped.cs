//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Geometry
{
    public class MInertiaStamped : Message
    {
        public const string k_RosMessageName = "geometry_msgs/InertiaStamped";
        public override string RosMessageName => k_RosMessageName;

        public MHeader header;
        public MInertia inertia;

        public MInertiaStamped()
        {
            this.header = new MHeader();
            this.inertia = new MInertia();
        }

        public MInertiaStamped(MHeader header, MInertia inertia)
        {
            this.header = header;
            this.inertia = inertia;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(inertia.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.inertia.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "MInertiaStamped: " +
            "\nheader: " + header.ToString() +
            "\ninertia: " + inertia.ToString();
        }
    }
}
