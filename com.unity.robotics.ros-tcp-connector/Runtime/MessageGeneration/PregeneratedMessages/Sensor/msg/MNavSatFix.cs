//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Sensor
{
    public class MNavSatFix : Message
    {
        public const string k_RosMessageName = "sensor_msgs/NavSatFix";
        public override string RosMessageName => k_RosMessageName;

        //  Navigation Satellite fix for any Global Navigation Satellite System
        // 
        //  Specified using the WGS 84 reference ellipsoid
        //  header.stamp specifies the ROS time for this measurement (the
        //         corresponding satellite time may be reported using the
        //         sensor_msgs/TimeReference message).
        // 
        //  header.frame_id is the frame of reference reported by the satellite
        //         receiver, usually the location of the antenna.  This is a
        //         Euclidean frame relative to the vehicle, not a reference
        //         ellipsoid.
        public MHeader header;
        //  satellite fix status information
        public MNavSatStatus status;
        //  Latitude [degrees]. Positive is north of equator; negative is south.
        public double latitude;
        //  Longitude [degrees]. Positive is east of prime meridian; negative is west.
        public double longitude;
        //  Altitude [m]. Positive is above the WGS 84 ellipsoid
        //  (quiet NaN if no altitude is available).
        public double altitude;
        //  Position covariance [m^2] defined relative to a tangential plane
        //  through the reported position. The components are East, North, and
        //  Up (ENU), in row-major order.
        // 
        //  Beware: this coordinate system exhibits singularities at the poles.
        public double[] position_covariance;
        //  If the covariance of the fix is known, fill it in completely. If the
        //  GPS receiver provides the variance of each measurement, put them
        //  along the diagonal. If only Dilution of Precision is available,
        //  estimate an approximate covariance from that.
        public const byte COVARIANCE_TYPE_UNKNOWN = 0;
        public const byte COVARIANCE_TYPE_APPROXIMATED = 1;
        public const byte COVARIANCE_TYPE_DIAGONAL_KNOWN = 2;
        public const byte COVARIANCE_TYPE_KNOWN = 3;
        public byte position_covariance_type;

        public MNavSatFix()
        {
            this.header = new MHeader();
            this.status = new MNavSatStatus();
            this.latitude = 0.0;
            this.longitude = 0.0;
            this.altitude = 0.0;
            this.position_covariance = new double[9];
            this.position_covariance_type = 0;
        }

        public MNavSatFix(MHeader header, MNavSatStatus status, double latitude, double longitude, double altitude, double[] position_covariance, byte position_covariance_type)
        {
            this.header = header;
            this.status = status;
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.position_covariance = position_covariance;
            this.position_covariance_type = position_covariance_type;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(status.SerializationStatements());
            listOfSerializations.Add(BitConverter.GetBytes(this.latitude));
            listOfSerializations.Add(BitConverter.GetBytes(this.longitude));
            listOfSerializations.Add(BitConverter.GetBytes(this.altitude));
            
            Array.Resize(ref position_covariance, 9);
            foreach(var entry in position_covariance)
                listOfSerializations.Add(BitConverter.GetBytes(entry));
            listOfSerializations.Add(new[]{this.position_covariance_type});

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.status.Deserialize(data, offset);
            this.latitude = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.longitude = BitConverter.ToDouble(data, offset);
            offset += 8;
            this.altitude = BitConverter.ToDouble(data, offset);
            offset += 8;
            
            this.position_covariance= new double[9];
            for(var i = 0; i < 9; i++)
            {
                this.position_covariance[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }
            this.position_covariance_type = data[offset];;
            offset += 1;

            return offset;
        }

        public override string ToString()
        {
            return "MNavSatFix: " +
            "\nheader: " + header.ToString() +
            "\nstatus: " + status.ToString() +
            "\nlatitude: " + latitude.ToString() +
            "\nlongitude: " + longitude.ToString() +
            "\naltitude: " + altitude.ToString() +
            "\nposition_covariance: " + System.String.Join(", ", position_covariance.ToList()) +
            "\nposition_covariance_type: " + position_covariance_type.ToString();
        }
    }
}
