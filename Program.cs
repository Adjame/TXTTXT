using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManipTXT
{
    class Sender
    {
        public string Identifiant { get; set; }
        public string Rib { get; set; }
        public string Name { get; set; }
    }

    class Receiver
    {
        public string Rib { get; set; }
        public string Nom { get; set; }
    }

    class Program
    {
        static string GetReport(Sender sender, List<Receiver> receivers)
        {
            var builder = new StringBuilder();

            //l'entte
            builder.Append("VIRM");
            builder.Append(sender.Rib);
            builder.Append($"{sender.Name,-50}");
            builder.AppendLine(".");

            //corp
            foreach (var r in receivers)
            {
                builder.Append(r.Rib);
                builder.Append($"{r.Nom,-20}");
                builder.AppendLine(".");
            }

            return builder.ToString();
        }

        static void Main(string[] args)
        {
            var sender = new Sender
            {
                Identifiant = "001",
                Rib = "LKJ0923333",
                Name = "RG"
            };

            var employees = new List<Receiver>
            {
                new Receiver{Rib = "COCO", Nom = "Djamel"},
                new Receiver{Rib = "KIKI", Nom = "Eddine"}
            };

            var repo = GetReport(sender, employees);
            File.WriteAllText(@"D:\\file.txt", repo);
            Console.WriteLine(repo);
            Console.ReadKey();

            return;
            string line = "djamel";
            var content = new List<string>();
            content.Add("Line 1");
            content.Add("Line 2");

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("rib");
            stringBuilder.Append("nom");
            for (int i = 0; i < 10; i++)
            {
                stringBuilder.AppendLine("rib-employé");

                stringBuilder.AppendFormat("{0, -50} coco, {1}", $"name-{i}","KIKI");
            }

            File.WriteAllText(@"D:\\test.txt", line);
            File.WriteAllLines(@"D:\\test2.txt", content);
            File.WriteAllText(@"D:\\test3.txt", stringBuilder.ToString());
            

            return;
            //creation du fichier TXT
            {
                //FileStream fs = File.Create("MyFile.txt");
                Console.WriteLine("fichier créé !!");
            }
            //creation du contenue
            {
                string contenu01 = ("contenu du fichier pour teste");
                string contenu02 = ("un autre contenu dans le fichier pour tester ce que sa donne ");
                using (StreamWriter autre = new StreamWriter("MyFile.txt"))
                    autre.WriteLine(contenu01);

                using (StreamWriter autre2 = new StreamWriter("MyFile.txt"))
                    autre2.WriteLine(contenu02);


                //System.IO.File.WriteAllText("je veux tester quoi ecrire dans cette section ok ok",contenu);

            }
            Console.WriteLine("appuyer sur une touche pour sortir");
            Console.ReadKey();
        }

    }
        
    
}
