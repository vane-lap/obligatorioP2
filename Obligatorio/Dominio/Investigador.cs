using Dominio.Enums;
using Dominio.Interfaces;

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

        public Investigador(string email, string contrasena, string nombre, Rol rol)
        {
            _email = email;
            _contrasena = contrasena;
            _nombre = nombre;
            _rol = rol;
        }

        public Rol Rol { get {return _rol;}}
        public string Email { get { return _email; } }

        public void Validar()
        {
            if (!string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacío"); // sistema va a tener que tener una lista de investigadores para validar si hay otro investigador con mismo mail
            if (!string.IsNullOrEmpty(_contrasena)) throw new Exception("La contraseña no puede ser vacía");
            if (!string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío");
            if (!Enum.IsDefined(typeof(Rol), _rol)) throw new Exception("No existe rol de ese tipo");
        }

    }
}
