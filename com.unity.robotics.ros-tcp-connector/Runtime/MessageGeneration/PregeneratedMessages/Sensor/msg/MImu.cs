//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Sensor
{
    public class MImu : Message
    {
        public const string k_RosMessageName = "sensor_msgs/Imu";
        public override string RosMessageName => k_RosMessageName;

        //  This is a message to hold data from an IMU (Inertial Measurement Unit)
        // 
        //  Accelerations should be in m/s^2 (not in g's), and rotational velocity should be in rad/sec
        // 
        //  If the covariance of the measurement is known, it should be filled in (if all you know is the 
        //  variance of each measurement, e.g. from the datasheet, just put those along the diagonal)
        //  A covariance matrix of all zeros will be interpreted as "covariance unknown", and to use the
        //  data a covariance will have to be assumed or gotten from some other source
        // 
        //  If you have no estimate for one of the data elements (e.g. your IMU doesn't produce an orientation 
        //  estimate), please set element 0 of the associated covariance matrix to -1
        //  If you are interpreting this message, please check for a value of -1 in the first element of each 
        //  covariance matrix, and disregard the associated estimate.
        public MHeader header;
        public Geometry.MQuaternion orientation;
        public double[] orientation_covariance;
        //  Row major about x, y, z axes
        public Geometry.MVector3 angular_velocity;
        public double[] angular_velocity_covariance;
        //  Row major about x, y, z axes
        public Geometry.MVector3 linear_acceleration;
        public double[] linear_acceleration_covariance;
        //  Row major x, y z 

        public MImu()
        {
            this.header = new MHeader();
            this.orientation = new Geometry.MQuaternion();
            this.orientation_covariance = new double[9];
            this.angular_velocity = new Geometry.MVector3();
            this.angular_velocity_covariance = new double[9];
            this.linear_acceleration = new Geometry.MVector3();
            this.linear_acceleration_covariance = new double[9];
        }

        public MImu(MHeader header, Geometry.MQuaternion orientation, double[] orientation_covariance, Geometry.MVector3 angular_velocity, double[] angular_velocity_covariance, Geometry.MVector3 linear_acceleration, double[] linear_acceleration_covariance)
        {
            this.header = header;
            this.orientation = orientation;
            this.orientation_covariance = orientation_covariance;
            this.angular_velocity = angular_velocity;
            this.angular_velocity_covariance = angular_velocity_covariance;
            this.linear_acceleration = linear_acceleration;
            this.linear_acceleration_covariance = linear_acceleration_covariance;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(orientation.SerializationStatements());
            
            Array.Resize(ref orientation_covariance, 9);
            foreach(var entry in orientation_covariance)
                listOfSerializations.Add(BitConverter.GetBytes(entry));
            listOfSerializations.AddRange(angular_velocity.SerializationStatements());
            
            Array.Resize(ref angular_velocity_covariance, 9);
            foreach(var entry in angular_velocity_covariance)
                listOfSerializations.Add(BitConverter.GetBytes(entry));
            listOfSerializations.AddRange(linear_acceleration.SerializationStatements());
            
            Array.Resize(ref linear_acceleration_covariance, 9);
            foreach(var entry in linear_acceleration_covariance)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.orientation.Deserialize(data, offset);
            
            this.orientation_covariance= new double[9];
            for(var i = 0; i < 9; i++)
            {
                this.orientation_covariance[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }
            offset = this.angular_velocity.Deserialize(data, offset);
            
            this.angular_velocity_covariance= new double[9];
            for(var i = 0; i < 9; i++)
            {
                this.angular_velocity_covariance[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }
            offset = this.linear_acceleration.Deserialize(data, offset);
            
            this.linear_acceleration_covariance= new double[9];
            for(var i = 0; i < 9; i++)
            {
                this.linear_acceleration_covariance[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MImu: " +
            "\nheader: " + header.ToString() +
            "\norientation: " + orientation.ToString() +
            "\norientation_covariance: " + System.String.Join(", ", orientation_covariance.ToList()) +
            "\nangular_velocity: " + angular_velocity.ToString() +
            "\nangular_velocity_covariance: " + System.String.Join(", ", angular_velocity_covariance.ToList()) +
            "\nlinear_acceleration: " + linear_acceleration.ToString() +
            "\nlinear_acceleration_covariance: " + System.String.Join(", ", linear_acceleration_covariance.ToList());
        }
    }
}
