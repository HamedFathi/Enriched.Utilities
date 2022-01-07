namespace System
{
    public struct Uuid : IEquatable<Uuid>
    {
        public readonly static Uuid Empty;
        static Uuid()
        {
            Empty = new Uuid();
        }
        private readonly long _leastSignificantBits;
        private readonly long _mostSignificantBits;
        public Uuid(long mostSignificantBits, long leastSignificantBits)
        {
            _mostSignificantBits = mostSignificantBits;
            _leastSignificantBits = leastSignificantBits;
        }
        public Uuid(byte[] b)
        {
            if (b == null)
                throw new ArgumentNullException("b");
            if (b.Length != 16)
                throw new ArgumentException("Length of the UUID byte array should be 16");
            _mostSignificantBits = BitConverter.ToInt64(b, 0);
            _leastSignificantBits = BitConverter.ToInt64(b, 8);
        }
        public long LeastSignificantBits
        {
            get { return _leastSignificantBits; }
        }
        public long MostSignificantBits
        {
            get { return _mostSignificantBits; }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Uuid))
            {
                return false;
            }
            Uuid uuid = (Uuid)obj;
            return Equals(uuid);
        }
        public bool Equals(Uuid uuid)
        {
            return _mostSignificantBits == uuid._mostSignificantBits && _leastSignificantBits == uuid._leastSignificantBits;
        }
        public override int GetHashCode()
        {
            return ((Guid)this).GetHashCode();
        }
        public override string ToString()
        {
            return GetDigits(_mostSignificantBits >> 32, 8) + "-" +
                GetDigits(_mostSignificantBits >> 16, 4) + "-" +
                GetDigits(_mostSignificantBits, 4) + "-" +
                GetDigits(_leastSignificantBits >> 48, 4) + "-" +
                GetDigits(_leastSignificantBits, 12);
        }
        public byte[] ToByteArray()
        {
            byte[] uuidMostSignificantBytes = BitConverter.GetBytes(_mostSignificantBits);
            byte[] uuidLeastSignificantBytes = BitConverter.GetBytes(_leastSignificantBits);
            byte[] bytes =
            {
                uuidMostSignificantBytes[0],
                uuidMostSignificantBytes[1],
                uuidMostSignificantBytes[2],
                uuidMostSignificantBytes[3],
                uuidMostSignificantBytes[4],
                uuidMostSignificantBytes[5],
                uuidMostSignificantBytes[6],
                uuidMostSignificantBytes[7],
                uuidLeastSignificantBytes[0],
                uuidLeastSignificantBytes[1],
                uuidLeastSignificantBytes[2],
                uuidLeastSignificantBytes[3],
                uuidLeastSignificantBytes[4],
                uuidLeastSignificantBytes[5],
                uuidLeastSignificantBytes[6],
                uuidLeastSignificantBytes[7]
            };
            return bytes;
        }
        public static bool operator ==(Uuid a, Uuid b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Uuid a, Uuid b)
        {
            return !a.Equals(b);
        }
        public static explicit operator Guid(Uuid uuid)
        {
            if (uuid == default)
            {
                return default;
            }
            byte[] uuidMostSignificantBytes = BitConverter.GetBytes(uuid._mostSignificantBits);
            byte[] uuidLeastSignificantBytes = BitConverter.GetBytes(uuid._leastSignificantBits);
            byte[] guidBytes =
            {
                uuidMostSignificantBytes[4],
                uuidMostSignificantBytes[5],
                uuidMostSignificantBytes[6],
                uuidMostSignificantBytes[7],
                uuidMostSignificantBytes[2],
                uuidMostSignificantBytes[3],
                uuidMostSignificantBytes[0],
                uuidMostSignificantBytes[1],
                uuidLeastSignificantBytes[7],
                uuidLeastSignificantBytes[6],
                uuidLeastSignificantBytes[5],
                uuidLeastSignificantBytes[4],
                uuidLeastSignificantBytes[3],
                uuidLeastSignificantBytes[2],
                uuidLeastSignificantBytes[1],
                uuidLeastSignificantBytes[0]
            };
            return new Guid(guidBytes);
        }
        public static implicit operator Uuid(Guid value)
        {
            if (value == default)
            {
                return default;
            }
            byte[] guidBytes = value.ToByteArray();
            byte[] uuidBytes =
            {
                guidBytes[6],
                guidBytes[7],
                guidBytes[4],
                guidBytes[5],
                guidBytes[0],
                guidBytes[1],
                guidBytes[2],
                guidBytes[3],
                guidBytes[15],
                guidBytes[14],
                guidBytes[13],
                guidBytes[12],
                guidBytes[11],
                guidBytes[10],
                guidBytes[9],
                guidBytes[8]
            };
            return new Uuid(BitConverter.ToInt64(uuidBytes, 0), BitConverter.ToInt64(uuidBytes, 8));
        }
        public static Uuid Parse(string input)
        {
            return Guid.Parse(input);
        }
        public static bool TryParse(string input, out Uuid uuid)
        {
            try
            {
                uuid = new Guid(input.Replace("-", ""));
                return true;
            }
            catch
            {
                uuid = Guid.Empty;
                return false;
            }
        }

        public static Guid ToGuid(string input)
        {
            return Guid.Parse(input);
        }
        public static Guid ToGuid(Uuid input)
        {
            return (Guid)input;
        }
        public static Uuid NewUuid()
        {
            return Guid.NewGuid();
        }
        private static string GetDigits(long val, int digits)
        {
            long hi = 1L << digits * 4;
            return string.Format("{0:X}", hi | val & hi - 1).Substring(1);
        }
    }
}