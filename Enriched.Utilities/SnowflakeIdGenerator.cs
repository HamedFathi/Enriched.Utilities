using System;

namespace Enriched.Utilities
{
    // We should keep the generator as a singleton, it means that we should only create the generator once. If not, it may generate some duplicate Ids.
    public class SnowflakeIdGenerator
    {
        public const long Twepoch = 1288834974000L;
        private const int WorkerIdBits = 5;
        private const int DatacenterIdBits = 5;
        private const int SequenceBits = 12;
        private const long MaxWorkerId = -1L ^ (-1L << WorkerIdBits);
        private const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);
        private const long SequenceMask = -1L ^ (-1L << SequenceBits);
        private const int WorkerIdShift = SequenceBits;
        private const int DatacenterIdShift = SequenceBits + WorkerIdBits;
        public const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
        private long _lastTimestamp = -1L;
        private readonly object _lock = new object();

        public long DatacenterId { get; protected set; }

        public long Sequence { get; internal set; } = 0L;

        public long WorkerId { get; protected set; }

        public SnowflakeIdGenerator(long workerId, long datacenterId, long sequence = 0L)
        {
            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new ArgumentException($"worker Id must greater than or equal 0 and less than or equal {MaxWorkerId}");
            }

            if (datacenterId > MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException($"datacenter Id must greater than or equal 0 and less than or equal {MaxDatacenterId}");
            }

            WorkerId = workerId;
            DatacenterId = datacenterId;
            Sequence = sequence;
        }

        public long NextId()
        {
            lock (_lock)
            {
                var timestamp = TimeGen();
                if (timestamp < _lastTimestamp)
                {
                    throw new Exception($"timestamp error");
                }

                if (_lastTimestamp == timestamp)
                {
                    Sequence = (Sequence + 1) & SequenceMask;

                    if (Sequence == 0)
                    {
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    Sequence = 0;
                }

                _lastTimestamp = timestamp;
                return ((timestamp - Twepoch) << TimestampLeftShift) | (DatacenterId << DatacenterIdShift) | (WorkerId << WorkerIdShift) | Sequence;
            }
        }

        private long TilNextMillis(long lastTimestamp)
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }

            return timestamp;
        }

        private long TimeGen()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}