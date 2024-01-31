namespace Ocean_Tec_Task.Shared
{
    public class CreateProductWithUnitsAndCharsRequest
    {
        public ProductDto ProductDto { get; set; }
        public UnitDto MainUnitDto { get; set; }
        public UnitDto MediumUnitDto { get; set; }
        public UnitDto SmallUnitDto { get; set; }
        public CharacteristicsDto CharacteristicsDto { get; set; }
    }

}
