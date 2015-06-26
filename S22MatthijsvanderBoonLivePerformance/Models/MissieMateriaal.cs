﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22MatthijsvanderBoonLivePerformance.Models
{
    class MissieMateriaal
    {
         //Fields
        private int _id;
        private int _hoeveeleheid;
        private Missie _missie;
        private Materiaal _materiaal;

        //Propeties
        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Hoeveeleheid
        {
            get { return _hoeveeleheid; }
            set { _hoeveeleheid = value; }
        }

        public Missie Missie
        {
            get { return _missie; }
            set { _missie = value; }
        }

        public Materiaal Materiaal
        {
            get { return _materiaal; }
            set { _materiaal = value; }
        }

        #endregion

        //Constructor
        public MissieMateriaal(int id, int hoeveeleheid, Missie missie, Materiaal materiaal)
        {
            _id = id;
            _hoeveeleheid = hoeveeleheid;
            _missie = missie;
            _materiaal = materiaal;
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
