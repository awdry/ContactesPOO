public static class ContactHelper
{
    public static void AddContact(List<Contact> contacts)
    {
        try
        {
            int id = contacts.Count + 1;

    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine() ?? "";
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine() ?? "";
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine() ?? "";
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
    Console.ResetColor();
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    Contact contact = new Contact(id, name, lastname, address, phone, email, age, isBestFriend);
    contacts.Add(contact);
    
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Contacto agregado exitosamente.");
    Console.ResetColor();
        }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrió un error al agregar el contacto: " + ex.Message);
                Console.ResetColor();
            }
}

public static void ShowContact(List<Contact> contacts)
    {
        try
        {
                if (contacts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No hay contactos para mostrar.");
                Console.ResetColor();
                return;
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine("\n============================\n");
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"Nombre: {contact.Name}");
                Console.WriteLine($"Apellido: {contact.LastName}");
                Console.WriteLine($"Dirección: {contact.Address}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Edad: {contact.Age}");
                Console.WriteLine($"Mejor Amigo: {(contact.IsBestFriend ? "Sí" : "No")}");
                Console.WriteLine("-----------------------------");
            }
        }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ocurrió un error al mostrar los contactos: " + ex.Message);
        Console.ResetColor();

    }
    }

public static void SearchContacts(List<Contact> contacts)
{
    try
    {
        Console.WriteLine("\n============================\n");
        Console.WriteLine("Digite el nombre o apellido del contacto que desea buscar:");
        string searchTerm = Console.ReadLine() ?? "";

        var foundContacts = contacts.Where(c =>
        (c.Name ?? "").Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        (c.LastName ?? "").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContacts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No se encontraron contactos con ese nombre o apellido.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("\n============================\n"); 

        foreach (var contact in foundContacts)
        {
            Console.WriteLine($"ID: {contact.Id}");
            Console.WriteLine($"Nombre: {contact.FullName}");
            Console.WriteLine($"Dirección: {contact.Address}");
            Console.WriteLine($"Teléfono: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Edad: {contact.Age}");
            Console.WriteLine($"Mejor Amigo: {(contact.IsBestFriend ? "Sí" : "No")}");
            Console.WriteLine("-----------------------------");
        }
    }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ocurrió un error al buscar los contactos: " + ex.Message);
            Console.ResetColor();
        }
}

public static void ModifyContact(List<Contact> contacts)
{
    try
    { 
        if (contacts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay contactos registrados");
            Console.ResetColor();
            return;
        }

    Console.WriteLine("\n============================\n"); 
    ShowContact(contacts);
    Console.WriteLine("Digite el ID del contacto que desea modificar");
    int id = Convert.ToInt32(Console.ReadLine());

Contact? contact = contacts.FirstOrDefault(c => c.Id == id);

if (contact == null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("ID no encontrado.");
    Console.ResetColor();
    return;
}

Console.WriteLine("(Presione Enter para mantener el valor actual)");

Console.WriteLine($"Nombre actual: {contact.Name}");
string input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.Name = input;

Console.WriteLine($"Apellido actual: {contact.LastName}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.LastName = input;

Console.WriteLine($"Dirección actual: {contact.Address}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.Address = input;

Console.WriteLine($"Telefóno actual: {contact.Phone}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.Phone = input;

Console.WriteLine($"Email actual: {contact.Email}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.Email = input;

Console.WriteLine($"Edad actual: {contact.Age}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.Age = Convert.ToInt32(input);

Console.WriteLine($"Mejor Amigo actual: 1. Sí, 2. No {(contact.IsBestFriend ? "Sí" : "No")}");
input = Console.ReadLine() ?? "";
if (!string.IsNullOrWhiteSpace(input)) contact.IsBestFriend = Convert.ToInt32(input) == 1;

Console.WriteLine("\n============================\n");

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Contacto modificado exitosamente.");
Console.ResetColor();

    }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ocurrió un error al modificar el contacto: " + ex.Message);
            Console.ResetColor();
        }
}

public static void DeleteContact(List<Contact> contacts)
{
    try
    {
        if (contacts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay contactos registrados");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("\n============================\n"); 

        ShowContact(contacts);
        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        Contact? contact = contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ID no encontrado.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"¿Estás seguro de que desea eliminar a {contact.Name} {contact.LastName}? 1. Sí, 2. No");
        Console.ResetColor();
        int confirmation = Convert.ToInt32(Console.ReadLine());

        if (confirmation == 1)
        {
        contacts.Remove(contact);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Contacto eliminado exitosamente.");
        Console.ResetColor();
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Eliminación cancelada.");
        Console.ResetColor();
    }
}
        catch (Exception ex)
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ocurrió un error al eliminar el contacto: " + ex.Message);
        Console.ResetColor();
        }

}

}