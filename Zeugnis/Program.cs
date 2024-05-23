using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;



var nameRegex = new Regex("^[A-Za-zß-]*$");
var fachRegex = new Regex("^[A-Za-zß-]*$");

string Name;
string Datum;
int Fehltage;
int UnFehltage;
int Unterkurse = 0;
string[,] Fächer = new string[8,2];

Console.WriteLine("ZeugnisAPP");
Console.WriteLine();

while (true){
    Console.WriteLine("Name: ");
    Name = Console.ReadLine();
    if (nameRegex.IsMatch(Name))
    {
        break;
    }
    Console.WriteLine("Im Namen sind nur Buchstaben, Leerzeichen und Bindestriche erlaubt");
}

while (true)
{
    Console.WriteLine("Datum: ");
    Datum = Console.ReadLine();
    if (Datum[2] == '.' && Datum[5] == '.')
    {
        string Day0 = Convert.ToString(Datum[0]);
        string Day1 = Convert.ToString(Datum[1]);
        string Month3 = Convert.ToString(Datum[3]);
        string Month4 = Convert.ToString(Datum[4]);
        string Year6 = Convert.ToString(Datum[6]);
        string Year7 = Convert.ToString(Datum[7]);
        string Year8 = Convert.ToString(Datum[8]);
        string Year9 = Convert.ToString(Datum[9]);

        int Day = Convert.ToInt32(Day0)*10 + Convert.ToInt32(Day1) ;
        int Month = Convert.ToInt32(Month3) * 10 + Convert.ToInt32(Month4);
        int Year = Convert.ToInt32(Year6) * 1000 + Convert.ToInt32(Year7)*100 + Convert.ToInt32(Year8)*10 + Convert.ToInt32(Year9);
        if (Day <= 31 && Month <= 12)
        {
            break;
        }
        Console.WriteLine("Das ist kein richtiges Datum");
    }
    Console.WriteLine("Das Datum soll in der Form DD.MM.YYYY eingegeben werden");
}


Console.WriteLine("Fehltage: ");
Fehltage = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Davon Unnetschuldigte: ");
UnFehltage = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Die ersten Beiden sind die Leistungskurse");
static void fächerInput(int i)
{

}
for (int i = 0; i<8; i++)
{
    while (true)
    {
        int fi = i + 1;
        Console.WriteLine("Fach " + fi + " Gebe Fachname ein: ");
        Fächer[i, 0] = Console.ReadLine();

        Console.WriteLine("Gebe Note für " + Fächer[i, 0] + " ein: ");
        Fächer[i, 1] = Console.ReadLine();
        if (Convert.ToInt32(Fächer[i, 1]) > -1 && Convert.ToInt32(Fächer[i, 1]) < 16)
        {
            if (fachRegex.IsMatch(Fächer[i,0]) && Fächer[i,0].Length <= 20)
            {
                break;
            }
            else
            {
                Console.WriteLine("der Fachname darf höstens 20 Zeichen lang sein und kann keine Sonderzeichen enthalten");
            }
            
        }
        else
        {
            Console.WriteLine("es dürfen nur Zahlenwerte zwischen 0 und 15 eingegeben werden");
        }
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
Console.Clear();
Console.WriteLine("=====================================");
Console.WriteLine("Zeugnis für " + Name);
Console.WriteLine("Datum: " + Datum);
Console.WriteLine(Fehltage + " Fehltage");
Console.WriteLine(UnFehltage + " Unentschuldigte Fehltage");
Console.WriteLine("=====================================");
Console.WriteLine("");

schnitt = schnitt / 10;
schnitt = (17 - schnitt) / 3;
schnitt = Math.Round(schnitt,1);
Console.WriteLine("Durchschnittsnote: " + schnitt);
Console.WriteLine("");

bool Versetzung = true;

if (Unterkurse > 2)
{
    Versetzung = false;
}

if (UnFehltage > 29)
{
    Versetzung = false;
}


Console.WriteLine();

Console.WriteLine("Lestungskurse:");
for (int i = 0; i<8; i++)
{
    if (i == 2)
    {
        Console.WriteLine("Restliche Fächer:");
    }
    Console.WriteLine(Fächer[i, 0] + " " + Fächer[i, 1]);
}

Console.WriteLine();   
if (Versetzung == true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Versetzt");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Nicht versetzt");
    Console.ResetColor();

}
Console.WriteLine("=====================================");

Console.Clear();

Console.WriteLine("Soll das Gespeichert werden? (Ja/Nein)");
string speirchern = Console.ReadLine();

if (speirchern == "Ja")
{
    string PathF = "C:\\Users\\Paul Schule\\source\\repos\\Zeugnis\\2024-gruppe-tano\\" + Name + ".txt";

    FileStream fileStream = File.Create(PathF);
    fileStream.Close();

    StreamWriter sw = new StreamWriter(PathF, true);

    sw.Write("Zeugnis für: " + Name + Environment.NewLine + "Ausgestellt am: " + Datum + Environment.NewLine + "Fehltage: " + Fehltage + Environment.NewLine + "Unentschuldigte Fehltage:" + UnFehltage + Environment.NewLine + Environment.NewLine);
    sw.WriteLine("Lestungskurse:");
    for (int i = 0; i < 8; i++)
    {
        if (i == 2)
        {
            sw.WriteLine("Restliche Fächer:");
        }
        sw.WriteLine(Fächer[i, 0] + " " + Fächer[i, 1]);
    }

    if (Versetzung == true)
    {
        sw.WriteLine("Versetzt");
    }
    else
    {
        sw.WriteLine("Nicht versetzt");

    }
    sw.Flush();
}



Console.ReadKey();