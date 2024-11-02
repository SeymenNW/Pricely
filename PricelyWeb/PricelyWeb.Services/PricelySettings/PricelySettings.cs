using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricelyWeb.Services.PricelySettings
{
    //Denne singleton skal sikre at man de env vars man sætter i server projektet skal kunne bruges i klinet projektet.
        public class PricelySettings
        {

            #region Singleton Pattern
            public static PricelySettings _instance;

            public PricelySettings() { }

            public static PricelySettings Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new PricelySettings();
                    }
                    return _instance;
                }
            }
            #endregion

            public string BackendUrl { get; set; }
        }

    }


