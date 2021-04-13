//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Sensor
{
    public class MPointCloud : Message
    {
        public const string k_RosMessageName = "sensor_msgs/PointCloud";
        public override string RosMessageName => k_RosMessageName;

        //  This message holds a collection of 3d points, plus optional additional
        //  information about each point.
        //  Time of sensor data acquisition, coordinate frame ID.
        public MHeader header;
        //  Array of 3d points. Each Point32 should be interpreted as a 3d point
        //  in the frame given in the header.
        public Geometry.MPoint32[] points;
        //  Each channel should have the same number of elements as points array,
        //  and the data in each channel should correspond 1:1 with each point.
        //  Channel names in common practice are listed in ChannelFloat32.msg.
        public MChannelFloat32[] channels;

        public MPointCloud()
        {
            this.header = new MHeader();
            this.points = new Geometry.MPoint32[0];
            this.channels = new MChannelFloat32[0];
        }

        public MPointCloud(MHeader header, Geometry.MPoint32[] points, MChannelFloat32[] channels)
        {
            this.header = header;
            this.points = points;
            this.channels = channels;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(points.Length));
            foreach(var entry in points)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(channels.Length));
            foreach(var entry in channels)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            
            var pointsArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.points= new Geometry.MPoint32[pointsArrayLength];
            for(var i = 0; i < pointsArrayLength; i++)
            {
                this.points[i] = new Geometry.MPoint32();
                offset = this.points[i].Deserialize(data, offset);
            }
            
            var channelsArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.channels= new MChannelFloat32[channelsArrayLength];
            for(var i = 0; i < channelsArrayLength; i++)
            {
                this.channels[i] = new MChannelFloat32();
                offset = this.channels[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MPointCloud: " +
            "\nheader: " + header.ToString() +
            "\npoints: " + System.String.Join(", ", points.ToList()) +
            "\nchannels: " + System.String.Join(", ", channels.ToList());
        }
    }
}
