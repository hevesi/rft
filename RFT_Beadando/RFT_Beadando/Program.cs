using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ProgTech_beadando
{
    class Program
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Prog_Tech\ProgTech_beadando\ProgTech_beadando\bin\Debug\Database1.mdf;Integrated Security=True";
        static void Main(string[] args)
        {

            string input = "";
            Console.SetWindowSize(160, 30);
            while (input.ToLower() != "-q")
            {
                Console.Write("\nAdjon meg egy parancsot(súgó: '-h'):");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "-h":
                        Sugo();
                        break;

                    case "-terem":
                        MoziTerem mt = MoziTerem.GetInstance();
                        Console.WriteLine("\n" + mt);
                        break;


                    case "-vendegmutat":
                        VendegMutat();
                        break;

                    case "-torzsvendegmutat":
                        TorzsVendegMutat();
                        break;

                    case "-legyentorzsvendeg":
                        Console.WriteLine("Név: ");
                        string nev = Console.ReadLine();
                        UpgradeVevo(nev);
                        break;

                    case "-maieloadasok":
                        MaiEloadasok();
                        break;

                    case "-ujeloadas":
                        FilmMutat();
                        Console.Write("\nAdja meg a jelenleg műsoron lévő film ID-jét: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Adja meg az előadás dátumát(YYYY.MM.DD. hh:mm: ");
                        DateTime dt = DateTime.Parse(Console.ReadLine());

                        EloadasHozzaadas(id, dt);
                        Console.WriteLine("Előadás hozzáadva.");
                        break;

                    case "-jegyeladas":
                        Console.Write("Vevő neve: ");
                        nev = Console.ReadLine();
                        Vevo v;
                        if (TorzsvendegE(nev))
                        {
                            v = new Vevo(new TorzsVevo(nev));
                            Console.WriteLine(nev + " törzsvendég.");
                        }
                        else
                        {
                            v = new Vevo(new NormalVevo(nev));
                            Console.WriteLine(nev + " nem törzsvendég");
                        }
                        Console.WriteLine("\n\n");
                        MaiEloadasok();
                        Console.Write("\nAdja meg a választott előadás ID-jét: ");
                        int eID = int.Parse(Console.ReadLine());

                        Jegyvasarlas(eID, v);
                        v.Fizetes();

                        break;
                    case "-ujfilm":
                        Console.Write("\nFilm címe: ");
                        string cim = Console.ReadLine();
                        Film f = new Film(cim);

                        Console.Write("Film műfaja(nem kötelező): ");
                        string mufaj = Console.ReadLine();
                        if (mufaj != "")
                            f.SetMufaj(mufaj);

                        Console.Write("Film hossza percben(nem kötelező): ");
                        string sHossz = Console.ReadLine();
                        if (sHossz != "")
                            f.SetHossz(int.Parse(sHossz));

                        Console.Write("Film rendezője(nem kötelező): ");
                        string rendezo = Console.ReadLine();
                        if (rendezo != "")
                            f.SetRendezo(rendezo);

                        FilmHozzaadas(f);
                        Console.WriteLine(cim + " hozzáadva.");
                        break;
                    case "-filmmutat":
                        FilmMutat();
                        break;

                    case "-filmtorles":
                        FilmMutat();
                        Console.Write("\nAdja meg a törölni kívánt film ID-jét: ");
                        int filmID = int.Parse(Console.ReadLine());
                        FilmTorles(filmID);
                        Console.WriteLine("Film törölve.");
                        break;
                }
            }
        }
        static void Sugo()
        {
            Console.WriteLine("<------------------------------------------------------>");
            Console.WriteLine("Az összes vendég megjelenítése: -vendegMutat");
            Console.WriteLine("Az összes törzsvendég megjelenítése: -torzsvendegMutat");
            Console.WriteLine("Vendég törzsvendéggé nyilvánítása: -legyenTorzsvendeg");
            Console.WriteLine("\nMai előadások megjelenítése: -maiEloadasok");
            Console.WriteLine("Új előadás hozzáadása: -ujEloadas");
            Console.WriteLine("\nJegy eladása: -jegyEladas");
            Console.WriteLine("\nÚj film hozzáadása: -ujFilm");
            Console.WriteLine("Jelenleg vetített filmek megjelenítése: -filmMutat");
            Console.WriteLine("Film törlése: -filmTorles");
            Console.WriteLine("<------------------------------------------------------>");

        }

        static void VendegMutat()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Id, Nev FROM Vevok", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetValue(i) + "\t\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void TorzsVendegMutat()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Nev FROM Vevok Where Torzsvendeg= 'True'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void UpgradeVevo(string nev)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("UPDATE Vevok SET Torzsvendeg='1' Where Nev=@nev", connection);
                command.Parameters.AddWithValue("@nev", nev);
                connection.Open();
                command.ExecuteNonQuery();
            }
            Console.WriteLine(nev + " mostmár törzsvendég");
        }
        static bool TorzsvendegE(string nev)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Vevok Where Nev=@nev AND " +
                    "Torzsvendeg ='1'", connection))
                {
                    command.Parameters.AddWithValue("@nev", nev);
                    int userCount = (int)command.ExecuteScalar();
                    if (userCount > 0)
                        return true;
                    return false;
                }
            }
        }

        static void MaiEloadasok()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Write("ElőadásID");
                Console.SetCursorPosition(20, Console.CursorTop);
                Console.Write("Filmcím");
                Console.SetCursorPosition(80, Console.CursorTop);
                Console.WriteLine("Időpont\n");
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT e.Id, f.Cim, e.Idopont " +
                    "FROM Eloadasok e INNER JOIN Filmek f ON e.FilmID = f.Id Where e.Idopont>= @todaydate " +
                    "AND Idopont<@nextday Order by e.Idopont", connection))
                {
                    command.Parameters.AddWithValue("@todaydate", DateTime.Today);
                    command.Parameters.AddWithValue("@nextday", DateTime.Today.AddDays(1));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        Console.SetCursorPosition(20, Console.CursorTop);
                                        break;
                                    case 2:
                                        Console.SetCursorPosition(80, Console.CursorTop);
                                        break;
                                }
                                Console.Write(reader.GetValue(i) + " \t\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void EloadasHozzaadas(int filmID, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Eloadasok(FilmID,Idopont)" +
                    "VALUES(@filmid,@idopont)", connection))
                {
                    command.Parameters.AddWithValue("@filmid", filmID);
                    command.Parameters.AddWithValue("@idopont", date);
                    command.ExecuteNonQuery();
                }
            }
        }

        static void Jegyvasarlas(int eloadasID, Vevo v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //vevoID beállítása
                int vevoID = -1;

                //megnézni hogy a Vevok tábla tartalmazza-e
                using (SqlCommand command = new SqlCommand("SELECT Id FROM Vevok Where Nev=@nev", connection))
                {
                    command.Parameters.AddWithValue("@nev", v.Nev);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            vevoID = (int)reader.GetValue(0);
                    }
                }
                //ha nem, akkor insert, és vevoID beállítása
                if (vevoID == -1)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Vevok(Nev) Values(@nev)", connection))
                    {
                        command.Parameters.AddWithValue("@nev", v.Nev);
                        command.ExecuteNonQuery();

                        command.Parameters.Clear();
                        command.CommandText = "SELECT Id FROM Vevok Where Nev=@nev";
                        command.Parameters.AddWithValue("@nev", v.Nev);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                vevoID = (int)reader.GetValue(0);
                        }

                    }

                }

                int filmID;
                using (SqlCommand command = new SqlCommand("SELECT FilmID FROM Eloadasok WHERE Id=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", eloadasID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        filmID = (int)reader.GetValue(0);
                    }
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO Jegyvasarlasok(VevoId,FilmID,EloadasID," +
                    "Idopont) Values(@vevoid, @filmid, @eloadasid, @idopont)", connection))
                {
                    command.Parameters.AddWithValue("@vevoid", vevoID);
                    command.Parameters.AddWithValue("@filmid", filmID);
                    command.Parameters.AddWithValue("@eloadasid", eloadasID);
                    command.Parameters.AddWithValue("@idopont", DateTime.Now);
                    command.ExecuteNonQuery();
                }

            }
        }

        static void FilmHozzaadas(Film film)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Filmek(Cim,Mufaj,Hossz,Rendezo)" +
                    " VALUES(@cim, @mufaj, @hossz, @rendezo)", connection))
                {
                    command.Parameters.AddWithValue("@cim", film.Cim);
                    command.Parameters.AddWithValue("@mufaj", film.Mufaj);
                    command.Parameters.AddWithValue("@hossz", film.Hossz);
                    command.Parameters.AddWithValue("@rendezo", film.Rendezo);
                    command.ExecuteNonQuery();
                }
            }
        }
        static void FilmMutat()
        {
            Console.Write("ID");
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.Write("Cím");
            Console.SetCursorPosition(80, Console.CursorTop);
            Console.Write("Műfaj");
            Console.SetCursorPosition(100, Console.CursorTop);
            Console.Write("Hossz");
            Console.SetCursorPosition(110, Console.CursorTop);
            Console.Write("Rendező");
            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Filmek", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                switch (i)
                                {
                                    case 1:
                                        Console.SetCursorPosition(20, Console.CursorTop);
                                        break;
                                    case 2:
                                        Console.SetCursorPosition(80, Console.CursorTop);
                                        break;
                                    case 3:
                                        Console.SetCursorPosition(100, Console.CursorTop);
                                        break;
                                    case 4:
                                        Console.SetCursorPosition(110, Console.CursorTop);
                                        break;
                                }

                                Console.Write(reader.GetValue(i) + "\t\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void FilmTorles(int filmID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Filmek WHERE Id=@id", connection))
                {
                    command.Parameters.AddWithValue("@id", filmID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }

    public class MoziTerem //singleton
    {
        private static MoziTerem uniqueInstance = null;
        private MoziTerem() { }

        public static MoziTerem GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new MoziTerem();
            }
            return uniqueInstance;
        }

        private int _ferohely = 50;
        public int Ferohely { get { return _ferohely; } }

        private int _vaszonX = 16;
        public int VaszonX { get { return _vaszonX; } }
        private int _vaszonY = 7;
        public int VaszonY { get { return _vaszonY; } }

        private string _hangrendszer = "Dolby Atmos";
        public string Hangrendszer { get { return _hangrendszer; } }

        public void SetFerohely(int ferohely)
        {
            _ferohely = ferohely;
        }

        public void SetVaszonMeret(int X, int Y)
        {
            _vaszonX = X;
            _vaszonY = Y;
        }

        public void SetHangrendszer(string Hangrendszer)
        {
            _hangrendszer = Hangrendszer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A moziterem férőhelye: " + Ferohely);
            sb.AppendLine("A vászon mérete: " + VaszonX + "m*" + VaszonY + "m");
            sb.AppendLine("Hangrendszer: " + Hangrendszer);
            return sb.ToString();
        }

    }

    public class Film
    {
        string cim;
        public string Cim { get { return cim; } }

        string mufaj;
        public string Mufaj { get { return mufaj; } }

        string rendezo;
        public string Rendezo { get { return rendezo; } }

        int hossz;
        public int Hossz { get { return hossz; } }

        public Film(string cim)
        {
            this.cim = cim;
            mufaj = "";
            rendezo = "";
            hossz = 0;

        }

        public void SetCim(string cim)
        {
            this.cim = cim;
        }

        public void SetMufaj(string mufaj)
        {
            this.mufaj = mufaj;
        }

        public void SetHossz(int hossz)
        {
            this.hossz = hossz;
        }

        public void SetRendezo(string rendezo)
        {
            this.rendezo = rendezo;
        }
    }//encapsulation

    //stratégia
    public abstract class VevoStrategia
    {
        public abstract void Fizetes();
        public abstract string Nev { get; }
        public abstract int Fizetendo { get; }
    }
    public class NormalVevo : VevoStrategia
    {
        private string _nev;
        public override string Nev
        {
            get { return _nev; }
        }
        private int _fizetendo;
        public override int Fizetendo
        {
            get
            {
                return _fizetendo;
            }
        }

        public NormalVevo(string nev)
        {
            _nev = nev;
            _fizetendo = 1500;
        }

        public override void Fizetes()
        {
            Console.WriteLine(_fizetendo + " forint a jegy ára.");
        }
    }
    public class TorzsVevo : VevoStrategia
    {
        private string _nev;
        public override string Nev
        {
            get { return _nev; }
        }

        private int _fizetendo;
        public override int Fizetendo
        {
            get
            {
                return _fizetendo;
            }
        }


        public TorzsVevo(string nev)
        {
            _nev = nev;
            _fizetendo = 1200;
        }

        public override void Fizetes()
        {
            Console.WriteLine(_fizetendo + " forint lesz a jegy ára");
        }
    }
    public class Vevo
    {
        private VevoStrategia vevoStrategia;
        public string Nev { get { return vevoStrategia.Nev; } }

        public Vevo(VevoStrategia v)
        {
            vevoStrategia = v;
        }

        public void Fizetes()
        {
            vevoStrategia.Fizetes();
        }
        public int Fizetendo
        {
            get
            {
                return vevoStrategia.Fizetendo;
            }
        }

    }



}
