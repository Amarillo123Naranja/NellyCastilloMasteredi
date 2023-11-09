namespace ML
{
    public class Emisor
    {

        public string IdEmisor { get; set; }

        public string? Rfc { get; set; }

        public DateTime FechaInicioOperacion { get; set; }

        public decimal? Capital { get; set; }

        public List<Object>? Emisoras { get; set; }

        public string Accion { get; set; }
    }
}