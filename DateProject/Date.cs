using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateProject
{
    public class Date //omogućava rad s datumima
    {
        int dan, mjesec, godina;
        string[] naziv_mjeseca= new string[12] {"Siječanj","Veljača","Ožujak","Travanj","Svibanj","Lipanj","Srpanj","Kolovoz","Rujan","Listopad","Studeni","Prosinac"};
        int[] broj_dana_u_mjesecu = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public Date(int xdan, int xmjesec, int xgodina)
        {
            //Konstruktor klase prima godinu, mjesec i dan kao int
            CheckDateFormat(xdan, xmjesec, xgodina);
            this.dan = xdan;
            this.mjesec = xmjesec;
            this.godina = xgodina;
        }

        public Date()
        {

        }

        private void CheckDateFormat(int dan, int mjesec, int godina)
        {
            if (dan <= 0 || mjesec <= 0 || godina <= 0)
            {
                throw new InvalidProgramException("Svi uneseni brojevi moraju biti pozitivni!");
            }
            if (mjesec > 12)
            {
                throw new InvalidProgramException("Unijeli ste broj mjeseca koji ne postoji!");
            }
            if (dan > broj_dana_u_mjesecu[mjesec-1] || (isLeapYear(godina) && mjesec==2 && dan > broj_dana_u_mjesecu[mjesec-1] + 1))
            {
                    throw new InvalidProgramException("Unijeli ste veći broj dana nego što ih odabrani mjesec ima!");
            }
        }

        public string getMonthName(int mjesec)
        {
            if (mjesec > 12 || mjesec < 0)
            {
                throw new InvalidProgramException("Unijeli ste broj mjeseca koji ne postoji!");
            }
            return naziv_mjeseca[mjesec-1];
        }

        public string getMonthName()
        {
            return naziv_mjeseca[this.mjesec-1];
        }

        public int getNumberOfRemaingDaysInMonth(int dan, int mjesec, int godina)
        {
            if (mjesec == 2 && isLeapYear(godina) && mjesec<=12)
            {
                return GetNumberOfDays(dan, mjesec) + 1;
            }
            return GetNumberOfDays(dan, mjesec);

        }

        public int getNumberOfRemaingDaysInMonth(int dan, int mjesec)
        {
            if (mjesec == 2)
            {
                throw new InvalidProgramException("Broj dana u veljači razlikuje se ovisno o godini!");
            }
            return GetNumberOfDays(dan, mjesec);
        }

        private int GetNumberOfDays(int dan, int mjesec)
        {
            if (dan > broj_dana_u_mjesecu[mjesec - 1])
            {
                throw new InvalidProgramException("Unijeli ste veći broj dana nego što ih odabrani mjesec ima!");
            }
            return broj_dana_u_mjesecu[mjesec - 1] - dan;
        }

        public int getNumberOfRemaingDaysInMonth()
        {
            if (this.mjesec == 2 && this.isLeapYear()&& this.mjesec<=12)
            {
                return broj_dana_u_mjesecu[this.mjesec - 1] - this.dan + 1;
            }
            return broj_dana_u_mjesecu[this.mjesec - 1] - this.dan;
        }



        public bool isLeapYear(int godina)
        {
            //prijestupne godine su sve djeljive s 4, ako nisu djeljive sa 100, 
            //kojima se dodaju one koju su djeljive sa 400
            //npr 2000-ta je prijestupna iako je djeljiva sa 100, jer je djeljiva sa 400
            return ((godina%4==0&&godina%10!=0)||godina%400==0);
        }

        public bool isLeapYear()
        {
            //prijestupne godine su sve djeljive s 4, ako nisu djeljive sa 100, 
            //kojima se dodaju one koju su djeljive sa 400
            //npr 2000-ta je prijestupna iako je djeljiva sa 100, jer je djeljiva sa 400
            return ((this.godina%4==0&&this.godina%10!=0)||this.godina%400==0);
        }

    }
}
