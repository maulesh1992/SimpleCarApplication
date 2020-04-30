//Project:  CarsSimpleApplication (Montu's Car Inventory Application)
//Creator:   Montu Patel
//File:      Cars.cs

namespace CarsSimpleApplication
{
    class Cars
    {

        //Class Declarations
        #region
        private int _ID;
        private string _Year;
        private string _Make;
        private string _Model;
        private string _Color;
        #endregion

        // Class Properties
        #region
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }

        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        #endregion

        // Class Constructors
        #region
        public Cars()
        {
            //no code required
        }
        public Cars(int id)
        {
            ID = id;
            Year = "";
            Make = "";
            Model = "";
            Color = "";
        }
        #endregion

    }
}
