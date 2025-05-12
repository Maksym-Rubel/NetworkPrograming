using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Asn1.X509;
using System;


class Program
{
    static void Main()
    {
       
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string email = "rubelmaksum2404@gmail.com";
        string password = "biqn elwk zpvn cfvz";

        using (var client = new ImapClient())
        {

            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            client.Authenticate(email, password);

            var folders = client.GetFolders(client.PersonalNamespaces[0]);
            Console.WriteLine("Folders:");
            foreach (var folder in folders)
            {
                Console.WriteLine("- " + folder.Name);
            }

            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            Console.WriteLine($"Count mssg {inbox.FullName}: {inbox.Count}");
            int couter = inbox.Count - 5;
            for (int i = inbox.Count - 1; i >= couter; i--)
            {
                var message_ = inbox.GetMessage(i);
                string? senred = message_.From.Mailboxes.FirstOrDefault()?.Name == "" ? message_.From.Mailboxes.FirstOrDefault()?.Address : message_.From.Mailboxes.FirstOrDefault()?.Name;
                Console.WriteLine($"\nMessage #{i + 1}");
                Console.WriteLine($"From: {senred} ------- To:{message_.To}");
                Console.WriteLine($"{message_.Subject}");
                Console.WriteLine($"Date:{message_.Date.DateTime.ToShortDateString()}");
            }
        

            var folder1 = client.GetFolder(client.PersonalNamespaces[0]);
            

            DeleteMessages(inbox, inbox.Count - 1);
            CreateFolder(folder1, "MyFolder");
            MoveMessageToFolder(inbox, folder1, "MyFolder");
            SortMessagesByDate(inbox);
            FilterMessagesBySender(inbox, "noreply@olx.ua");
            SearchMessagesBySubject(inbox, "test");

            client.Disconnect(true);
        }
    }
    static void DeleteMessages(IMailFolder inbox,int index)
    {
        
        inbox.AddFlags(index, MessageFlags.Deleted, true);
        inbox.Expunge();
        Console.WriteLine("DeleteMessages");
    }

    static void CreateFolder(IMailFolder folder, string folderName)
    {
        if (!folder.GetSubfolders(false).Any(f => f.Name == folderName))
        {
            folder.Create(folderName, true);
            Console.WriteLine($"Created folder: {folderName}");
        }
    }

    static void MoveMessageToFolder(IMailFolder inbox, IMailFolder folder, string targetFolderName)
    {
        if (inbox.Count > 0)
        {
            var targetFolder = folder.GetSubfolder(targetFolderName);
            inbox.MoveTo(0, targetFolder);
            Console.WriteLine($"MoveMessageToFolder {targetFolderName}");
        }
    }

    static void SortMessagesByDate(IMailFolder inbox)
    {
        var sorted = inbox.Fetch(0, -1, MessageSummaryItems.Envelope)
                          .OrderByDescending(m => m.Envelope.Date)
                          .ToList();
        Console.WriteLine("SortMessagesByDate:");
        foreach (var item in sorted)
            Console.WriteLine($"{item.Envelope.Date}: {item.Envelope.Subject}");
    }

    static void FilterMessagesBySender(IMailFolder inbox, string senderEmail)
    {
        var results = inbox.Search(SearchQuery.FromContains(senderEmail));
        Console.WriteLine("FilterMessagesBySender:");
        foreach (var idx in results)
        {
            var msg = inbox.GetMessage(idx);
            Console.WriteLine($"BY: {msg.From}, Subject: {msg.Subject}");
        }
    }

    static void SearchMessagesBySubject(IMailFolder inbox, string text)
    {
        var found = inbox.Search(SearchQuery.SubjectContains(text));
        Console.WriteLine("SearchMessagesBySubject:");
        foreach (var id in found)
        {
            var msg = inbox.GetMessage(id);
            Console.WriteLine($"Find: {msg.Subject}");
        }
    }


}
