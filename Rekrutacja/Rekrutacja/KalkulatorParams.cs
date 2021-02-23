using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    public class KalkulatorParams : ContextBase
    {



        [ControlEdit(ControlEditKind.Decimal)]
        public decimal A { get; set; }

        [ControlEdit(ControlEditKind.Decimal)]
        public decimal B { get; set; }

        #region DataObliczen
        public Date _dataObliczen;
        [Caption("Data obliczeń")]
        public Date DataObliczen 
        {
            get { return _dataObliczen; }
            set
            {
                _dataObliczen = value;
                if (_dataObliczen == Date.Empty)
                {
                    _dataObliczen = Date.Today;
                }
                OnChanged();
            }
        }
        #endregion

        #region Operacje
        private char[] _dostepneOperacje= "+-*/".ToCharArray();
        public char Operacja { get; set; }

        public object GetListOperacja()
        {
            return _dostepneOperacje;
        }
        #endregion

        public KalkulatorParams(Context context) : base(context)
        {
            this.DataObliczen = Date.Today;
            Operacja = _dostepneOperacje.FirstOrDefault();
        }
    }
}
