// Deze controller dient voor alle functionaliteit die te maken hebben met missies
using System;
using System.Collections.Generic;
using S22MatthijsvanderBoonLivePerformance.Models;

namespace S22MatthijsvanderBoonLivePerformance.Controller
{
    class MissieController
    {
        //Maak fields aan voor de database klasse en de BotenController zodat deze overal te bereiken zijn
        private Database.Database database;
        private BotenController controller;

        //Constructor
        public MissieController()
        {
            //Initialiseer de fields
            database = new Database.Database();
            controller = new BotenController();
        }

        //Deze methode geeft een lijst terug van alle bestaande missies
        public List<Missie> SearchAllMissions()
        {
            var missionColumns = new List<string>();
            var missions = new List<Missie>();

            missionColumns.Add("MissieID");
            missionColumns.Add("BootID");
            missionColumns.Add("Samenvatting");
            missionColumns.Add("StartDatum");
            missionColumns.Add("Conclusie");
            missionColumns.Add("Type");
            missionColumns.Add("EindDatum");
            missionColumns.Add("PolitieHoeveelheid");

            var dataTable = database.SelectQuery("SELECT * FROM MISSIE", missionColumns);

            if (dataTable[0].Count > 1)
            {

                for (int i = 1; i < dataTable[0].Count; i++)
                {
                    MissieType type = (MissieType) Enum.Parse(typeof (MissieType), (string)dataTable[5][i], false);
                    if ((string) dataTable[5][i] == "SIN")
                    {
                        missions.Add(new SIN(
                        Convert.ToInt32(dataTable[0][i]),
                        (string)dataTable[2][i],
                        Convert.ToDateTime(dataTable[3][i]),
                        (string)dataTable[4][i],
                        type,
                        controller.SearchSpecificBoat(Convert.ToInt32(dataTable[1][i])),
                        Convert.ToInt32(dataTable[7][i])));   
                    }
                    else if ((string) dataTable[5][i] == "HOPE")
                    {
                        missions.Add(new HOPE(Convert.ToInt32(dataTable[0][i]),
                        (string)dataTable[2][i],
                        Convert.ToDateTime(dataTable[3][i]),
                        (string)dataTable[4][i],
                        type,
                        controller.SearchSpecificBoat(Convert.ToInt32(dataTable[1][i])),
                        Convert.ToDateTime(dataTable[6][i])));
                    }
                }
            }

            return missions;
        }

        //Deze methode dient ervoor om missies aan de database toe te voegen
        public bool AddSINMission(SIN sin, List<Persoon> personen, List<MissieMateriaal> missieMaterialen)
        {
            try
            {
                database.EditDatabase(String.Format("INSERT INTO MISSIE VALUES(1,{0},'{1}',TO_DATE('{2}', 'dd/mm/yyyy hh24:mi:ss'),null,'SIN',null,{3})",sin.Boot.Id,sin.Samenvatting,sin.StartDatum,sin.HoeveelheidPolitie));

                int missionID = 0;
                List<string> missionColumns = new List<string>();
                missionColumns.Add("MAXMISSIE");

                List<string>[] dataTable = database.SelectQuery("SELECT MAX(MISSIEID)AS MAXMISSIE FROM MISSIE",missionColumns);

                if (dataTable[0].Count > 1)
                {
                    for (int i = 1; i < dataTable[0].Count; i++)
                    {
                        missionID = Convert.ToInt32(dataTable[0][i]);
                    }
                }

                foreach (Persoon persoon in personen)
                {
                    database.EditDatabase(String.Format("INSERT INTO MISSIE_PERSOON VALUES({0},{1})",persoon.Id,missionID));
                }

                foreach (var missieMateriaal in missieMaterialen)
                {
                    database.EditDatabase(String.Format("INSERT INTO MissieMateriaal VALUES(1,{0},{1},{2})", missionID, missieMateriaal.Id,missieMateriaal.Hoeveelheid));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Deze methode dient ervoor om missies uit de database te verwijderen
        public void DeleteMission(Missie missie)
        {
            if (missie is SIN)
            {
                SIN sin = (SIN)missie;
                sin.Remove(database);
            }
            else if (missie is HOPE)
            {
                HOPE hope = (HOPE)missie;
                hope.Remove(database);
            }
        }
    }
}
