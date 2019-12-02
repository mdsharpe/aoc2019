namespace day2
{
    class Instruction
    {
        public Instruction(Opcode opcode, int posIn1, int posIn2, int posOut)
        {
            Opcode = opcode;
            PosIn1 = posIn1;
            PosIn2 = posIn2;
            PosOut = posOut;
        }

        public Opcode Opcode { get; }
        public int PosIn1 { get; }
        public int PosIn2 { get; }
        public int PosOut { get; }
    }
}
