using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesBudget
{
    class Chapitre
    {
        String Libelle, Type;
        int NumChapitre, Budget;

        public Chapitre(int NumChapitre,String Libelle,int Budget, string Type)
        {
            this.NumChapitre=NumChapitre;
            this.Libelle = Libelle;
            this.Budget = Budget;
            this.Type = Type;
         }





    }
}
