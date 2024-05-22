using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string Name;
string Datum;
int Fehltage;
int UnFehltage;
int Unterkurse = 0;
string[,] Fächer = new string[8,2];
Console.WriteLine(Fächer);

Console.WriteLine("Name: ");
Name = Console.ReadLine();

Console.WriteLine("Datum: ");
Datum = Console.ReadLine();

Console.WriteLine("Fehltage: ");
Fehltage = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Davon Unnetschuldigte: ");
UnFehltage = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Die ersten Beiden sind die Leistungskurse");
for (int i = 0; i<8; i++)
{
    int fi = i + 1;
    Console.WriteLine("Fach " + fi + " Gebe Fachname ein: ");
    Fächer[i, 0] = Console.ReadLine();

    Console.WriteLine("Gebe Note für "+ Fächer[i,0] + " ein: ");
    Fächer[i, 1] = Console.ReadLine();
    if (Convert.ToInt32(Fächer[i, 1]) > -1 && Convert.ToInt32(Fächer[i, 1]) < 16)
    {

    }
    else
    {
        Console.WriteLine("STOP! Das geht nicht!");
        System.Threading.Thread.Sleep(1000);
        Console.ReadKey();
    }
    if (Convert.ToInt32(Fächer[i, 1]) < 5)
    {
        Unterkurse = Unterkurse + 1;
    }
}

double schnitt = 0;
for (int i = 0; i < 8; i++)
{
    if (i < 3)
            { 
        schnitt += Convert.ToInt32(Fächer[i, 1]) * 2;
    }
    else{
        schnitt += Convert.ToInt32(Fächer[i, 1]);
    }
}

Console.WriteLine("Das fertige Zeugnis:");


schnitt = schnitt / 10;
schnitt = (17 - schnitt) / 3;
schnitt = Math.Round(schnitt,1);
Console.WriteLine("Der Schnitt ist: " + schnitt);

bool Versetzung = true;

if (Unterkurse > 2)
{
    Versetzung = false;
}

if (UnFehltage > 29)
{
    Versetzung = false;
}

if  (Versetzung = true)
{
    Console.WriteLine("Versetzt");
}
else
{
    Console.WriteLine("Nicht versetzt");

}

Console.WriteLine("Zeugnis für " + Name);
Console.WriteLine("Datum: " + Datum);
Console.WriteLine(Fehltage + " Fehltage");
Console.WriteLine(UnFehltage + " Unentschuldigte Fehltage");
Console.WriteLine("Lestungskurse:");
for (int i = 0; i<8; i++)
{
    if (i == 2)
    {
        Console.WriteLine("Restliche Fächer:");
    }
    Console.WriteLine(Fächer[i, 0] + " " + Fächer[i, 1]);
}