using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyXiNghiepMay;
using QuanLyXiNghiepMay.Forms.Form_Tables.Form_Child;
using QuanLyXiNghiepMay.Forms.Form_Tables.Form_Detail.Form_Phieu_Nhan;
using QuanLyXiNghiepMay.Forms.Form_Tables.Form_Parent;
using QuanLyXiNghiepMay.R.ControlerForForm;
using System;

namespace QuanLyXiNghiepMayUnitTest
{
    [TestClass]
    public class UnitTestGeneral
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestMethodLoginCase1
            ()
        {
            string usename = "";
            string password = "";
            FormLogin formLogin = new FormLogin();
            bool actual = formLogin.CheckLogin(usename, password);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestMethodLoginCase2
            ()
        {
            string usename = "admin";
            string password = "123";
            FormLogin formLogin = new FormLogin();
            bool actual = formLogin.CheckLogin(usename, password);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestMethodLoginCase3
            ()
        {
            string usename = "admin";
            string password = "";
            FormLogin formLogin = new FormLogin();
            bool actual = formLogin.CheckLogin(usename, password);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\DataSource\dataLogin.csv", "dataLogin#csv", DataAccessMethod.Sequential)]
        public void TestMethodLoginDataSource
            ()
        {
            string _usename = TestContext.DataRow[0].ToString().Remove(0, 1);
            string _password = TestContext.DataRow[1].ToString().Remove(0, 1);
            bool _result = bool.Parse(TestContext.DataRow[2].ToString().Remove(0, 1));

            FormLogin formLogin = new FormLogin();
            bool actual = formLogin.CheckLogin(_usename, _password);
            TestContext.WriteLine("Message..." + actual + _usename + ":" + _password);
            Assert.AreEqual(_result, actual);
        }



        [TestMethod]
        public void TestMethodAddNguyenLieuToDataBase
            ()
        {
            NguyenLieu nguyenLieu = new NguyenLieu();
            nguyenLieu.ma = "NL241220220002";
            nguyenLieu.ten = "ten nguyen lieu test 1";
            nguyenLieu.ghiChu = "khong co";
            bool actual = new FormNguyenLieu().addNguyenLieuToDataBase(nguyenLieu);

            Assert.AreEqual(false, actual);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\DataSource\dataNguyenLieu.csv", "dataNguyenLieu#csv", DataAccessMethod.Sequential)]
        public void TestMethodAddNguyenLieuToDataBaseDataSource
           ()
        {

            string _ma = TestContext.DataRow[0].ToString().Remove(0, 1);
            string _name = TestContext.DataRow[1].ToString().Remove(0, 1);
            string _ghiChu = TestContext.DataRow[2].ToString().Remove(0, 1);
            bool _result = bool.Parse(TestContext.DataRow[3].ToString().Remove(0, 1));

            NguyenLieu nguyenLieu = new NguyenLieu();
            nguyenLieu.ma = _ma;
            nguyenLieu.ten = _name;
            nguyenLieu.ghiChu = _ghiChu;
            bool actual = new FormNguyenLieu().addNguyenLieuToDataBase(nguyenLieu);

            Assert.AreEqual(_result, actual);
        }

        [TestMethod]
        public void TestMethodGetMaPhanXuong
            ()
        {
            string maExpected = "PX";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaPhanXuong().Remove(10, 3);
            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }

        [TestMethod]
        public void TestMethodGetMaCongDoan
            ()
        {
            string maExpected = "CD";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaCongDoan().Remove(10, 3);

            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }

        [TestMethod]
        public void TestMethodGetMaPhieuPhanCong
    ()
        {
            string maExpected = "PC";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaPhieuPhanCong().Remove(10, 3);
            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }
        [TestMethod]
        public void TestMethodGetMaNguyenLieu
   ()
        {
            string maExpected = "NL";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaNguyenLieu().Remove(10, 3);

            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }

        [TestMethod]
        public void TestMethodGetMaPhieuNhan
   ()
        {
            string maExpected = "PN";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaPhieuNhan().Remove(10, 3);

            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }

        [TestMethod]
        public void TestMethodGetMaSanPham
   ()
        {
            string maExpected = "SP";
            maExpected += DateTime.Now.ToString("yyyyMMdd");
            string maActual = Precenter.getMaSanPham().Remove(10, 3);

            TestContext.WriteLine("Message..." + maActual + ":" + maExpected);

            Assert.AreEqual(expected: maExpected, maActual);
        }
    }
}
