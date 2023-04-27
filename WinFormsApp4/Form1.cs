
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using xNet;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            while (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }
        int dulieu = 0;

        string globalcookie = "";

        private void bt_getdata_Click(object sender, EventArgs e)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 OPR/94.0.0.0";
            //  string cookie = "PHPSESSID=tblo3fhsp8i18tmaeb2j6vegg9";
            HttpResponse response = http.Get("https://htql.ctu.edu.vn/htql/capcha/securimage_show.php?sid=");
            response.None();
            string dataa = "";
            globalcookie = response.Cookies.ToString();
            if (dulieu == 0)
            {
            //    http.AddHeader("cookie", cookie);
                string html = http.Get("https://htql.ctu.edu.vn/htql").ToString();
                dataa = getBetween(html, "<img id=\"verify_code\" src=\"capcha/securimage_show.php?sid=", "\" onclick=");
                dulieu = 1;
            }
       //     http.AddHeader("cookie", cookie);
            byte[] capcha = http.Get("https://htql.ctu.edu.vn/htql/capcha/securimage_show.php?sid=" + dataa).ToMemoryStream().ToArray();
            //  System.IO.File.WriteAllBytes("catpcha.jpg", capcha);
            //  capchaa.Image = Image.FromFile("catpcha.jpg");
            Image capchapic = (Bitmap)((new ImageConverter()).ConvertFrom(capcha));
            capchaa.Image = capchapic;

        }
        /*
         * back up
         *             HttpRequest http2 = new HttpRequest();
            http2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 OPR/94.0.0.0";
            //string dataPost = "txtDinhDanh=B1805812&txtMatKhau=!u!TBfMK&txtMaBaoVe=dasdsad";
            http2.Cookies = new CookieDictionary();
       //     HttpResponse response = http2.Get("https://htql.ctu.edu.vn/htql/login.php﻿");
            string cookie = "PHPSESSID=1234567891234567891234567";
            string html = http2.Get("https://htql.ctu.edu.vn/htql/login.php").ToString();

            http2.AddHeader("cookie", cookie);
            string capcha = tb_captcha.Text;
            var urlParams = new RequestParams
            {
                ["txtDinhDanh"] = tb_account.Text,
                ["txtMatKhau"] = tb_password.Text,
                ["txtMaBaoVe"] = tb_captcha.Text,
                ["login"] = ""
            };
     //   string contenttype = "application/json";
            string result = http2.Post("https://htql.ctu.edu.vn/htql/detect.php", urlParams).ToString();
            System.IO.File.WriteAllText("res2.html", result);
            new Process { StartInfo = new ProcessStartInfo("res2.html") { UseShellExecute = true } }.Start();
         * 
         */

        string globalcookie2 = "";
        string result = "";


        private void button1_Click(object sender, EventArgs e)
        {

            HttpRequest http2 = new HttpRequest();
            http2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 OPR/94.0.0.0";
            http2.Cookies = new CookieDictionary();
            http2.AddHeader("cookie", globalcookie);
            //MessageBox.Show(globalcookie);
            string capcha = tb_captcha.Text;
            var urlParams = new RequestParams
            {
                ["txtDinhDanh"] = "B1805812",
                ["txtMatKhau"] = "!u!TBfMK",
                ["txtMaBaoVe"] = capcha,
                ["login"] = ""
            };
            HttpResponse response = http2.Post("https://htql.ctu.edu.vn/htql/detect.php", urlParams);

            response.ToFile("res2.html");
            string CookieXenforo = response.Cookies.ToString();
            tb_account.Text = CookieXenforo;
                
      //      response = http2.Post("https://htql.ctu.edu.vn/htql/detect.php", urlParams);
     //        result = response.ToString();
       //     System.IO.File.WriteAllText("res2.html", result);
            new Process { StartInfo = new ProcessStartInfo("res2.html") { UseShellExecute = true } }.Start();


            globalcookie2 = response.Cookies.ToString();
     //       MessageBox.Show(globalcookie2);

            
            

            /*     var urlParams2 = new RequestParams
                 {
                     ["IN"] = "tatca",
                     ["maxNH"] = "2023",
                     ["maxHK"] = "2",
                     ["fileIn"] = "HamInBangDiemSinhVien.php",
                     ["MaSinhVien"] = "B1805812",
                     ["maHDDT"] = "CQ",
                     ["rdoInDiem"] = "rdoInTatCa",
                 };
                 //   string contenttype = "application/json";
                 string result2 = http2.Post("https://qldt.ctu.edu.vn/htql/sinhvien/qldiem/codes/HamInBangDiemSinhVien.php", urlParams2).ToString();
                 System.IO.File.WriteAllText("res7.html", result2);
                 new Process { StartInfo = new ProcessStartInfo("res7.html") { UseShellExecute = true } }.Start();
            */
        }
        string globalecookie3 = "";
        private void button2_Click(object sender, EventArgs e)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            string cookie = "ZDEDebuggerPresent=php,phtml,php3; path=/";
            http.AddHeader("Cookie",cookie);
            HttpResponse response = http.Get("https://dkmonhoc.ctu.edu.vn/htql/sinhvien/hindex.php");
            string htmldata = response.ToString();
       //     globalcookie2 = response.Cookies.ToString();
       //     MessageBox.Show(globalcookie2);
            //      string htmldata = http.Get("https://qldt.ctu.edu.vn/htql/sinhvien/hindex.php").ToString();
            System.IO.File.WriteAllText("res5.html", htmldata);
            globalecookie3 = response.Cookies.ToString();
            MessageBox.Show(globalecookie3);
          //  new Process { StartInfo = new ProcessStartInfo("res5.html") { UseShellExecute = true } }.Start();


            /*
            var urlParams2 = new RequestParams
          {
              ["IN"] = "tatca",
              ["maxNH"] = "2023",
              ["maxHK"] = "2",
              ["fileIn"] = "HamInBangDiemSinhVien.php",
              ["MaSinhVien"] = "B1805812",
              ["maHDDT"] = "CQ",
              ["rdoInDiem"] = "rdoInTatCa",
          };
          //   string contenttype = "application/json";
          string result2 = http.Post("https://qldt.ctu.edu.vn/htql/sinhvien/qldiem/codes/HamInBangDiemSinhVien.php", urlParams2).ToString();
          System.IO.File.WriteAllText("res7.html", result2);
          new Process { StartInfo = new ProcessStartInfo("res7.html") { UseShellExecute = true } }.Start();
            */
 }

 private void button3_Click(object sender, EventArgs e)
 {
            HttpRequest http3 = new HttpRequest();
      //     "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 108.0.0.0 Safari / 537.36 OPR / 94.0.0.0"
            http3.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36 OPR/95.0.0.0";
            //string dataPost = "txtDinhDanh=B1805812&txtMatKhau=!u!TBfMK&txtMaBaoVe=dasdsad";
            http3.Cookies = new CookieDictionary();
            HttpResponse response = http3.Get("https://qldt.ctu.edu.vn/htql/sinhvien/hindex.php");
            response.None();
            MessageBox.Show(response.Cookies.ToString());
            //           string cookie3 = "ZDEDebuggerPresent=php,phtml,php3; PHPSESSID=6h1cipje59dh4oi21lrqfhkji5rcoolt";
            //     string html = http3.Get("https://qldt.ctu.edu.vn/htql/sinhvien/dang_nhap.php").ToString();

            string data1 = getBetween(result, "<input type=\"hidden\" name=\"f6e7a9414bec\" value=\"", "\" />");
            string data2 = getBetween(result, "<input type=\"hidden\" name=\"f2711251a4f\" value=\"", "\" />");


            tb_account.Text = data1;
            tb_password.Text = data2;

            http3.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
         //   http3.AddHeader("Accept-Encoding", "gzip, deflate, br");
            http3.AddHeader("Cache-Control", " max-age=0");
            //   http3.AddHeader("Host", "dkmonhoc.ctu.edu.vn");
            //     http3.AddHeader("Upgrade-Insecure-Requests", "1");
            //     http3.AddHeader("Sec-Fetch-Mode", "navigate");
            http3.AddHeader("Location", "https://qldt.ctu.edu.vn/htql/sinhvien/hindex.php");
           
            var urlParams2 = new RequestParams
            {
                ["txtDinhDanh"] = "B1805812",
                ["txtMatKhau"] = "%21u%21TBfMK",
                ["f6e7a9414bec"] = data1,
                ["f2711251a4f"] = data2,
            };
            // HttpResponse response = http3.Get("https://htql.ctu.edu.vn/htql/login.php");
            // response.None();
         //   http3.AddHeader("name", "frmLogin");
          
            response = http3.Post("https://qldt.ctu.edu.vn/htql/sinhvien/dang_nhap.php", urlParams2);
            //      string contenttype = "application/json";
            string CookieXenforo = response.Cookies.ToString();
            MessageBox.Show(CookieXenforo);
            textBox1.Text = CookieXenforo;
            string result3 = response.ToString(); //http3.Post("https://qldt.ctu.edu.vn/htql/sinhvien/dang_nhap.php", urlParams2).ToString();
            System.IO.File.WriteAllText("res65.html", result3);
            new Process { StartInfo = new ProcessStartInfo("res65.html") { UseShellExecute = true } }.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result3 = readHtmlPage("https://qldt.ctu.edu.vn/htql/sinhvien/dang_nhap.php");
            System.IO.File.WriteAllText("res65.html", result3);
            new Process { StartInfo = new ProcessStartInfo("res65.html") { UseShellExecute = true } }.Start();
        }

        private String readHtmlPage(string url)
        {

            //setup some variables
//
            String txtDinhDanh = "B1805812";
      //      String txtMatKhau = "%21u%21TBfMK";
    //        String f6e7a9414bec = "John";
      //      String lastname = "Smith";

            //setup some variables end

            String result = "";
            String strPost = "?txtDinhDanh=B1805812&txtMatKhau=%2521u%2521TBfMK&f6e7a9414bec=5B180581231xt1&f2711251a4f=4%2521u%2521TBfMKkky1"; //+ "&firstname=" + firstname + "&lastname=" + lastname;
            StreamWriter myWriter = null;

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.CookieContainer = new CookieContainer();
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();

                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }










    }
}