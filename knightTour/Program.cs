using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knightTour
{
    class Program
    {
        static void cetakPapan(int[,] papan)
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (papan[i, j] < 10)
                    {
                        Console.Write("[0" + papan[i, j] + "]");
                    }
                    else
                    {
                        Console.Write("[" + papan[i, j] + "]");
                    }
                    //Console.Write(papan[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //1. Inisialisasi Papan Catur
            //2. Representasi 8 Langkah Kuda
            //3. Cari Solusi
            //4.    If lkh>64 then goals tercapai
            //5.      Mencari setiap langkah 8 kuda
            //6.         cari solusi sampai didapatkan goals

            //1. Inisialisasi Papan Catur
            int[,] papan = new int[8, 8];
            //mengisi papan dengan nilai 0
            for (int i = 0; i < 8; i++)
            {
                for (int j=0; j < 8; j++)
                {
                    papan[i, j] = 0;
                }
            }
            cetakPapan(papan);
            //langkah ke-1 done

            //2. Representasi 8 Langkah Kuda
            int[] xm = { 1, 2, 2, 1,-1,-2,-2,-1};
            int[] ym = {-2,-1, 1, 2, 2, 1,-1,-2};

            papan[0, 0] = 1;
            cetakPapan(papan);
            //langkah ke-2 done

            //3. Cari Solusi
            if (cariSolusi(0, 0, 2, xm, ym, papan) == 0)
            {
                Console.Write("Tidak Ada Solusi");
            }
            else
            {
                cetakPapan(papan);
            }
            //langkah ke-3 done

            Console.ReadKey();

        }//end void main
        static int bolehJalan(int x, int y, int i, int[] xm, int[] ym, int[,] papan)
        {
            //untuk 8 queens {papan==0}

            int x_next = x + xm[i];
            int y_next = y + ym[i];
            //bagaimana boleh jalan --> x_next 0-7, y_next 0-7, papan[x_next, y_next] ==0
            if (x_next>=0 && x_next<8 && y_next>=0 && y_next<8 && papan[x_next, y_next] == 0)
            {
                return 1;
            } else
            {
                return 0;
            }
        }

        static int cariSolusi(int x, int y, int lkh, int[] xm, int[] ym, int[,] papan)
        {
            //x=0, y=0, lkh=2

            //langkah ke-4 goals tercapai
            if (lkh == 65) return 1;
            else
            {
                //goals belum tercapai
                //5. Mencari setiap 8 langkah kuda
                for(int i = 0; i < 8; i++)
                {
                    //x=0, y=0, lkh=2 --> i=0 x_next =1, y_next=-2 tidak boleh jalan
                    //x=0, y=0, lkh=2 --> i=1 x_next =2, y_next=-1 tidak boleh jalan
                    //x=0, y=0, lkh=2 --> i=2 x_next =2, y_next=1 boleh jalan
                    //x dan y adalah posisi kuda di lkh==1 , lkh=2
                    int x_next = x + xm[i];
                    int y_next = y + ym[i];
                    //cek apakah posisi itu available/boleh jalan
                    if (bolehJalan(x,y,i,xm,ym,papan) == 1)
                    {
                        papan[x_next, y_next] = lkh; //lkh==2
                        //untuk 8 queens {
                            //semua yang merupakan langkah menteri itu ditambah 1
                            //vertikal, diagonalx2, horizontal }

                        //cetakPapan(papan);
                        //Console.ReadKey();
                        //6. Cari solusi sampai ditemukan goals
                        if (cariSolusi(x_next, y_next, lkh+1, xm, ym, papan) == 1)
                        {
                            return 1;
                        }
                        else
                        {
                            papan[x_next, y_next] = 0;
                            //untuk 8 queens {
                                //semua langkah menteri itu dikurangi 1
                                //vertikal, diagonalx2, horizontal}
                        }
                    }
                }//end for i
            }//end if

            return 0;
        }

    }//end class
}
