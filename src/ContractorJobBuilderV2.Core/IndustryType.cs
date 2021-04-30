using Ardalis.SmartEnum;
using ContractorJobBuilderV2.Core.Entities.Aggregates;

namespace ContractorJobBuilderV2.Core
{
    public abstract class IndustryType : SmartEnum<IndustryType>
    {
        public static readonly IndustryType Carpentry = new CarpentryType();
        public static readonly IndustryType Plumbing = new PlumbingType();
        public static readonly IndustryType Electrical = new ElectricalType();

        private IndustryType(string name, int value): base(name, value)
        {
        }

        public abstract Industry Industry { get; }

        private sealed class CarpentryType : IndustryType
        {
            public CarpentryType() : base("Carpentry", 1) {}
            public override Industry Industry => Industry.Carpentry;
        }

        private sealed class PlumbingType : IndustryType
        {
            public PlumbingType() : base("Plumbing", 2) { }
            public override Industry Industry => Industry.Plumbing;
        }

        private sealed class ElectricalType : IndustryType
        {
            public ElectricalType() : base("Electrical", 3) { }
            public override Industry Industry => Industry.Electrical;
        }
    }
}
