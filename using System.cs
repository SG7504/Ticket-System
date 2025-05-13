using System;
using System.Collections.Generic;

class Ticket
{
    public int Id { get; }
    public string Description { get; set; }
    public bool IsResolved { get; private set; }

    public Ticket(int id, string description)
    {
        Id = id;
        Description = description;
        IsResolved = false;
    }

    public void MarkResolved()
    {
        IsResolved = true;
    }

    public override string ToString()
    {
        return $"[#{Id}] {Description} - {(IsResolved ? "Resolved" : "Open")}";
    }
}

class Program
{
    static List<Ticket> tickets = new List<Ticket>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Support Ticket System ====");
            Console.WriteLine("1. Add Ticket");
            Console.WriteLine("2. View Tickets");
            Console.WriteLine("3. Resolve Ticket");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTicket();
                    break;
                case "2":
                    ViewTickets();
                    break;
                case "3":
                    ResolveTicket();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddTicket()
    {
        Console.Write("Enter ticket description: ");
        string desc = Console.ReadLine();
        tickets.Add(new Ticket(nextId++, desc));
        Console.WriteLine("Ticket added. Press any key to return.");
        Console.ReadKey();
    }

    static void ViewTickets()
    {
        Console.WriteLine("\nCurrent Tickets:");
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets available.");
        }
        else
        {
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
        }
        Console.WriteLine("Press any key to return.");
        Console.ReadKey();
    }

    static void ResolveTicket()
    {
        Console.Write("Enter ticket ID to resolve: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var ticket = tickets.Find(t => t.Id == id);
            if (ticket != null && !ticket.IsResolved)
            {
                ticket.MarkResolved();
                Console.WriteLine("Ticket marked as resolved.");
            }
            else
            {
                Console.WriteLine("Ticket not found or already resolved.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
        Console.WriteLine("Press any key to return.");
        Console.ReadKey();
    }
}
