namespace Models.Entidades
{
    public class Persona
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string NumeroIdentificacion { get; set; }
        // Tipo de dato string
        public string Nombre { get; set; }

        // Tipo de dato int
        public int Edad { get; set; }

        // Tipo de dato DateTime
        public DateTime FechaNacimiento { get; set; }

        // Tipo de dato bool
        public bool EsEmpleado { get; set; }

        // Tipo de dato decimal
        public decimal Salario { get; set; }
    }
}
