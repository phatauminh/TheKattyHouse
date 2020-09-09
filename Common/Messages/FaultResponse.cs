using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Common.Messages
{
    [DataContract]
    public class FaultResponse : IEquatable<FaultResponse>
    {
        public static FaultResponse NoFault = new FaultResponse(0, "NoFault");

        public static FaultResponse NoProductFoundError(int productId)
        {
            return new FaultResponse(1001, string.Format("No ProductId {0} Found ", productId));
        }

        public FaultResponse()
        {
        }
        public FaultResponse(int code, string description)
        {
            Code = code;
            CodeDescription = description;
        }

        [DataMember(IsRequired = false)]
        public int Code { get; set; }

        [DataMember(IsRequired = false)]
        public string CodeDescription { get; set; }

        public static implicit operator int(FaultResponse item)
        {
            return item.Code;
        }

        public static bool operator !=(FaultResponse left, FaultResponse right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(FaultResponse left, FaultResponse right)
        {
            return Equals(left, right);
        }

        public bool Equals(FaultResponse other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return other.Code == Code;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj is FaultResponse && Equals((FaultResponse)obj);
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public override string ToString()
        {
            return CodeDescription.ToString(CultureInfo.InvariantCulture);
        }
    }
}
