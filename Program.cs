using Microsoft.Win32.SafeHandles;

Console.WriteLine("Bienvenido a mi lista de Contactes");

bool runing = true;
List<Contact> contacts = new List<Contact>();


while (runing)
{
    Console.WriteLine("1. Agregar Contacto");
    Console.WriteLine("2. Ver Contactos");
    Console.WriteLine("3. Buscar Contactos");
    Console.WriteLine("4. Modificar Contacto");
    Console.WriteLine("5. Eliminar Contacto");
    Console.WriteLine("6. Salir");
    
    Console.WriteLine("Digite el número de la opción deseada");

    try
    {
        int option = Convert.ToInt32(Console.ReadLine());
    
    switch (option)
    {
        case 1:
            {
                    ContactHelper.AddContact(contacts);

            }
            break;
        case 2:
            {
                    ContactHelper.ShowContact(contacts);
            }
            break;
        case 3:
            {
                    ContactHelper.SearchContacts(contacts);
            }
            break;
        case 4:
            {
                    ContactHelper.ModifyContact(contacts);
            }
            break;
        case 5:
            {
                    ContactHelper.DeleteContact(contacts);
            }
            break;
        case 6:
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Gracias por usar mi lista de contactos, hasta luego!");
        Console.ResetColor();
            runing = false;
            break;
        default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Opción no válida.");
        Console.ResetColor();
            break;
       } 
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ocurrió un error: " + ex.Message);
        Console.ResetColor();
    }
}

Console.ReadKey();