using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nefe.Domain
{
    public class Address : Entity
    {
        public byte CountryId { get; set; }
        public Country Country { get; set; }
        public short ProvinceId { get; set; }
        public Province Province { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string AddressDesc { get; set; }
        public AddressType AddressType { get; set; }
    }

    public class AddressBase
    {
        public string Name { get; set; }
    }

    public class Country : AddressBase
    {
        public byte CountryId { get; set; }
    }

    public class Province : AddressBase
    {
        public short ProvinceId { get; set; }
    }

    public class District : AddressBase
    {
        public int DistrictId { get; set; }
    }

    public enum AddressType
    {
        Home = 1,
        Bill = 2
    }
}
