namespace SmartHomeDashboard.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Ambiente { get; set; } = string.Empty;

        public string Protocolo { get; set; } = string.Empty;

        public string Fabricante { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public bool Online { get; set; }

        public bool Ligado { get; set; }

        public DateTime UltimaComunicacao { get; set; }
    }
}