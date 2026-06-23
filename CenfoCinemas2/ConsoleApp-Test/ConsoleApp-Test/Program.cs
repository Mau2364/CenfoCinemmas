using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOS;
using System; // ya que uso console.write... y dateTime.Parse..
using System.Net.Sockets;
using System.Text.Json.Serialization;

using System.Text.Json;


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
            Console.WriteLine("4. Listar Usuarios");
            Console.WriteLine("5. Salir");
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
                    LstUsers();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opcion != 5);
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

        /*  sqlOperation.AddStringParameter("P_USER_CODE", userCode);
          sqlOperation.AddStringParameter("P_NAME", name);
          sqlOperation.AddStringParameter("P_EMAIL", email);
          sqlOperation.AddStringParameter("P_PASSWORD", password);
          sqlOperation.AddDateTimeParameter("P_DATE_BIRTH", dateBirth);
          sqlOperation.AddStringParameter("P_STATUS", "AC");
          sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);

          sqlDao.ExecuteProcedure(sqlOperation); */

        var userDTO = new User();
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = password;
        userDTO.DateBirth = dateBirth;
        userDTO.Status = "AC";
        userDTO.PhoneNumber = phone;

        var uCrud = new UserCrudFactory();
        uCrud.Create(userDTO);

        Console.WriteLine("Usuario creado correctamente");
    }
    static void CrearMovie(SqlDao sqlDao)
    {
     
        Console.Write("Titulo: ");
        var title = Console.ReadLine();

        Console.Write("Sinopsis: ");
        var synopsis = Console.ReadLine();

        Console.Write("Genero: ");
        var gender = Console.ReadLine();


        Console.Write("Clasificacion: ");
        var clasificacion = Console.ReadLine();

        Console.Write("Imagen: ");
        var image = Console.ReadLine();
        var status = "AC";

        var movieDTO = new Movie();

        movieDTO.Title = title;
        movieDTO.Synopsis = synopsis;
        movieDTO.Gender = gender;
        movieDTO.Clasificacion = clasificacion;
        movieDTO.Image = image;
        movieDTO.Status = "AC";

        var mCrud = new MovieCrudFactory();
        mCrud.Create(movieDTO);

        Console.WriteLine("Película creada correctamente");
    }

    static void CrearTicket(SqlDao sqlDao)
    {
   

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

        var ticketDTO = new Ticket();

        ticketDTO.Price = (double)price;
        ticketDTO.Schedule = schedule;
        ticketDTO.Date = date;
        ticketDTO.Type = type;

        ticketDTO.Movie = new Movie();
        ticketDTO.Movie.Id = movieId;

        var tCrud = new TicketCrudFactory();
        tCrud.Create(ticketDTO);

        Console.WriteLine("Ticket creado correctamente");
    }
    static void LstUsers()
    {
        Console.WriteLine("Listado de usuarios del aplicativo ");

        var uCrud= new UserCrudFactory();
        var lstUsers = uCrud.RetrieveAll<User>();

        foreach (var user in lstUsers)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Código: {user.UserCode}");
            Console.WriteLine($"Nombre: {user.Name}");
            Console.WriteLine($"Correo: {user.Email}");
            Console.WriteLine($"Estado: {user.Status}");
            Console.WriteLine($"Fecha Nacimiento: {user.DateBirth}");
            Console.WriteLine($"Teléfono: {user.PhoneNumber}");
        }
    }
}