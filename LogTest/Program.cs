using NLog;

class Program {

    static int Main(string[] args){

        Logger logger = LogManager.GetCurrentClassLogger();
        
        logger.Info("Prueba log info");
        logger.Debug("Prueba log debug");

        return 0;
    }

}