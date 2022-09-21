namespace Punto4;

enum Curso
{
    Atletismo,
    Voley,
    Futbol

}
class Alumno{
    private int ID {get; set;}
    private string Nombre {get; set;}

    private string Apellido {get; set;}

    private int DNI {get; set;}

    public Curso CursoAlumno {get; set;}
    
    public Alumno (int ID, string Nombre, string Apellido, int DNI, Curso curso){
        if (string.IsNullOrEmpty(Apellido)) {
            throw new ArgumentNullException("El nombre debe ser no vacío");
        } else {
            this.Nombre = Nombre;
        }

        if (string.IsNullOrEmpty(Nombre)){
            throw new ArgumentNullException("El apellido debe ser no vacío");
        } else {
            this.Apellido = Apellido;
        }

        if(ID < 0) throw new ArgumentException("El ID debe ser un entero no negativo."); else this.ID = ID;
        if(DNI < 10000000 || DNI > 99999999) throw new ArgumentException("DNI inválido."); else this.DNI = DNI;

    }

    public string getInformacionAlumno(){
        return $"{this.ID};{this.DNI};{this.Nombre};{this.Apellido}";
    }

}