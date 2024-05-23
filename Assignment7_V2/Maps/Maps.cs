using System.Text;
using System.Drawing;

namespace Assignment7_V2
{
    class Maps
    {
        #region ----- PROPERTIES
        public GameMaps GameMap { get => gameMap; set => gameMap = value; }
        private GameMaps gameMap;

        /// <summary>Getter for game map. Enabled using System.Drawing</summary>
        public Image MapImage { get => mapImage; }
        private Image mapImage;

        /// <summary>A mapgrid containing collision objects,interactive objects and gates</summary>
        public int?[,] MapGrid { get => mapGrid; set => mapGrid = value; }
        private int?[,] mapGrid;
        #endregion

        #region ----- FIELDS
        private bool firstLoad = true; // blocker variable for first loadup
        #endregion


        #region ----- CONSTRUCTOR
        /// <summary>Constructor generating mapdata</summary>
        /// <param name="loadMap">input map</param>
        public Maps(GameMaps loadMap)
        {
            gameMap = loadMap;
            LoadMap(gameMap);
        }
        #endregion
        
        #region ----- METHODS
        /// <summary>Generates map grid and sets mapimage</summary>
        /// <param name="loadMap">map to be loaded</param>
        public void LoadMap(GameMaps loadMap)
        {
            if (!firstLoad)
                gameMap = loadMap;

            mapGrid = LoadMapGrid(loadMap);
            mapImage = LoadMapImage(loadMap);

            firstLoad = false;
        }

        /// <summary>Returns a map image</summary>
        /// <param name="mapImage">enum corresponding to image</param>
        public Image LoadMapImage(GameMaps mapImage)
        {
            return mapImage == GameMaps.Map1 ? MapImages.map1 : MapImages.map2;
        }

        /// <summary>Nested return function for generating an array of nullable int containing mapdata</summary>
        /// <param name="mapGrid">selected map</param>
        public int?[,] LoadMapGrid(GameMaps mapGrid)
        {
            return GenerateMap(GetMapGrid(mapGrid));
        }

        /// <summary>Generates an array of nullable int containing mapdata</summary>
        /// <param name="mapString">input map string</param>
        public int?[,] GenerateMap(string mapString)
        {
            int x, y, i; // x+y (coorinates) i (position in mapstring)
            x = y = i = 0;
            int?[,] mapData = new int?[25, 15];

            for (int j = 0; j < mapData.GetUpperBound(1) + 1; j++) // outer loop itterating columns
            {
                x = 0;
                for (int k = 0; k < mapData.GetUpperBound(0) + 1; k++) // inner loop itterating rows
                {
                    mapData[x, y] = HelperMethods.ToNullableInt(mapString[i++].ToString()); // converts and adds current string char(as string)
                    x++;
                }
                y++;
            }

            return mapData;
        }

        /// <summary>Generates a string representing a map grid</summary>
        /// <param name="map">selected map coresponding to return string</param>
        private string GetMapGrid(GameMaps map)
        {
            //character representation
            //0 null positions of a map - free to move to
            //1 block objects - player cant move through
            //2 interactive object
            //3 gates

            var strBuilder = new StringBuilder();

            switch (map)
            {
                case GameMaps.Map1:
                    strBuilder.Append("1000012001111111111111111");
                    strBuilder.Append("1111110000000000001111111");
                    strBuilder.Append("1111111011211100000011111");
                    strBuilder.Append("2121213012012000100001111");
                    strBuilder.Append("0000010010010000000001111");
                    strBuilder.Append("0000010010010121011101311"); // 5
                    strBuilder.Append("1000011111010111011100001");
                    strBuilder.Append("1000000001010121011100001");
                    strBuilder.Append("1100011100000000000000000");
                    strBuilder.Append("1111100000000000000011110");
                    strBuilder.Append("1111020000000110000011110"); // 10
                    strBuilder.Append("1211000000001110000011100");
                    strBuilder.Append("1021000000111111000020000");
                    strBuilder.Append("1001000111111111100000000");
                    strBuilder.Append("2000011111111111110000000");
                    break;
                case GameMaps.Map2:
                    strBuilder.Append("1111111111111111100000111");
                    strBuilder.Append("1311111111111111100002111");
                    strBuilder.Append("0000000000001000200000111");
                    strBuilder.Append("0000000000001000000000111");
                    strBuilder.Append("0000020202000000110000111");
                    strBuilder.Append("0000000000001111111101111"); // 5
                    strBuilder.Append("0000000100001202100100001");
                    strBuilder.Append("0000002200001000120100001");
                    strBuilder.Append("0000000000001101100100011");
                    strBuilder.Append("0000000000000000000100011");
                    strBuilder.Append("0000000000000000000110111"); // 10
                    strBuilder.Append("0000000000000000011110111");
                    strBuilder.Append("0000000000001101011110131");
                    strBuilder.Append("1100200002000101111000000");
                    strBuilder.Append("1110000000000000111200000");
                    break;
            }

            return strBuilder.ToString();
        }
        #endregion
    }
}