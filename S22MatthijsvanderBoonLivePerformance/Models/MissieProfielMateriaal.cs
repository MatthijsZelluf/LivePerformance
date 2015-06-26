using System;
using S22MatthijsvanderBoonLivePerformance.Database;

namespace S22MatthijsvanderBoonLivePerformance.Models
{
    class MissieProfielMateriaal : iDatabase
    {
        //Fields
        private int _id;
        private int _hoeveelheid;
        private Materiaal _materiaal;
        private MissieProfiel _missieProfiel;

        //Properties
        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Hoeveelheid
        {
            get { return _hoeveelheid; }
            set { _hoeveelheid = value; }
        }

        public Materiaal Materiaal
        {
            get { return _materiaal; }
            set { _materiaal = value; }
        }

        public MissieProfiel MissieProfiel
        {
            get { return _missieProfiel; }
            set { _missieProfiel = value; }
        }

        #endregion

        //Constructor
        public MissieProfielMateriaal(int id, int hoeveelheid, Materiaal materiaal, MissieProfiel missieProfiel)
        {
            _id = id;
            _hoeveelheid = hoeveelheid;
            _materiaal = materiaal;
            _missieProfiel = missieProfiel;
        }

        public bool Edit(Database.Database database)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Database.Database database)
        {
            throw new NotImplementedException();
        }
    }
}
