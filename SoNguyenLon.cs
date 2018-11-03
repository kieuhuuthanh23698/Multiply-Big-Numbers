using System;
using System.Collections.Generic;
using System.Text;

namespace BaiToanNhanSoNguyenLon
{
    class SoNguyenLon
    {
        String soNguyen;
        int n;
        int dau;//0 / -1 / 1

        public SoNguyenLon()
        {
            this.soNguyen = "";
        }

        public SoNguyenLon(String songuyen, int dau)
        {
            this.dau = dau;
            this.soNguyen = songuyen;
            this.n = this.soNguyen.Length;
        }

        public String tachSoLeft()
        {
            int n = this.n / 2;
            String kq = "";
            for (int i = 0; i < n; i++)
                kq += this.soNguyen[i] + "";
            return kq;
        }

        public String tachSoRight()
        {
            int n = this.n / 2;
            String kq = "";
            for (int i = n; i < this.n; i++)
                kq += this.soNguyen[i] + "";
            return kq;
        }

        public static void chuan(String a, String b)
        {
            int n = a.Length - b.Length;//n > 0 , n < 0 , n = o
            if (n == 0)
                return;
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                    b = "0" + b;
            }
            else
            {
                for (int i = 0; i < Math.Abs(n); i++)
                    a = "0" + a;
            }
        }

        public static SoNguyenLon congHaiSoNguyenLon(SoNguyenLon A, SoNguyenLon B)
        {
            int nho = 0;


            int n = A.soNguyen.Length - B.soNguyen.Length;//n > 0 , n < 0 , n = o
            if (n == 0)
            { }
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                    B.soNguyen = "0" + B.soNguyen;
            }
            else
            {
                for (int i = 0; i < Math.Abs(n); i++)
                    A.soNguyen = "0" + A.soNguyen;
            }

            String a = A.soNguyen, b = B.soNguyen, kq = "";
            //System.out.println(a + " cộng " + b);
            int x, y;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                x = int.Parse(a[i] + "");
                y = int.Parse(b[i] + "");
                int tong = x + y + nho;
                if (tong >= 10)
                {
                    kq = (tong + "")[1] + kq;
                    nho = int.Parse((tong + "")[0] + "");
                }
                else
                {
                    kq = tong + kq;
                    nho = 0;
                }
                //System.out.println(i + " : " + x + " cong " + y + " bang " + tong +" nho " + nho);
            }
            if (nho == 1)
                kq = nho + kq;
            SoNguyenLon dapAn = new SoNguyenLon(kq, 1);
            //System.out.println(A.soNguyen + " + " + B.soNguyen + " = " + dapAn.soNguyen);
            //System.out.println("Ket thuc ");
            return dapAn;
        }

        public static String TongHopKQ(SoNguyenLon m1, SoNguyenLon m2, SoNguyenLon m3, int n)
        {
            String kq = "";
            //System.out.println("Bat dau tong hop kq qua cuoi cung ");
            //m1.xuat();
            //m2.xuat();
            //m3.xuat();
            for (int i = 0; i < n; i++)
                m1.soNguyen += "0";
            for (int i = 0; i < n / 2; i++)
                m2.soNguyen += "0";
            //System.out.println("Sau khi tong hop ket qua : " + m1.soNguyen + " " + m2.soNguyen + " " + m3.soNguyen);
            SoNguyenLon m1_m2 = SoNguyenLon.congHaiSoNguyenLon(m1, m2);
            SoNguyenLon dapAn = SoNguyenLon.congHaiSoNguyenLon(m1_m2, m3);
            kq = dapAn.soNguyen;
            return kq;
        }

        public string xuat() {
            return this.soNguyen;
	    }

        public static SoNguyenLon nhanSoNguyenLon(SoNguyenLon a, SoNguyenLon b)
        {
            //System.out.println("Bat dau nhan hai so nguyen lon : " + a.soNguyen + " và  " + b.soNguyen);
            SoNguyenLon kq;
            int n;
            if (a.n < b.n)
            {
                n = b.n - a.n;
                for (int i = 0; i < n; i++)
                    a.soNguyen = "0" + a.soNguyen;
            }
            else if (a.n > b.n)
            {
                n = a.n - b.n;
                for (int i = 0; i < n; i++)
                    b.soNguyen = "0" + b.soNguyen;

            }
            else
                n = a.n;//số lượng chữ số

            if (n == 1)
            {
                int tich = int.Parse(a.soNguyen) * int.Parse(b.soNguyen);
                int dau = a.dau * b.dau;
                kq = new SoNguyenLon(tich + "", dau);
                return kq;
            }
            else
            {
                SoNguyenLon A = new SoNguyenLon(a.tachSoLeft(), 1);//5
                //A.xuat();
                SoNguyenLon B = new SoNguyenLon(a.tachSoRight(), 1);//5
                //B.xuat();
                SoNguyenLon C = new SoNguyenLon(b.tachSoLeft(), 1);//5
                //C.xuat();
                SoNguyenLon D = new SoNguyenLon(b.tachSoRight(), 1);//5
                //D.xuat();

                SoNguyenLon m1 = SoNguyenLon.nhanSoNguyenLon(A, C);
                //System.out.println(A.soNguyen + " nhan " + C.soNguyen);
                //m1.xuat();//25

                SoNguyenLon m2_A = SoNguyenLon.nhanSoNguyenLon(A, D);
                //System.out.println(A.soNguyen + " nhan " + D.soNguyen);
                //m2_A.xuat();

                SoNguyenLon m2_B = SoNguyenLon.nhanSoNguyenLon(B, C);
                //System.out.println(B.soNguyen + " nhan " + C.soNguyen);
                //m2_B.xuat();

                SoNguyenLon m2 = SoNguyenLon.congHaiSoNguyenLon(m2_A, m2_B);
                //System.out.println(m2_A.soNguyen + " cong " + m2_B.soNguyen);
                //m2.xuat();//0

                SoNguyenLon m3 = SoNguyenLon.nhanSoNguyenLon(B, D);
                //System.out.println(B.soNguyen + " nhan " + D.soNguyen);
                //m3.xuat();//25

                int dau = a.dau * b.dau;
                String tonghop = SoNguyenLon.TongHopKQ(m1, m2, m3, n);
                kq = new SoNguyenLon(tonghop, dau);
            }

            return kq;
        }
    }
}
