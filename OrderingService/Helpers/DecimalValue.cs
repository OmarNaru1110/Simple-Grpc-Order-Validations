namespace OrderingService.Protos
{
    //https://itnext.io/net-decimal-datatype-in-grpc-51c2ddb1c153
    public partial class DecimalValue
    {
        private const decimal NanoFactor = 1_000_000_000;
        public DecimalValue(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }



        public static implicit operator decimal(DecimalValue grpcDecimal)
        {
            /*
                grpcDecimal = new DecimalValue(10,500);
                decimal salary = grpcDecimal;
            */
            return grpcDecimal.Units + grpcDecimal.Nanos / NanoFactor;
        }

        public static implicit operator DecimalValue(decimal value)
        {
            /*
                decimal salary = 10000m;
                DecimalValue grpcDecimal = salary;
            */
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalValue(units, nanos);
        }
    }

}
