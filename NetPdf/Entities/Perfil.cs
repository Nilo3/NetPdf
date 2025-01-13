namespace NetPdf.entities
{
    public class Perfil
    {
        public int idPerfil {  get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Empleado> EmpleadosReferencia { get; set; }
    }
}
