using NLog;
namespace Punto4;
class Program {

    static int Main(string[] args){

        Logger logger = LogManager.GetCurrentClassLogger();

        int opcionMenu = 0;

        do
        {
            Console.WriteLine("==> INSTITUTO DE EDUCACIÓN FÍSICA");
            Console.WriteLine("1) Cargar información de un alumno");
            Console.WriteLine("2) Mostrar listado de alumnos");
            Console.WriteLine("3) Eliminar información de alumnos de un curso");
            Console.WriteLine("4) Salir");
                
            do
            {
                Console.Write("Indique la operación: ");
                Int32.TryParse(Console.ReadLine(), out opcionMenu);
            } while (opcionMenu < 1 || opcionMenu > 4);

            switch (opcionMenu)
            {
                case 1:
                    bool cargado;
                    do
                    {
                        cargado = cargarInformacionAlumno();
                    } while (!cargado);
                    logger.Debug("Se cargó la información del alumno.");
                    logger.Info("Se cargó la información de un alumno.");
                    break;
                case 2:
                    mostrarListadoAlumnos();
                    break;
                case 3:
                    int curso = 0;
                    do
                    {
                        Console.WriteLine("¿De qué curso desea eliminar la información?");
                        Console.WriteLine("1) Atletismo \n2) Voley \n3) Futbol");
                        int.TryParse(Console.ReadLine(),out curso);
                    } while (curso < 1 || curso > 3);
                    eliminarInformacionCurso((Curso) curso-1);
                    break;                
            }

        } while (opcionMenu != 4);

        return 0;

    }

    static bool cargarInformacionAlumno(){

        Logger logger = LogManager.GetCurrentClassLogger();

        string Nombre, Apellido;
        int DNI, ID, cursoAlumno;
        
        Console.WriteLine("-> Ingrese la información del alumno: ");

        Console.Write("Nombre: ");
        Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        Apellido = Console.ReadLine();

        Console.Write("DNI: ");
        Int32.TryParse(Console.ReadLine(), out DNI);

        Console.Write("ID: ");
        Int32.TryParse(Console.ReadLine(), out ID);

        Console.WriteLine("Curso: \n1) Atletismo \n2) Voley \n3) Futbol");

        do
        {
            Console.Write("Elija el curso: ");
            Int32.TryParse(Console.ReadLine(), out cursoAlumno);
        } while (cursoAlumno < 1|| cursoAlumno > 3);

        try
        {   
            Curso curso = (Curso) cursoAlumno-1;
            Alumno nuevoAlumno = new Alumno(ID,Nombre,Apellido,DNI,curso);
            HelperDeArchivos.escribirEnArchivo(curso,nuevoAlumno.getInformacionAlumno()+"\n");
        }
        catch (ArgumentNullException ex)
        {
            logger.Debug(ex.Message);
            logger.Warn(ex.Message);

            return false;
            
        }
        catch (ArgumentException ex2)
        {
            logger.Debug(ex2.Message);
            logger.Warn(ex2.Message);

            return false;
        } 
        catch (Exception ex3)
        {
            logger.Debug(ex3.Message);
            logger.Warn(ex3.Message);

            return false;
        }
        
        return true;
    }

    static void mostrarListadoAlumnos(){
        var cursos = Enum.GetNames(typeof(Curso));
        int numCurso = 0;
        foreach (var curso in cursos)
        {
            Console.WriteLine($"--> CURSO: {curso}");
            HelperDeArchivos.mostrarContenidoArchivo(HelperDeArchivos.obtenerRutaArchivo((Curso)numCurso));
            numCurso++;
        }
    }

    static void eliminarInformacionCurso(Curso curso){
        Logger logger = LogManager.GetCurrentClassLogger();
        try
        {
            HelperDeArchivos.limpiarContenidoArchivo(HelperDeArchivos.obtenerRutaArchivo(curso));
            logger.Debug("Se eliminó la información del curso.");
            logger.Info($"Se eliminó la información del curso {curso}.");
        }
        catch (System.Exception)
        {
            logger.Debug("No se pudo eliminar la información del curso.");
            logger.Warn($"No se pudo eliminar información del curso {curso}.");
        }
    }
    
}