using System;
using System.Diagnostics.Metrics;

// MOCK DATA - creation of the 3 sudents based on Etudiant structure. Most values are already assigned.
Etudiant etu1 = new Etudiant(101010, "David Demau", 70, 90, 88);
Etudiant etu2 = new Etudiant(202020, "Antoine Griezmann", 99, 90, 85);
Etudiant etu3 = new Etudiant(303030, "Manuel Neuer", 90, 45, 50);

// an array to store students
Etudiant[] etudiants = { etu1, etu2, etu3 };

// an array to store newly added students, that may not be yet in the final list (etudiants)
List<Etudiant> nouveauxEtudiants = new List<Etudiant>();

// program starts here with menu options
Main();

void Main()
{
    bool showMenu = true;
    while (showMenu)
    {
        showMenu = MainMenu();
    }
}

bool MainMenu()
{
    Console.Clear();
    Console.WriteLine("*****Choisissez une option*****");
    Console.WriteLine("1) Créer un étudiant avec ses 3 notes");
    Console.WriteLine("2) Ajouter un étudiant à la liste d’étudiants");
    Console.WriteLine("3) Afficher la liste des étudiants");
    Console.WriteLine("4) Calculer la moyenne de tous les étudiants");
    Console.WriteLine("5) Attribuer la mention à tous les étudiants");
    Console.Write("\r\nSelect an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            CreateNewStudent();
            return false;
        case "2":
            AddNewStudentToList();
            return false;
        case "3":
            DisplayStudentsList();
            return false;
        case "4":
            CalculateAverageForAllStudents();
            return false;
        case "5":
            AssignStudentsMentions();
            return false;
        default:
            return true;
    }
}

// creer nouvel etudiant et le stocke dans l'array des nouveaux etudiants
void CreateNewStudent()
{
    Etudiant etudiant = new Etudiant();

    Console.WriteLine("Entrez numero etudiant: ");
    etudiant.numEtudiant = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Entrez nom etudiant: ");
    etudiant.nom = Convert.ToString(Console.ReadLine());

    Console.WriteLine("Entrez note mi-session: ");
    etudiant.noteMiSession = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Entrez note projet: ");
    etudiant.noteProjet = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Entrez note fin de session: ");
    etudiant.noteFinDeSession = Convert.ToInt32(Console.ReadLine());

    etudiant.mention = "**";

    nouveauxEtudiants.Add(etudiant); // ajouter un nouvel etudiant dans notre table d'etudiants deja existe 

    Console.WriteLine(etudiant.nom + " a ete cree");
    Thread.Sleep(2000);
    Main();
}

void AddNewStudentToList()
{
    bool isEtudiantFound = false;

    Console.WriteLine("Entrez le numero de l'etudiant que vous souhaitez ajouter a la liste: ");
    int numEtudiant = Convert.ToInt32(Console.ReadLine());

    // loop through each newly created student
    for (var i = 0; i < nouveauxEtudiants.Count; i++)
    {
        // check if entered numEtudiant equals current numEtudiant
        if (numEtudiant == nouveauxEtudiants[i].numEtudiant)
        {
            isEtudiantFound = true;

            // ajouter nouvel etudiant dans la liste officiel des etudiants
            Array.Resize(ref etudiants, etudiants.Length + 1);
            etudiants[etudiants.Length - 1] = nouveauxEtudiants[i];

            Console.WriteLine(nouveauxEtudiants[i].nom + " a ete ajoute a la liste des etudiants");
            Thread.Sleep(2000);
            Main();
        }
    }
    if (isEtudiantFound == false)
    {
        Console.WriteLine("Numero etudiant incorrect, vous allez etre redirige vers le menu principal");
        Thread.Sleep(2000);
        Main();
    }
}

void DisplayStudentsList()
{
    for (var i = 0; i < etudiants.Length; i++)
    {
        Console.WriteLine("");
        DisplayInfoStudent(etudiants[i].numEtudiant);
    }
    Console.WriteLine("");
    Console.WriteLine("La liste va disparaitre dans 10 secondes, et vous allez etre redirige vers le menu principal");
    Thread.Sleep(10000);
    Main();
}

