//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geometry
{
    public class MVector3 : Message
    {
        public const string k_RosMessageName = "geometry_msgs/Vector3";
        public override string RosMessageName => k_RosMessageName;

        //  This represents a vector in free space. 
        //  It is only meant to represent a direction. Therefore, it does not
        //  make sense to apply a translation to it (e.g., when applying a 
        //  generic rigid transformation to a Vector3, tf2 will only apply the
        //  rotation). If you want your data to be translatable too, use the
        //  geometry_msgs/Point message instead.
        public double x;
        public double y;
        public double z;

        public MVector3()
        {
            this.x = 0.0;
            this.y = 0.0;
            this.z = 0.0;
        }

        public MVector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.x));
            listOfSerializations.Add(BitConverter.GetBytes(this.y));
            listOfSerializations.Add(BitConverter.GetBytes(this.z));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.x = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.y = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.z = BitConverter.ToDouble(data, offset);
            offset += 8;

            return offset;
        }

        public override string ToString()
        {
            return "MVector3: " +
            "\nx: " + x.ToString() +
            "\ny: " + y.ToString() +
            "\nz: " + z.ToString();
        }
    }
}
