using DataAccess.DAO;

public class Program
{
    public static void Main(string[] args)
    {
        var sqlDao = SqlDao.getInstance();

        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el codigo de usuario");
        var userCode = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre completo");
        var name = Console.ReadLine();

        Console.WriteLine("Ingrese el correo");
        var email = Console.ReadLine();

        Console.WriteLine("Ingrese la contrase;a");
        var password = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento *MM/DD/YYYY");
        var dateBirth = DateTime.Parse(Console.ReadLine());

        var status = "AC";

        Console.WriteLine("Ingrese el numero de telefono");
        var phone = int.Parse(Console.ReadLine());


        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", password);
        sqlOperation.AddDateTimeParameter("P_DATE_BIRTH", dateBirth);
        sqlOperation.AddStringParameter("P_STATUS", status);
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);

        sqlDao.ExecuteProcedure(sqlOperation);

    }
}