void CalculateAverageForAllStudents()
{
    for (var i = 0; i < etudiants.Length; i++)
    {
        CalculateStudentAverage(etudiants[i].numEtudiant);
    }
    Console.WriteLine("Tous les etudiants ont leur moyenne");
    Thread.Sleep(2000);
    Main();
}

void DisplayInfoStudent(int numEtudiant)
{
    // loop through each student
    for (var i = 0; i < etudiants.Length; i++)
    {
        // check if entered numEtudiant equals current numEtudiant
        if (numEtudiant == etudiants[i].numEtudiant)
        {
            Console.WriteLine("Numero etudiant: " + etudiants[i].numEtudiant);
            Console.WriteLine("Name: " + etudiants[i].nom);
            Console.WriteLine("Moyenne: " + etudiants[i].moyenne);
            Console.WriteLine("Mention: " + etudiants[i].mention);
            Console.WriteLine("Pass: " + etudiants[i].reussi);
        }
    }
}

void AssignStudentsMentions()
{
    for (var i = 0; i < etudiants.Length; i++)
    {
        AssignStudentMention(etudiants[i].numEtudiant);
    }
    Console.WriteLine("Tous les etudiants ont leur mention");
    Thread.Sleep(2000);
    Main();
}


void CalculateStudentAverage(int numEtudiant)
{
    // loop through each student
    for (var i = 0; i < etudiants.Length; i++)
    {
        // check if entered numEtudiant equals current numEtudiant
        if (numEtudiant == etudiants[i].numEtudiant)
        {
            etudiants[i].moyenne = (etudiants[i].noteMiSession + etudiants[i].noteProjet + etudiants[i].noteFinDeSession) / 3;
        }
    }

}


void AssignStudentMention(int numEtudiant)
{
    // loop through each student
    for (var i = 0; i < etudiants.Length; i++)
    {
        // check if entered numEtudiant equals current numEtudiant
        if (numEtudiant == etudiants[i].numEtudiant)
        {
            switch (etudiants[i].moyenne)
            {
                case >= 85 and <= 100:
                    etudiants[i].mention = "Excellent";
                    etudiants[i].reussi = true;
                    break;
                case >= 75:
                    etudiants[i].mention = "Tres bien";
                    etudiants[i].reussi = true;
                    break;

                case >= 65:
                    etudiants[i].mention = "Bien";
                    etudiants[i].reussi = true;
                    break;
                case >= 60:
                    etudiants[i].mention = "Passable";
                    etudiants[i].reussi = true;
                    break;
                case >= 0:
                    etudiants[i].mention = "Echec";
                    etudiants[i].reussi = false;
                    break;
                default:
                    Console.WriteLine("Si la moyenne n'est pas entre 0 et 100, SVP entrez les notes a nouveau");
                    break;
            }
        }
    }
}


void AssignGradesToStudent() //void pas de return
{
    Console.WriteLine("Entrez numero etudiant: ");
    int numEtudiant = Convert.ToInt32(Console.ReadLine());

    // loop through each student
    for (var i = 0; i < etudiants.Length; i++) //var = variable
    {
        // check if entered numEtudiant equals current numEtudiant
        if (numEtudiant == etudiants[i].numEtudiant)
        {
            Console.WriteLine("Etudiant actuel: " + etudiants[i].nom);

            Console.WriteLine("Entrez note mi-session: ");
            etudiants[i].noteMiSession = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entrez note projet: ");
            etudiants[i].noteProjet = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entrez note fin de session: ");
            etudiants[i].noteFinDeSession = Convert.ToInt32(Console.ReadLine());
        }
    }
}


public struct Etudiant
{
    public int numEtudiant;
    public string nom;
    public int noteMiSession;
    public int noteProjet;
    public int noteFinDeSession;
    public double moyenne;
    public string mention;
    public bool reussi;

    public Etudiant(int numEtudiant, string nom, int noteMiSession, int noteProjet, int noteFinDeSession,
                                      double moyenne = 0, string mention = "**", bool reussi = false)
    {
        this.numEtudiant = numEtudiant;
        this.nom = nom;
        this.noteMiSession = noteMiSession;
        this.noteProjet = noteProjet;
        this.noteFinDeSession = noteFinDeSession;
        this.moyenne = moyenne;
        this.mention = mention;
        this.reussi = reussi;
    }
}