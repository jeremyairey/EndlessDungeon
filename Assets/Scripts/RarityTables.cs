using UnityEngine;
using System.Collections;


namespace rds
{


    public class RarityTables : RDSObject
    {
        public int _tileID;
        public TileContainer ThisTile;

        public RarityTables(int tileID)
        {
            _tileID = tileID;
        }


    }//end of class

}//end of namespace
