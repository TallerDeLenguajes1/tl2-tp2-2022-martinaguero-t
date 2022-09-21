namespace Punto4;
using NLog;

static class HelperDeArchivos{

    static public string obtenerRutaArchivo(Curso curso){
        switch (curso)
        {
            case Curso.Atletismo:
                return "Atletismo.csv";
            case Curso.Futbol:
                return "Futbol.csv";
            case Curso.Voley:
                return "Voley.csv";
            default:
                return "";
        }
    }
    static public void escribirEnArchivo(Curso curso, string contenido){

        Logger logger = LogManager.GetCurrentClassLogger();
        
        try
        {
            using(StreamWriter writer = new StreamWriter(obtenerRutaArchivo(curso),true)){
                writer.Write(contenido);
            }

        }
        catch (System.Exception ex)
        {
            throw;
        }

    }
    
    static public void  limpiarContenidoArchivo(string rutaArchivo){
        try
        {
            using(FileStream fs = new FileStream(rutaArchivo,FileMode.Truncate)){
                // Se vacía el contenido del archivo
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    static public void mostrarContenidoArchivo(string rutaArchivo){
        if(File.Exists(rutaArchivo)){

            using(StreamReader sr = new StreamReader(rutaArchivo)){

                var linea = sr.ReadLine();

                if(linea==null) Console.WriteLine("No hay información registrada.");

                while(linea!=null){
                    var datos = linea.Split(";");
                    Console.WriteLine($"ID: {datos[0]} | DNI : {datos[1]} | NOMBRE: {datos[3]}, {datos[2]}");
                    linea = sr.ReadLine();
                }

            }

        } else {
            Console.WriteLine("No hay información registrada.");
        }
    }
}
