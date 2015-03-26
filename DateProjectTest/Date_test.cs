using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateProject;

namespace DateProjectTest
{
    [TestClass]
    public class Date_test
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNegativanBrojUDatumu()
        {
            var wallet = new Date(2, 23, -2015);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNulaUDatumu()
        {
            var wallet = new Date(2, 0, 2015);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestNepostojeciMjesec()
        {
            var wallet = new Date(2, 13, 2015);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestPrevelikBrojDana()
        {
            var wallet = new Date(31, 9, 2015);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestPrevelikBrojDanaUVeljaci()
        {
            var wallet = new Date(29, 2, 2015);
        }


        [TestMethod]
        public void TestDohvatiMjesec()
        {
            var datum = new Date();
            Assert.AreEqual(
                "Siječanj",
                datum.getMonthName(1),
                "Pogresan izracun mjeseca"
                );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestDohvatiMjesecGreska()
        {
            var datum = new Date();
            string ime = datum.getMonthName(13);
        }

        [TestMethod]
        public void TestDohvatiMjesec_2()
        {
            var datum = new Date(1,1,2015);
            Assert.AreEqual(
                "Siječanj",
                datum.getMonthName(),
                "Pogresno dohvacen mjesec!"
                );
        }

        [TestMethod]
        public void TestDohvatiBrojPreostalihDana()
        {
            var datum = new Date( );
            Assert.AreEqual(
                29,
                datum.getNumberOfRemaingDaysInMonth(2,3),
                "Pogresan izracun preostalih dana!"
                );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestDohvatiBrojDanaGreskaVeljacaBezGodine()
        {
            var datum = new Date();
            int broj = datum.getNumberOfRemaingDaysInMonth(2, 2);
        }

        [TestMethod]
        public void TestDohvatiBrojPreostalihDanaSGodinom()
        {
            var datum = new Date();
            Assert.AreEqual(
                26,
                datum.getNumberOfRemaingDaysInMonth(2, 2,2015),
                "Pogresan izracun preostalih dana!"
                );
        }

        [TestMethod]
        public void TestDohvatiBrojPreostalihDanaSGodinomPrijestupna()
        {
            var datum = new Date();
            Assert.AreEqual(
                27,
                datum.getNumberOfRemaingDaysInMonth(2, 2, 2012),
                "Pogresan izracun preostalih dana!"
                );
        }

        [TestMethod]
        public void TestDohvatiBrojPreostalihDanaUneseniDatum()
        {
            var datum = new Date(2,2,2015);
            Assert.AreEqual(
                26,
                datum.getNumberOfRemaingDaysInMonth(),
                "Pogresan izracun preostalih dana!"
                );
        }
        [TestMethod]
        public void TestDohvatiBrojPreostalihDanaUneseniDatumPrijestupna()
        {
            var datum = new Date(2,2,2012);
            Assert.AreEqual(
                27,
                datum.getNumberOfRemaingDaysInMonth(),
                "Pogresan izracun preostalih dana!"
                );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestDohvatiBrojDanaGreskaPreviseDana()
        {
            var datum = new Date();
            int broj = datum.getNumberOfRemaingDaysInMonth(29,2,2015);
        }


        [TestMethod]
        public void TestPrijestupneGodineNijePrijestupna()
        {
            var datum = new Date();
            Assert.AreEqual(
                false,
                datum.isLeapYear(2015),
                "Pogresan izracun prijestupne godine"
                );
        }

        [TestMethod]
        public void TestPrijestupneGodinePrijestupna()
        {
            var datum = new Date();
            Assert.AreEqual(
                true,
                datum.isLeapYear(2012),
                "Pogresan izracun prijestupne godine"
                );
        }
        [TestMethod]
        public void TestPrijestupneGodinePrijestupnaZbog400()
        {
            var datum = new Date();
            Assert.AreEqual(
                true,
                datum.isLeapYear(2000),
                "Pogresan izracun prijestupne godine"
                );
        }

        [TestMethod]
        public void TestPrijestupneGodineNijePrijestupna_2()
        {
            var datum = new Date(2,2,2015);
            Assert.AreEqual(
                false,
                datum.isLeapYear(),
                "Pogresan izracun prijestupne godine"
                );
        }

        [TestMethod]
        public void TestPrijestupneGodinePrijestupna_2()
        {
            var datum = new Date(2,2,2012);
            Assert.AreEqual(
                true,
                datum.isLeapYear(),
                "Pogresan izracun prijestupne godine"
                );
        }
        [TestMethod]
        public void TestPrijestupneGodinePrijestupnaZbog400_2()
        {
            var datum = new Date(2,2,2000);
            Assert.AreEqual(
                true,
                datum.isLeapYear(),
                "Pogresan izracun prijestupne godine"
                );
        }
    }
}
