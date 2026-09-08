namespace Dominio
{
    public class Investigador : IValidable
    {
        #region ATRIBUTOS
        private string _email;
        private string _contrasena;
        private string _nombre;
        private Rol _rol;
        #endregion

        #region METODOS

        #endregion

        #region CONSTRUCTOR

        public void Investigador(string email, string contrasena, string nombre, Rol rol)
        {
            _email = email;
            _contrasena = contrasena;
            _nombre = nombre;
            _rol = rol;
        }
        #endregion
    }
}
