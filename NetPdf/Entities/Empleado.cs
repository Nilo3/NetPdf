namespace NetPdf.entities
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string NombreCompleto { get; set; }

        public int Sueldo { get; set; }

        public int idPerfil { get; set; }
        public virtual Perfil PerfilReferencia { get; set; }

    }
}
