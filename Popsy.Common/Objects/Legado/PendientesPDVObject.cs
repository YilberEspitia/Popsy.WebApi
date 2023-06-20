namespace Popsy.Objects
{
    public class PendientesPDVObject
    {
        public Int32 PendientesPedidos { get; set; }
        public Int32 PendientesInventarios { get; set; }
        public Int32 PendientesRecepciones { get; set; }

        public PendientesPDVObject()
        {
            PendientesPedidos = 0;
            PendientesInventarios = 0;
            PendientesRecepciones = 0;
        }
    }
}
