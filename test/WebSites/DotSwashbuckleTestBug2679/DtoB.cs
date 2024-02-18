namespace SwashbuckleTestBug2679 {
    public class DtoB {
        public Int64 Id { get; set; }
        public DtoA Ref { get; set; } = new DtoA();
    }
}