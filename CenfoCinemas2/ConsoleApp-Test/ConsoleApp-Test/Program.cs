using System; // ya que uso console.write... y dateTime.Parse..

using DataAccess.DAO;


public class Program
{
    public static void Main(string[] args)
    {
        var sqlDao = SqlDao.getInstance();

        try
        {
            sqlDao.TestConnection();
            Console.WriteLine("Conexion exitosa");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de conexion: {ex.Message}");
            return;
        }

        int opcion = 0;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Crear Pelicula");
            Console.WriteLine("3. Crear Ticket");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearUsuario(sqlDao);
                    break;

                case 2:
                    CrearMovie(sqlDao);
                    break;

                case 3:
                    CrearTicket(sqlDao);
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opcion != 4);
    }

    static void CrearUsuario(SqlDao sqlDao)
    {
        var sqlOperation = new SqlOperation();

        Console.Write("Codigo usuario: ");
        var userCode = Console.ReadLine();

        Console.Write("Nombre: ");
        var name = Console.ReadLine();

        Console.Write("Correo: ");
        var email = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        Console.Write("Fecha nacimiento (MM/DD/YYYY): ");
        var dateBirth = DateTime.Parse(Console.ReadLine());

        Console.Write("Telefono: ");
        var phone = int.Parse(Console.ReadLine());

        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", password);
        sqlOperation.AddDateTimeParameter("P_DATE_BIRTH", dateBirth);
        sqlOperation.AddStringParameter("P_STATUS", "AC");
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario creado correctamente");
    }
    static void CrearMovie(SqlDao sqlDao)
    {
        var sqlOperation = new SqlOperation();

        Console.Write("Titulo: ");
        var title = Console.ReadLine();

        Console.Write("Sinopsis: ");
        var synopsis = Console.ReadLine();

        Console.Write("Genero: ");
        var gender = Console.ReadLine();

        Console.Write("Duracion (HH:mm:ss): ");
        var duration = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Clasificacion: ");
        var clasificacion = Console.ReadLine();

        Console.Write("Imagen: ");
        var image = Console.ReadLine();

        var status = "AC";

        sqlOperation.ProcedureName = "CRE_MOVIE_PR";

        sqlOperation.AddStringParameter("P_TITLE", title);
        sqlOperation.AddStringParameter("P_SYNOPSIS", synopsis);
        sqlOperation.AddStringParameter("P_GENDER", gender);
        sqlOperation.AddStringParameter("P_CLASIFICACION", clasificacion);
        sqlOperation.AddStringParameter("P_IMAGE", image);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Película creada correctamente");
    }

    static void CrearTicket(SqlDao sqlDao)
    {
        var sqlOperation = new SqlOperation();

        Console.Write("Precio: ");
        var price = decimal.Parse(Console.ReadLine());

        Console.Write("Horario (HH:mm:ss): ");
        var schedule = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Fecha (YYYY-MM-DD o completa): ");
        var date = DateTime.Parse(Console.ReadLine());

        Console.Write("Tipo (VIP / Normal): ");
        var type = Console.ReadLine();

        Console.Write("ID de la película: ");
        var movieId = int.Parse(Console.ReadLine());

        sqlOperation.ProcedureName = "CRE_TICKET_PR";

        sqlOperation.AddDecimalParameter("P_PRICE", price);
        sqlOperation.AddTimeParameter("P_SCHEDULE", schedule);
        sqlOperation.AddDateTimeParameter("P_DATE", date);
        sqlOperation.AddStringParameter("P_TYPE", type);
        sqlOperation.AddIntParameter("P_MOVIE_ID", movieId);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Ticket creado correctamente");
    }
}