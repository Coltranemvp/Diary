using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearyPetProj.Сontrollers
{
    public class BaseMenuController : BaseController
    {
        private static BaseMenuController instance;
        private static object syncRoot = new();


        private BaseMenuController()
        {
            // nothing here...
        }

        public BaseMenuController(bool initInstance)
        {
            if (initInstance)
                return;

            GetInstance();

            if (instance is not null)
                Start();
            else
            {
                Debug.WriteLine($"{nameof(BaseMenuController)} did not create insnace");
                Debugger.Break();
            }
        }

        public static BaseMenuController GetInstance()
        {
            if (instance is null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new BaseMenuController(true);
                }
            }
            return instance;
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
