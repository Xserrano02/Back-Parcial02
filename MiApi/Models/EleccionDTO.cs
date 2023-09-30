namespace MiApi.Models
{
    public class EleccionDTO
    {
        public string Candidato { get; set; }
        public int CantidadDeVotos { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class Eleccion
    {
        public int Id { get; set; } // Debes ajustar los tipos de datos según tu esquema de base de datos
        public string Departamento { get; set; }
        public string Candidato { get; set; }
        public int Votos { get; set; }
    }

}
